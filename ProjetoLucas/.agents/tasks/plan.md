# Implementation Plan — Hotel California (ProjetoLucas)

## Key Decisions

| Decision | Rationale |
|---|---|
| `frmMenu` stays in namespace `ProjetoLucas` (NOT `ProjetoLucas.View`) | `Program.cs` calls `new frmMenu()` without qualification; changing it would break compilation without also changing `Program.cs`, which must stay as-is. |
| All other View classes use namespace `ProjetoLucas.View` | Consistent with existing stub files (`frmCadastroFilial.cs`, `frmCadastroEndereco.cs`, etc.). |
| `Filial.Ativo` changes from `int` to `bool` | Spec requires it; DB column is `BIT`; `Convert.ToBoolean()` used when reading from `DataTable`. |
| Designer files written entirely in code (no `.resx` image resources for new forms) | All current stub Designer files use the default empty `InitializeComponent` pattern — no background images or icons are referenced. Only `frmMenuPrincipal.resx` and `frmSobre.resx` exist and reference images; the rewrites will not use image resources, so no `.resx` changes are needed for those forms. |
| `GetByFilters` in all controllers is `private`; public façade methods are `GetAll()` and `GetXxx(string)` | Mirrors the pattern in the original `FilialController`. |
| `ReservaController.GetAll()` and `GetById()` use a JOIN to `tblHospede` and `tblHotel` | The DataGridView on `frmCadastroReserva` must show guest name and hotel name; a JOIN is cleaner than N+1 controller calls. Extra columns `NomeHospede` and `RazaoSocial` are added to the returned `DataTable` only and are not part of the `Reserva` model. |
| `frmCadastroFilial` ComboBox for Endereço shows `"Logradouro, Número – Cidade/UF"` formatted string | Enough info for a user to identify an address without needing a separate lookup screen mid-flow. |
| `frmCadastroReserva` Hóspede ComboBox shows `"Nome – CPF"` | CPF disambiguates guests with the same name. |
| Masked TextBox for CEP uses mask `##.###-###` (9 chars matching `CHAR(9)` in DB) | Consistent with common Brazilian CEP display format and the DB column size. |
| SQL script uses `IF NOT EXISTS` guard on `CREATE DATABASE` and `IF OBJECT_ID … IS NOT NULL DROP TABLE` in FK order | Allows the script to be run repeatedly on a fresh machine without errors. |

---

## Bug Inventory in FilialController.cs (must all be fixed in step 6)

1. **INSERT column list wrong**: SQL has `Avalicao` (typo, missing 'a') and is missing `IdEndereco`. VALUES list has `Ativo` without `@` prefix (unquoted literal), missing closing `)`, and references `@Avalicao` (wrong param name) instead of `@Avaliacao`.
2. **INSERT param name mismatch**: Parameter added as `@Avaliacao` but SQL references `@Avalicao` — SQL Server will throw "Must declare the scalar variable".
3. **UPDATE SQL missing space before WHERE**: `"...@Ativo" + "WHERE..."` concatenates to `...@AtivoWHERE...` — syntax error.
4. **UPDATE param name mismatch**: SQL column set uses `@Avalicao` but parameter is added as `@Avaliacao`.
5. **DELETE SQL missing space before WHERE**: `"DELETE FROM tblHotel" + "WHERE..."` → `tblHotelWHERE` — syntax error.
6. **GetById SQL missing space before WHERE**: Same concatenation bug as DELETE.
7. **GetById reads `Ativo` as `int`**: `filial.Ativo = (int)dataTable.Rows[0]["Ativo"]` — after the model change to `bool` this must use `Convert.ToBoolean(...)`.
8. **GetByFilters uses wrong variable in WHERE branch**: Code builds base query into `filtro` then appends to `filtros` — the SQL command string used is `filtros` (which now contains the WHERE fragment), not the complete `"SELECT * FROM tblHotel WHERE …"` statement.
9. **GetByFilters loop reads `Rows[0]` instead of `Rows[i]`**: Every iteration overwrites the same first row, so the collection always contains N copies of the first record.
10. **GetByFilters ORDER BY appended to wrong variable**: Same variable confusion as point 8.
11. **GetByFilters `Ativo` read as `int`**: Same model-type issue as point 7.
12. **DataBaseService connection leak**: `ExecuteSql` and `GetDataTable` call `GetConnection()` which opens a connection, but never close it. Must wrap in `using` blocks.

---

## Ordered Implementation Steps

- [ ] 1. Create output directory and fix DataBaseService connection leak.
      Rewrite `Service\DataBaseService.cs`: wrap the `SqlConnection` in `using` inside both `ExecuteSql` and `GetDataTable`. Set `command.Connection` inside the `using` block before executing. Keep the same public signatures (`ExecuteSql(SqlCommand) int`, `GetDataTable(SqlCommand) DataTable`) and the same connection string. The `GetConnection()` helper is removed; connection creation is inlined in each method.
      Files: `c:\ProjetoLucas\ProjetoLucas\Service\DataBaseService.cs`
      Verify: Project compiles — `msbuild ProjetoLucas.csproj /p:Configuration=Debug` exits 0.

- [ ] 2. Fix Filial model — change Ativo from int to bool.
      Rewrite `Models\Filial.cs`: change `public int Ativo { get; set; }` to `public bool Ativo { get; set; }`. Keep all other properties and the `FilialColletion` class identical. Remove unused `using` directives (`System.Security.Cryptography.X509Certificates`, `System.Security.Permissions`).
      Files: `c:\ProjetoLucas\ProjetoLucas\Models\Filial.cs`
      Verify: Project compiles.

- [ ] 3. Create new model files: Hospede, Endereco, Reserva.
      Create three files following the exact property lists in the spec. Each file defines two classes: the entity class and a corresponding `*Collection : List<*>` class.
      - `Models\Hospede.cs` — namespace `ProjetoLucas.Models`, class `Hospede` (IdHospede int, Nome string, CPF string, RG string, Telefone string, Email string, DataNascimento DateTime, Nacionalidade string, Ativo bool), class `HospedeCollection : List<Hospede>`.
      - `Models\Endereco.cs` — namespace `ProjetoLucas.Models`, class `Endereco` (IdEndereco int, Logradouro string, Numero string, Complemento string, Bairro string, Cidade string, Estado string, CEP string), class `EnderecoCollection : List<Endereco>`.
      - `Models\Reserva.cs` — namespace `ProjetoLucas.Models`, class `Reserva` (IdReserva int, IdHospede int, IdFilial int, NumeroQuarto int, TipoQuarto string, DataCheckin DateTime, DataCheckout DateTime, ValorDiaria decimal, Observacoes string, Status string), class `ReservaCollection : List<Reserva>`.
      Files: `c:\ProjetoLucas\ProjetoLucas\Models\Hospede.cs`, `Models\Endereco.cs`, `Models\Reserva.cs`
      Verify: Project compiles (after step 6 adds these to `.csproj`).

- [ ] 4. Rewrite FilialController with all bugs fixed.
      Rewrite `Controller\FilialController.cs` applying every fix from the Bug Inventory above:
      - `Inserir`: SQL → `INSERT INTO tblHotel (RazaoSocial, CNPJ, Telefone, Email, Avaliacao, IdEndereco, Ativo) VALUES (@RazaoSocial, @CNPJ, @Telefone, @Email, @Avaliacao, @IdEndereco, @Ativo)`. Parameters use `@Avaliacao`. Read `Ativo` with `Convert.ToBoolean()`.
      - `Alterar`: SQL → `"UPDATE tblHotel SET RazaoSocial=@RazaoSocial, CNPJ=@CNPJ, Telefone=@Telefone, Email=@Email, Avaliacao=@Avaliacao, IdEndereco=@IdEndereco, Ativo=@Ativo WHERE IdFilial=@idFilial"` (single string literal, no concatenation gap). Parameter `@Avaliacao` matches SQL.
      - `Excluir`: SQL → `"DELETE FROM tblHotel WHERE IdFilial=@idFilial"` (single string literal).
      - `GetById`: SQL → `"SELECT * FROM tblHotel WHERE IdFilial=@idFilial"` (single string literal). Read `Ativo` with `Convert.ToBoolean()`.
      - `GetByFilters(string filtros = "")`: Build the full query string into one local variable `sql`. When `filtros != ""`, append `" WHERE " + filtros`. Always append `" ORDER BY IdFilial"`. Pass `sql` to `SqlCommand`. In the loop use `dataTable.Rows[i]` not `Rows[0]`. Read `Ativo` with `Convert.ToBoolean()`.
      - Make `GetByFilters` private. Public methods `GetAll()` and `GetFilials(string)` delegate to it (unchanged interface).
      Files: `c:\ProjetoLucas\ProjetoLucas\Controller\FilialController.cs`
      Verify: Project compiles.

- [ ] 5. Create HospedeController.
      New file `Controller\HospedeController.cs`, namespace `ProjetoLucas.Controller`, following the fixed FilialController pattern exactly:
      - `Inserir(Hospede hospede) int` — `INSERT INTO tblHospede (Nome, CPF, RG, Telefone, Email, DataNascimento, Nacionalidade, Ativo) VALUES (@Nome, @CPF, @RG, @Telefone, @Email, @DataNascimento, @Nacionalidade, @Ativo)`
      - `Alterar(Hospede hospede) int` — `UPDATE tblHospede SET Nome=@Nome, CPF=@CPF, RG=@RG, Telefone=@Telefone, Email=@Email, DataNascimento=@DataNascimento, Nacionalidade=@Nacionalidade, Ativo=@Ativo WHERE IdHospede=@IdHospede`
      - `Excluir(int idHospede) int` — `DELETE FROM tblHospede WHERE IdHospede=@IdHospede`
      - `GetById(int idHospede) Hospede` — `SELECT * FROM tblHospede WHERE IdHospede=@IdHospede`; map all columns; `Ativo = Convert.ToBoolean(row["Ativo"])`.
      - `private GetByFilters(string filtros = "") HospedeCollection` — same pattern; loop uses `Rows[i]`; ORDER BY IdHospede.
      - `GetAll() HospedeCollection` — delegates to `GetByFilters()`.
      - `GetHospedes(string value) HospedeCollection` — delegates to `GetByFilters("Nome LIKE '%" + value + "%'")`.
      Files: `c:\ProjetoLucas\ProjetoLucas\Controller\HospedeController.cs`
      Verify: Project compiles.

- [ ] 6. Create EnderecoController.
      New file `Controller\EnderecoController.cs`, namespace `ProjetoLucas.Controller`:
      - `Inserir(Endereco e) int` — `INSERT INTO tblEndereco (Logradouro, Numero, Complemento, Bairro, Cidade, Estado, CEP) VALUES (@Logradouro, @Numero, @Complemento, @Bairro, @Cidade, @Estado, @CEP)`
      - `Alterar(Endereco e) int` — `UPDATE tblEndereco SET Logradouro=@Logradouro, Numero=@Numero, Complemento=@Complemento, Bairro=@Bairro, Cidade=@Cidade, Estado=@Estado, CEP=@CEP WHERE IdEndereco=@IdEndereco`
      - `Excluir(int idEndereco) int` — `DELETE FROM tblEndereco WHERE IdEndereco=@IdEndereco`
      - `GetById(int idEndereco) Endereco` — `SELECT * FROM tblEndereco WHERE IdEndereco=@IdEndereco`
      - `private GetByFilters(string filtros = "") EnderecoCollection` — loop uses `Rows[i]`; ORDER BY IdEndereco.
      - `GetAll() EnderecoCollection` — delegates to `GetByFilters()`.
      - `GetEnderecos(string value) EnderecoCollection` — delegates to `GetByFilters("Logradouro LIKE '%" + value + "%'")`.
      Files: `c:\ProjetoLucas\ProjetoLucas\Controller\EnderecoController.cs`
      Verify: Project compiles.

- [ ] 7. Create ReservaController.
      New file `Controller\ReservaController.cs`, namespace `ProjetoLucas.Controller`:
      - `Inserir(Reserva r) int` — `INSERT INTO tblReserva (IdHospede, IdFilial, NumeroQuarto, TipoQuarto, DataCheckin, DataCheckout, ValorDiaria, Observacoes, Status) VALUES (@IdHospede, @IdFilial, @NumeroQuarto, @TipoQuarto, @DataCheckin, @DataCheckout, @ValorDiaria, @Observacoes, @Status)`
      - `Alterar(Reserva r) int` — full UPDATE with WHERE IdReserva=@IdReserva
      - `Excluir(int idReserva) int` — DELETE FROM tblReserva WHERE IdReserva=@IdReserva
      - `GetById(int idReserva) Reserva` — JOIN query: `SELECT r.*, h.Nome AS NomeHospede, f.RazaoSocial FROM tblReserva r INNER JOIN tblHospede h ON r.IdHospede=h.IdHospede INNER JOIN tblHotel f ON r.IdFilial=f.IdFilial WHERE r.IdReserva=@IdReserva`; map all `Reserva` properties from `r.*` columns; `NomeHospede` and `RazaoSocial` are extra columns in the DataTable but are NOT mapped to the model (they are used directly by the View from the DataGridView binding).
      - `private GetByFilters(string filtros = "") ReservaCollection` — same JOIN query without WHERE clause; when `filtros != ""` append `" WHERE " + filtros`; ORDER BY r.IdReserva; loop uses `Rows[i]`.
      - `GetAll() ReservaCollection` — delegates to `GetByFilters()`.
      - `GetReservas(string value) ReservaCollection` — delegates to `GetByFilters("r.Status LIKE '%" + value + "%'")`.
      - Add a separate `GetDataTableAll() DataTable` method that runs the JOIN query and returns the raw DataTable — used by the View to bind the DataGridView directly (showing NomeHospede and RazaoSocial columns).
      Files: `c:\ProjetoLucas\ProjetoLucas\Controller\ReservaController.cs`
      Verify: Project compiles.

- [ ] 8. Update ProjetoLucas.csproj — add compile entries for new files.
      Add `<Compile>` entries for all new files without removing any existing entry:
      ```xml
      <Compile Include="Models\Hospede.cs" />
      <Compile Include="Models\Endereco.cs" />
      <Compile Include="Models\Reserva.cs" />
      <Compile Include="Controller\HospedeController.cs" />
      <Compile Include="Controller\EnderecoController.cs" />
      <Compile Include="Controller\ReservaController.cs" />
      ```
      Insert them after the existing `<Compile Include="Controller\FilialController.cs" />` and `<Compile Include="Models\Filial.cs" />` lines respectively (grouping by folder for readability).
      Files: `c:\ProjetoLucas\ProjetoLucas\ProjetoLucas.csproj`
      Verify: `msbuild ProjetoLucas.csproj /p:Configuration=Debug` — BUILD SUCCEEDED, 0 errors.

- [ ] 9. Rewrite frmMenuPrincipal.cs and frmMenuPrincipal.Designer.cs.
      The current `frmMenuPrincipal.cs` already has the correct event handlers and correct namespace (`ProjetoLucas`). Rewrite to improve the visual presentation:
      **frmMenuPrincipal.cs** (`namespace ProjetoLucas`, `partial class frmMenu : Form`):
      - Constructor calls `InitializeComponent()`.
      - `Form_Load` event: applies the dark theme to the MenuStrip renderer (use `ToolStripProfessionalRenderer` with a custom `ProfessionalColorTable` overriding `MenuItemSelected`, `MenuBorder`, `MenuStripGradientBegin/End` to the dark color).
      - Retain all five click handlers (cadastrarFilial, cadastrarHospede, cadastrarEndereco, cadastrarNovaReserva, sobre) — open forms with `ShowDialog()`.
      **frmMenuPrincipal.Designer.cs** (`namespace ProjetoLucas`, `partial class frmMenu`):
      - Remove `BackgroundImage` and `Icon` resource references (they cause compile errors on machines without the `.resx` image data; the dark `BackColor` replaces them).
      - `this.BackColor = Color.FromArgb(30, 30, 45)`
      - `ClientSize = new Size(934, 561)` (950x600 outer → ~934x561 client)
      - `FormBorderStyle = FixedDialog`, `MaximizeBox = false`, `StartPosition = CenterScreen`
      - `Text = "Hotel California — Sistema de Gestão Hoteleira"`
      - MenuStrip: `BackColor = Color.FromArgb(45, 45, 65)`, `ForeColor = Color.White`. All top-level `ToolStripMenuItem` items: `ForeColor = Color.White`.
      - Add `lblTitulo`: `Text = "Hotel California"`, `Font = new Font("Segoe UI", 24, FontStyle.Bold)`, `ForeColor = Color.White`, `AutoSize = false`, `TextAlign = ContentAlignment.MiddleCenter`, centered horizontally around y≈180.
      - Add `lblSubtitulo`: `Text = "Sistema de Gestão Hoteleira"`, `Font = new Font("Segoe UI", 12, FontStyle.Italic)`, `ForeColor = Color.White`, centered below title.
      - Bottom status panel (`flpBOTTON` or `pnlStatus`): `BackColor = Color.FromArgb(20, 20, 35)`, label text `"Desenvolvido por: Renan Carvalho dos Santos | João | Cayc"`, `ForeColor = Color.White`.
      - Keep all existing menu item names and event-handler hook-ups (`cadastrarFilialToolStripMenuItem_Click`, etc.) so the `.cs` event handlers still wire up.
      - **Remove** the `BackgroundImage` and `Icon` resource assignments and the `ComponentResourceManager` usage — replace with plain `BackColor`.
      Files: `c:\ProjetoLucas\ProjetoLucas\View\frmMenuPrincipal.cs`, `c:\ProjetoLucas\ProjetoLucas\View\frmMenuPrincipal.Designer.cs`
      Verify: Project compiles.

- [ ] 10. Rewrite frmSobre.cs and frmSobre.Designer.cs.
      **frmSobre.cs** (`namespace ProjetoLucas.View`, `partial class frmSobre : Form`):
      - Constructor calls `InitializeComponent()`.
      - One button click handler `btnFechar_Click` closes the form (`this.Close()`).
      **frmSobre.Designer.cs** (`namespace ProjetoLucas.View`, `partial class frmSobre`):
      - Remove `BackgroundImage` resource reference; use `BackColor = Color.FromArgb(30, 30, 45)`.
      - `ClientSize = new Size(500, 340)`, `FormBorderStyle = FixedDialog`, `MaximizeBox = false`, `StartPosition = CenterScreen`.
      - `Text = "Sobre — Hotel California"`
      - Central panel (`pnlInfo`): `BackColor = Color.FromArgb(45, 45, 65)`, positioned at (50, 40), size (400, 220).
      - Labels inside panel (all `ForeColor = Color.White`, `Font = Segoe UI 9pt`):
        - `lblNome`: `"Hotel California"`, 14pt bold, centered.
        - `lblDescricao`: `"Sistema de Gestão Hoteleira"`, 10pt italic, centered.
        - `lblVersao`: `"Versão 1.0"`.
        - `lblEquipe`: `"Equipe:"`.
        - `lblMembros`: `"Renan Carvalho dos Santos | João | Cayc"`.
        - `lblCopyright`: `"© 2026 RCJ Desenvolvimento. Todos os direitos reservados."`, small font.
      - Button `btnFechar`: `Text = "Fechar"`, dark-blue style (`BackColor = Color.FromArgb(0,120,215)`, `ForeColor = Color.White`, `FlatStyle = Flat`), wired to `btnFechar_Click`.
      Files: `c:\ProjetoLucas\ProjetoLucas\View\frmSobre.cs`, `c:\ProjetoLucas\ProjetoLucas\View\frmSobre.Designer.cs`
      Verify: Project compiles.

- [ ] 11. Rewrite frmCadastroEndereco.cs and frmCadastroEndereco.Designer.cs.
      **frmCadastroEndereco.cs** (`namespace ProjetoLucas.View`):
      - Field: `private int _idEnderecoAtual = 0;` (0 = new record mode).
      - `Form_Load`: calls `CarregarGrid()`.
      - `CarregarGrid()`: calls `new EnderecoController().GetAll()`, binds result to `dgvEnderecos.DataSource` as a `List<Endereco>` (or calls a `GetDataTable` variant; using the collection is fine — set `AutoGenerateColumns = true` and hide `IdEndereco` column after binding, or bind manually).
      - `BtnSalvar_Click`: validates required fields (Logradouro, Numero, Cidade, Estado non-empty); if `_idEnderecoAtual == 0` calls `Inserir`, else calls `Alterar`; shows `MessageBox` on success/error; calls `LimparCampos()` and `CarregarGrid()`.
      - `BtnNovo_Click`: calls `LimparCampos()` which sets `_idEnderecoAtual = 0`.
      - `BtnExcluir_Click`: if `_idEnderecoAtual == 0` shows warning; else confirms with `MessageBox.Show(..., MessageBoxButtons.YesNo)`, calls `Excluir(_idEnderecoAtual)`, calls `LimparCampos()` and `CarregarGrid()`.
      - `BtnBuscar_Click`: if search text empty calls `CarregarGrid()`; else `new EnderecoController().GetEnderecos(txtBusca.Text)` and binds to grid.
      - `DgvEnderecos_CellClick`: reads selected row, populates all text fields and `cboEstado`, sets `_idEnderecoAtual`.
      - `LimparCampos()`: clears all input controls and resets `_idEnderecoAtual = 0`.
      **frmCadastroEndereco.Designer.cs**:
      - Dark theme: `BackColor = Color.FromArgb(30, 30, 45)`.
      - `ClientSize = new Size(934, 561)`, `FormBorderStyle = FixedDialog`, `MaximizeBox = false`, `StartPosition = CenterScreen`, `Text = "Cadastro de Endereços"`.
      - GroupBox `grpDados` (`BackColor = Color.FromArgb(45,45,65)`, `ForeColor = Color.White`), top ~320px, contains:
        - Label + `txtLogradouro` (TextBox), Label + `txtNumero`, Label + `txtComplemento`, Label + `txtBairro`, Label + `txtCidade`, Label + `cboEstado` (ComboBox, Items = all 27 UF abbreviations in alphabetical order: AC, AL, AP, AM, BA, CE, DF, ES, GO, MA, MT, MS, MG, PA, PB, PR, PE, PI, RJ, RN, RS, RO, RR, SC, SP, SE, TO), Label + `txtCEP` (TextBox, MaxLength=9).
        - All input controls: `BackColor = Color.FromArgb(50,50,70)`, `ForeColor = Color.White`.
      - Panel `pnlBotoes`: three buttons side by side:
        - `btnSalvar`: `Text="Salvar"`, `BackColor=Color.FromArgb(0,120,215)`, `ForeColor=Color.White`, `FlatStyle=Flat`.
        - `btnNovo`: `Text="Novo"`, same blue style.
        - `btnExcluir`: `Text="Excluir"`, `BackColor=Color.FromArgb(196,43,28)`, `ForeColor=Color.White`, `FlatStyle=Flat`.
      - Search row: `txtBusca` (TextBox, dark style) + `btnBuscar` (blue button `Text="Buscar"`).
      - `dgvEnderecos` (DataGridView) in bottom half (~260px tall):
        - `BackgroundColor = Color.FromArgb(30,30,45)`, `EnableHeadersVisualStyles = false`.
        - `ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45,45,65)`, `ForeColor = Color.White`.
        - `RowsDefaultCellStyle.BackColor = Color.FromArgb(30,30,45)`, `ForeColor = Color.White`.
        - `AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(40,40,58)`.
        - `SelectionMode = FullRowSelect`, `ReadOnly = true`, `AllowUserToAddRows = false`.
      Files: `c:\ProjetoLucas\ProjetoLucas\View\frmCadastroEndereco.cs`, `c:\ProjetoLucas\ProjetoLucas\View\frmCadastroEndereco.Designer.cs`
      Verify: Project compiles.

- [ ] 12. Rewrite frmCadastroFilial.cs and frmCadastroFilial.Designer.cs.
      **frmCadastroFilial.cs** (`namespace ProjetoLucas.View`):
      - Fields: `private int _idFilialAtual = 0;`, `private FilialController _filialCtrl = new FilialController();`, `private EnderecoController _enderecoCtrl = new EnderecoController();`.
      - `Form_Load`: calls `CarregarComboEnderecos()` then `CarregarGrid()`.
      - `CarregarComboEnderecos()`: gets `_enderecoCtrl.GetAll()`, for each `Endereco` adds an item to `cboEndereco` with `DisplayMember` style — set `cboEndereco.DataSource`, `DisplayMember` to a computed string, `ValueMember = "IdEndereco"`. Easiest approach: build an anonymous-type list `new { Text = $"{e.Logradouro}, {e.Numero} – {e.Cidade}/{e.Estado}", Value = e.IdEndereco }` and bind with `DisplayMember = "Text"` / `ValueMember = "Value"`.
      - `CarregarGrid()`: `dgvFiliais.DataSource = _filialCtrl.GetAll()`.
      - `BtnSalvar_Click`: validate (RazaoSocial, CNPJ non-empty); build `Filial` from fields; `nudAvaliacao.Value` → `filial.Avaliacao`; `(int)cboEndereco.SelectedValue` → `filial.IdEndereco`; `chkAtivo.Checked` → `filial.Ativo`; call Inserir or Alterar; refresh.
      - `BtnNovo_Click`, `BtnExcluir_Click`, `BtnBuscar_Click`, `DgvFiliais_CellClick`, `LimparCampos()` — same pattern as `frmCadastroEndereco`.
      - `DgvFiliais_CellClick` also sets `cboEndereco.SelectedValue = filial.IdEndereco` and `nudAvaliacao.Value = filial.Avaliacao` and `chkAtivo.Checked = filial.Ativo`.
      **frmCadastroFilial.Designer.cs**:
      - Same dark theme, 950x600 fixed dialog.
      - `Text = "Cadastro de Filiais"`
      - GroupBox fields: `txtRazaoSocial`, `txtCNPJ` (MaxLength=18), `txtTelefone`, `txtEmail`, `nudAvaliacao` (NumericUpDown: Minimum=1, Maximum=5, DecimalPlaces=1, Increment=0.5M), `cboEndereco` (ComboBox), `chkAtivo` (CheckBox `Text="Ativo"`, `ForeColor=Color.White`).
      - Buttons and DataGridView styled the same as `frmCadastroEndereco`.
      Files: `c:\ProjetoLucas\ProjetoLucas\View\frmCadastroFilial.cs`, `c:\ProjetoLucas\ProjetoLucas\View\frmCadastroFilial.Designer.cs`
      Verify: Project compiles.

- [ ] 13. Rewrite frmCadastroHospede.cs and frmCadastroHospede.Designer.cs.
      **frmCadastroHospede.cs** (`namespace ProjetoLucas.View`):
      - Same CRUD pattern. Fields: `_idHospedeAtual = 0`, `_hospedeCtrl = new HospedeController()`.
      - `DgvHospedes_CellClick`: sets `dtpDataNascimento.Value = hospede.DataNascimento` and `chkAtivo.Checked = hospede.Ativo`.
      - Search calls `_hospedeCtrl.GetHospedes(txtBusca.Text)`.
      **frmCadastroHospede.Designer.cs**:
      - Dark theme, 950x600 fixed dialog. `Text = "Cadastro de Hóspedes"`
      - Fields: `txtNome`, `txtCPF` (MaxLength=14), `txtRG` (MaxLength=20), `txtTelefone`, `txtEmail`, `dtpDataNascimento` (DateTimePicker, `Format = Short`), `txtNacionalidade`, `chkAtivo`.
      - All controls dark-styled; DateTimePicker `CalendarMonthBackground = Color.FromArgb(50,50,70)`, `CalendarForeColor = Color.White` (note: `BackColor` on DateTimePicker has no effect on Win32 renderer; use `CalendarMonthBackground` for the dropdown).
      - Buttons and DataGridView as before.
      Files: `c:\ProjetoLucas\ProjetoLucas\View\frmCadastroHospede.cs`, `c:\ProjetoLucas\ProjetoLucas\View\frmCadastroHospede.Designer.cs`
      Verify: Project compiles.

- [ ] 14. Rewrite frmCadastroReserva.cs and frmCadastroReserva.Designer.cs.
      **frmCadastroReserva.cs** (`namespace ProjetoLucas.View`):
      - Fields: `_idReservaAtual = 0`, `_reservaCtrl = new ReservaController()`, `_hospedeCtrl = new HospedeController()`, `_filialCtrl = new FilialController()`.
      - `Form_Load`: `CarregarComboHospedes()`, `CarregarComboFiliais()`, `CarregarGrid()`.
      - `CarregarComboHospedes()`: bind `_hospedeCtrl.GetAll()` to `cboHospede` with DisplayMember = `"Nome – CPF"` composite. Approach: anonymous list `new { Text = $"{h.Nome} – {h.CPF}", Value = h.IdHospede }`.
      - `CarregarComboFiliais()`: bind `_filialCtrl.GetAll()` to `cboFilial`, `DisplayMember = "RazaoSocial"`, `ValueMember = "idFilial"` (note lower-case 'i' matching the model property name).
      - `CarregarGrid()`: use `_reservaCtrl.GetDataTableAll()` to get a DataTable with `NomeHospede` and `RazaoSocial` columns; bind to `dgvReservas.DataSource`. After binding, hide columns `IdHospede`, `IdFilial`, `Observacoes` for cleaner display.
      - `BtnSalvar_Click`: build `Reserva` from fields; `dtpCheckin.Value` → `DataCheckin`; `dtpCheckout.Value` → `DataCheckout`; `decimal.Parse(txtValorDiaria.Text)` → `ValorDiaria`; `cboStatus.SelectedItem.ToString()` → `Status`; call Inserir or Alterar.
      - `DgvReservas_CellClick`: reads `IdReserva` from the underlying DataTable (not from the grid display columns), calls `_reservaCtrl.GetById(id)`, populates all fields including setting `cboHospede.SelectedValue` and `cboFilial.SelectedValue`.
      - Search: `_reservaCtrl.GetReservas(txtBusca.Text)` returns a `ReservaCollection` — rebind grid. For the grid to show NomeHospede/RazaoSocial on search results too, call `GetDataTableAll()` filtered approach or accept the limitation (collection bind shows ids instead). **Decision**: keep search results bound via the collection (ids visible) since full-join search would require a new method; this is acceptable for the scope.
      **frmCadastroReserva.Designer.cs**:
      - Dark theme, 950x600. `Text = "Cadastro de Reservas"`.
      - Fields: `cboHospede`, `cboFilial`, `nudNumeroQuarto` (NumericUpDown, Minimum=1, Maximum=9999), `cboTipoQuarto` (Items: Simples, Duplo, Suíte, Master), `dtpCheckin` (DateTimePicker, Format=Short), `dtpCheckout` (DateTimePicker), `txtValorDiaria`, `txtObservacoes` (Multiline=true, Height~60), `cboStatus` (Items: Ativa, Concluída, Cancelada).
      - All controls dark-styled. `cboStatus` and `cboTipoQuarto`: `DropDownStyle = DropDownList`.
      - Buttons and DataGridView as before.
      Files: `c:\ProjetoLucas\ProjetoLucas\View\frmCadastroReserva.cs`, `c:\ProjetoLucas\ProjetoLucas\View\frmCadastroReserva.Designer.cs`
      Verify: Project compiles.

- [ ] 15. Write the SQL database script.
      Create `c:\ProjetoLucas\ProjetoLucas\script_banco.sql`:
      ```sql
      -- Criação do banco de dados (idempotente)
      IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'gs600hotelCalifornia')
          CREATE DATABASE gs600hotelCalifornia;
      GO
      USE gs600hotelCalifornia;
      GO

      -- Drop em ordem de FK (filhos antes dos pais)
      IF OBJECT_ID('tblReserva',  'U') IS NOT NULL DROP TABLE tblReserva;
      IF OBJECT_ID('tblHotel',    'U') IS NOT NULL DROP TABLE tblHotel;
      IF OBJECT_ID('tblHospede',  'U') IS NOT NULL DROP TABLE tblHospede;
      IF OBJECT_ID('tblEndereco', 'U') IS NOT NULL DROP TABLE tblEndereco;
      GO

      CREATE TABLE tblEndereco (
          IdEndereco  INT          IDENTITY(1,1) PRIMARY KEY,
          Logradouro  VARCHAR(150) NOT NULL,
          Numero      VARCHAR(10)  NOT NULL,
          Complemento VARCHAR(50)  NULL,
          Bairro      VARCHAR(80)  NOT NULL,
          Cidade      VARCHAR(80)  NOT NULL,
          Estado      CHAR(2)      NOT NULL,
          CEP         CHAR(9)      NOT NULL
      );

      CREATE TABLE tblHospede (
          IdHospede       INT          IDENTITY(1,1) PRIMARY KEY,
          Nome            VARCHAR(150) NOT NULL,
          CPF             CHAR(14)     NOT NULL,
          RG              VARCHAR(20)  NULL,
          Telefone        VARCHAR(20)  NULL,
          Email           VARCHAR(100) NULL,
          DataNascimento  DATE         NOT NULL,
          Nacionalidade   VARCHAR(60)  NOT NULL,
          Ativo           BIT          NOT NULL DEFAULT 1
      );

      CREATE TABLE tblHotel (
          IdFilial    INT          IDENTITY(1,1) PRIMARY KEY,
          RazaoSocial VARCHAR(150) NOT NULL,
          CNPJ        CHAR(18)     NOT NULL,
          Telefone    VARCHAR(20)  NULL,
          Email       VARCHAR(100) NULL,
          Avaliacao   DECIMAL(3,1) NULL,
          IdEndereco  INT          NULL REFERENCES tblEndereco(IdEndereco),
          Ativo       BIT          NOT NULL DEFAULT 1
      );

      CREATE TABLE tblReserva (
          IdReserva    INT          IDENTITY(1,1) PRIMARY KEY,
          IdHospede    INT          NOT NULL REFERENCES tblHospede(IdHospede),
          IdFilial     INT          NOT NULL REFERENCES tblHotel(IdFilial),
          NumeroQuarto INT          NOT NULL,
          TipoQuarto   VARCHAR(50)  NOT NULL,
          DataCheckin  DATE         NOT NULL,
          DataCheckout DATE         NOT NULL,
          ValorDiaria  DECIMAL(10,2)NOT NULL,
          Observacoes  VARCHAR(300) NULL,
          Status       VARCHAR(20)  NOT NULL DEFAULT 'Ativa'
      );
      GO

      -- Dados de exemplo (mínimo 3 linhas por tabela)
      INSERT INTO tblEndereco (Logradouro, Numero, Complemento, Bairro, Cidade, Estado, CEP) VALUES
          ('Avenida Paulista',        '1578', 'Sala 3',  'Bela Vista',   'São Paulo',       'SP', '01310-100'),
          ('Rua das Flores',          '220',  NULL,      'Centro',       'Curitiba',        'PR', '80010-020'),
          ('Travessa do Comércio',    '45',   'Bloco B', 'Comércio',     'Salvador',        'BA', '40015-130');

      INSERT INTO tblHospede (Nome, CPF, RG, Telefone, Email, DataNascimento, Nacionalidade, Ativo) VALUES
          ('Carlos Eduardo Lima',    '123.456.789-00', '12.345.678-9', '(11) 91234-5678', 'carlos@email.com', '1985-03-15', 'Brasileira', 1),
          ('Ana Paula Ferreira',     '987.654.321-00', '98.765.432-1', '(41) 98765-4321', 'ana@email.com',    '1992-07-22', 'Brasileira', 1),
          ('John Robert Smith',      '000.111.222-33', NULL,            '(21) 99000-1111', 'john@email.com',   '1978-11-05', 'Americana',  1);

      INSERT INTO tblHotel (RazaoSocial, CNPJ, Telefone, Email, Avaliacao, IdEndereco, Ativo) VALUES
          ('Hotel California São Paulo Ltda.', '12.345.678/0001-99', '(11) 3333-4444', 'sp@hotelcalifornia.com',  4.5, 1, 1),
          ('Hotel California Curitiba Ltda.',  '98.765.432/0001-11', '(41) 2222-3333', 'cwb@hotelcalifornia.com', 4.0, 2, 1),
          ('Hotel California Salvador Ltda.',  '55.444.333/0001-22', '(71) 4444-5555', 'ssa@hotelcalifornia.com', 3.5, 3, 1);

      INSERT INTO tblReserva (IdHospede, IdFilial, NumeroQuarto, TipoQuarto, DataCheckin, DataCheckout, ValorDiaria, Observacoes, Status) VALUES
          (1, 1, 101, 'Suíte',   '2026-02-10', '2026-02-14', 350.00, 'Cama king size',     'Ativa'),
          (2, 2, 205, 'Duplo',   '2026-02-15', '2026-02-17', 180.00, NULL,                 'Concluída'),
          (3, 3, 310, 'Simples', '2026-03-01', '2026-03-03', 120.00, 'Vista para o mar',   'Ativa');
      GO

      SELECT * FROM tblEndereco;
      SELECT * FROM tblHospede;
      SELECT * FROM tblHotel;
      SELECT * FROM tblReserva;
      GO
      ```
      Files: `c:\ProjetoLucas\ProjetoLucas\script_banco.sql`
      Verify: Run the script in SSMS or `sqlcmd` against a local SQL Express instance; all four SELECT statements return 3 rows each.

- [ ] 16. Final build verification.
      After all files are written, run a full build to confirm zero errors.
      `msbuild c:\ProjetoLucas\ProjetoLucas\ProjetoLucas.csproj /p:Configuration=Debug /t:Rebuild`
      Expected: `Build succeeded.` with 0 Error(s).
      If any compile error appears, fix it before marking this step done.

---

## File Checklist

| # | File | Action |
|---|------|--------|
| 1 | `Service\DataBaseService.cs` | Rewrite — fix connection leak with `using` blocks |
| 2 | `Models\Filial.cs` | Rewrite — `Ativo int` → `bool`; remove unused usings |
| 3 | `Models\Hospede.cs` | **NEW** |
| 4 | `Models\Endereco.cs` | **NEW** |
| 5 | `Models\Reserva.cs` | **NEW** |
| 6 | `Controller\FilialController.cs` | Rewrite — fix all 12 bugs listed above |
| 7 | `Controller\HospedeController.cs` | **NEW** |
| 8 | `Controller\EnderecoController.cs` | **NEW** |
| 9 | `Controller\ReservaController.cs` | **NEW** — includes `GetDataTableAll()` |
| 10 | `View\frmMenuPrincipal.cs` | Rewrite — keep namespace `ProjetoLucas`, improve visuals, remove resource references |
| 11 | `View\frmMenuPrincipal.Designer.cs` | Rewrite — dark theme, add title/subtitle labels, remove BackgroundImage resource |
| 12 | `View\frmSobre.cs` | Rewrite — add `btnFechar_Click` |
| 13 | `View\frmSobre.Designer.cs` | Rewrite — dark theme, correct team names, remove BackgroundImage resource |
| 14 | `View\frmCadastroEndereco.cs` | Rewrite — full CRUD logic |
| 15 | `View\frmCadastroEndereco.Designer.cs` | Rewrite — dark theme layout |
| 16 | `View\frmCadastroFilial.cs` | Rewrite — full CRUD logic |
| 17 | `View\frmCadastroFilial.Designer.cs` | Rewrite — dark theme layout |
| 18 | `View\frmCadastroHospede.cs` | Rewrite — full CRUD logic |
| 19 | `View\frmCadastroHospede.Designer.cs` | Rewrite — dark theme layout |
| 20 | `View\frmCadastroReserva.cs` | Rewrite — full CRUD logic |
| 21 | `View\frmCadastroReserva.Designer.cs` | Rewrite — dark theme layout |
| 22 | `ProjetoLucas.csproj` | Add 6 new `<Compile>` entries |
| 23 | `script_banco.sql` | **NEW** — idempotent schema + seed data |
| 24 | `Program.cs` | **No change** |

---

## Theme Constants (reference for all Designer files)

```
BackColor (Form/panel outer)    : Color.FromArgb(30, 30, 45)
BackColor (GroupBox/inner panel): Color.FromArgb(45, 45, 65)
BackColor (inputs)              : Color.FromArgb(50, 50, 70)
BackColor (status bar)          : Color.FromArgb(20, 20, 35)
ForeColor (all text)            : Color.White
Button normal                   : BackColor=Color.FromArgb(0, 120, 215), ForeColor=White, FlatStyle=Flat
Button Excluir                  : BackColor=Color.FromArgb(196, 43, 28), ForeColor=White, FlatStyle=Flat
DGV header bg                   : Color.FromArgb(45, 45, 65)
DGV row bg                      : Color.FromArgb(30, 30, 45)
DGV alt row bg                  : Color.FromArgb(40, 40, 58)
Font (default)                  : Segoe UI, 9pt
Form size                       : ClientSize ≈ 934×561 (outer 950×600)
FormBorderStyle                 : FixedDialog
MaximizeBox                     : false
StartPosition                   : CenterScreen
```
