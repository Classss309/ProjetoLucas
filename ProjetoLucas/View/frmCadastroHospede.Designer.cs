namespace ProjetoLucas.View
{
    partial class frmCadastroHospede
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.grpDados = new System.Windows.Forms.GroupBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblCPF = new System.Windows.Forms.Label();
            this.txtCPF = new System.Windows.Forms.TextBox();
            this.lblRG = new System.Windows.Forms.Label();
            this.txtRG = new System.Windows.Forms.TextBox();
            this.lblTelefone = new System.Windows.Forms.Label();
            this.txtTelefone = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblDataNascimento = new System.Windows.Forms.Label();
            this.dtpDataNascimento = new System.Windows.Forms.DateTimePicker();
            this.lblNacionalidade = new System.Windows.Forms.Label();
            this.txtNacionalidade = new System.Windows.Forms.TextBox();
            this.lblAtivo = new System.Windows.Forms.Label();
            this.chkAtivo = new System.Windows.Forms.CheckBox();
            this.pnlBotoes = new System.Windows.Forms.Panel();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.pnlBusca = new System.Windows.Forms.Panel();
            this.lblBusca = new System.Windows.Forms.Label();
            this.txtBusca = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgvHospedes = new System.Windows.Forms.DataGridView();
            this.grpDados.SuspendLayout();
            this.pnlBotoes.SuspendLayout();
            this.pnlBusca.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHospedes)).BeginInit();
            this.SuspendLayout();
            // 
            // grpDados
            // 
            this.grpDados.BackColor = System.Drawing.Color.FromArgb(45, 45, 65);
            this.grpDados.ForeColor = System.Drawing.Color.White;
            this.grpDados.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.grpDados.Location = new System.Drawing.Point(10, 10);
            this.grpDados.Name = "grpDados";
            this.grpDados.Size = new System.Drawing.Size(914, 175);
            this.grpDados.TabIndex = 0;
            this.grpDados.TabStop = false;
            this.grpDados.Text = "Dados do Hóspede";
            this.grpDados.Controls.Add(this.lblNome);
            this.grpDados.Controls.Add(this.txtNome);
            this.grpDados.Controls.Add(this.lblCPF);
            this.grpDados.Controls.Add(this.txtCPF);
            this.grpDados.Controls.Add(this.lblRG);
            this.grpDados.Controls.Add(this.txtRG);
            this.grpDados.Controls.Add(this.lblTelefone);
            this.grpDados.Controls.Add(this.txtTelefone);
            this.grpDados.Controls.Add(this.lblEmail);
            this.grpDados.Controls.Add(this.txtEmail);
            this.grpDados.Controls.Add(this.lblDataNascimento);
            this.grpDados.Controls.Add(this.dtpDataNascimento);
            this.grpDados.Controls.Add(this.lblNacionalidade);
            this.grpDados.Controls.Add(this.txtNacionalidade);
            this.grpDados.Controls.Add(this.lblAtivo);
            this.grpDados.Controls.Add(this.chkAtivo);
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.ForeColor = System.Drawing.Color.White;
            this.lblNome.Location = new System.Drawing.Point(10, 30);
            this.lblNome.Name = "lblNome";
            this.lblNome.TabIndex = 0;
            this.lblNome.Text = "Nome:";
            // 
            // txtNome
            // 
            this.txtNome.BackColor = System.Drawing.Color.FromArgb(50, 50, 70);
            this.txtNome.ForeColor = System.Drawing.Color.White;
            this.txtNome.Location = new System.Drawing.Point(100, 27);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(280, 23);
            this.txtNome.TabIndex = 1;
            // 
            // lblCPF
            // 
            this.lblCPF.AutoSize = true;
            this.lblCPF.ForeColor = System.Drawing.Color.White;
            this.lblCPF.Location = new System.Drawing.Point(400, 30);
            this.lblCPF.Name = "lblCPF";
            this.lblCPF.TabIndex = 2;
            this.lblCPF.Text = "CPF:";
            // 
            // txtCPF
            // 
            this.txtCPF.BackColor = System.Drawing.Color.FromArgb(50, 50, 70);
            this.txtCPF.ForeColor = System.Drawing.Color.White;
            this.txtCPF.Location = new System.Drawing.Point(450, 27);
            this.txtCPF.MaxLength = 14;
            this.txtCPF.Name = "txtCPF";
            this.txtCPF.Size = new System.Drawing.Size(130, 23);
            this.txtCPF.TabIndex = 3;
            // 
            // lblRG
            // 
            this.lblRG.AutoSize = true;
            this.lblRG.ForeColor = System.Drawing.Color.White;
            this.lblRG.Location = new System.Drawing.Point(600, 30);
            this.lblRG.Name = "lblRG";
            this.lblRG.TabIndex = 4;
            this.lblRG.Text = "RG:";
            // 
            // txtRG
            // 
            this.txtRG.BackColor = System.Drawing.Color.FromArgb(50, 50, 70);
            this.txtRG.ForeColor = System.Drawing.Color.White;
            this.txtRG.Location = new System.Drawing.Point(640, 27);
            this.txtRG.MaxLength = 20;
            this.txtRG.Name = "txtRG";
            this.txtRG.Size = new System.Drawing.Size(250, 23);
            this.txtRG.TabIndex = 5;
            // 
            // lblTelefone
            // 
            this.lblTelefone.AutoSize = true;
            this.lblTelefone.ForeColor = System.Drawing.Color.White;
            this.lblTelefone.Location = new System.Drawing.Point(10, 75);
            this.lblTelefone.Name = "lblTelefone";
            this.lblTelefone.TabIndex = 6;
            this.lblTelefone.Text = "Telefone:";
            // 
            // txtTelefone
            // 
            this.txtTelefone.BackColor = System.Drawing.Color.FromArgb(50, 50, 70);
            this.txtTelefone.ForeColor = System.Drawing.Color.White;
            this.txtTelefone.Location = new System.Drawing.Point(100, 72);
            this.txtTelefone.Name = "txtTelefone";
            this.txtTelefone.Size = new System.Drawing.Size(150, 23);
            this.txtTelefone.TabIndex = 7;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.ForeColor = System.Drawing.Color.White;
            this.lblEmail.Location = new System.Drawing.Point(270, 75);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.TabIndex = 8;
            this.lblEmail.Text = "E-mail:";
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.FromArgb(50, 50, 70);
            this.txtEmail.ForeColor = System.Drawing.Color.White;
            this.txtEmail.Location = new System.Drawing.Point(320, 72);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(280, 23);
            this.txtEmail.TabIndex = 9;
            // 
            // lblDataNascimento
            // 
            this.lblDataNascimento.AutoSize = true;
            this.lblDataNascimento.ForeColor = System.Drawing.Color.White;
            this.lblDataNascimento.Location = new System.Drawing.Point(620, 75);
            this.lblDataNascimento.Name = "lblDataNascimento";
            this.lblDataNascimento.TabIndex = 10;
            this.lblDataNascimento.Text = "Data Nasc.:";
            // 
            // dtpDataNascimento
            // 
            this.dtpDataNascimento.CalendarForeColor = System.Drawing.Color.White;
            this.dtpDataNascimento.CalendarMonthBackground = System.Drawing.Color.FromArgb(50, 50, 70);
            this.dtpDataNascimento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataNascimento.Location = new System.Drawing.Point(710, 72);
            this.dtpDataNascimento.Name = "dtpDataNascimento";
            this.dtpDataNascimento.Size = new System.Drawing.Size(180, 23);
            this.dtpDataNascimento.TabIndex = 11;
            // 
            // lblNacionalidade
            // 
            this.lblNacionalidade.AutoSize = true;
            this.lblNacionalidade.ForeColor = System.Drawing.Color.White;
            this.lblNacionalidade.Location = new System.Drawing.Point(10, 120);
            this.lblNacionalidade.Name = "lblNacionalidade";
            this.lblNacionalidade.TabIndex = 12;
            this.lblNacionalidade.Text = "Nacionalidade:";
            // 
            // txtNacionalidade
            // 
            this.txtNacionalidade.BackColor = System.Drawing.Color.FromArgb(50, 50, 70);
            this.txtNacionalidade.ForeColor = System.Drawing.Color.White;
            this.txtNacionalidade.Location = new System.Drawing.Point(110, 117);
            this.txtNacionalidade.Name = "txtNacionalidade";
            this.txtNacionalidade.Size = new System.Drawing.Size(200, 23);
            this.txtNacionalidade.TabIndex = 13;
            // 
            // lblAtivo
            // 
            this.lblAtivo.AutoSize = true;
            this.lblAtivo.ForeColor = System.Drawing.Color.White;
            this.lblAtivo.Location = new System.Drawing.Point(340, 120);
            this.lblAtivo.Name = "lblAtivo";
            this.lblAtivo.TabIndex = 14;
            this.lblAtivo.Text = "Ativo:";
            // 
            // chkAtivo
            // 
            this.chkAtivo.BackColor = System.Drawing.Color.Transparent;
            this.chkAtivo.Checked = true;
            this.chkAtivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAtivo.ForeColor = System.Drawing.Color.White;
            this.chkAtivo.Location = new System.Drawing.Point(384, 117);
            this.chkAtivo.Name = "chkAtivo";
            this.chkAtivo.Size = new System.Drawing.Size(50, 23);
            this.chkAtivo.TabIndex = 15;
            this.chkAtivo.Text = "Sim";
            // 
            // pnlBotoes
            // 
            this.pnlBotoes.BackColor = System.Drawing.Color.FromArgb(45, 45, 65);
            this.pnlBotoes.Controls.Add(this.btnSalvar);
            this.pnlBotoes.Controls.Add(this.btnNovo);
            this.pnlBotoes.Controls.Add(this.btnExcluir);
            this.pnlBotoes.Location = new System.Drawing.Point(10, 195);
            this.pnlBotoes.Name = "pnlBotoes";
            this.pnlBotoes.Size = new System.Drawing.Size(914, 45);
            this.pnlBotoes.TabIndex = 1;
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.ForeColor = System.Drawing.Color.White;
            this.btnSalvar.Location = new System.Drawing.Point(10, 8);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(120, 30);
            this.btnSalvar.TabIndex = 0;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.btnNovo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovo.ForeColor = System.Drawing.Color.White;
            this.btnNovo.Location = new System.Drawing.Point(140, 8);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(120, 30);
            this.btnNovo.TabIndex = 1;
            this.btnNovo.Text = "Novo";
            this.btnNovo.UseVisualStyleBackColor = false;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.BackColor = System.Drawing.Color.FromArgb(196, 43, 28);
            this.btnExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcluir.ForeColor = System.Drawing.Color.White;
            this.btnExcluir.Location = new System.Drawing.Point(270, 8);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(120, 30);
            this.btnExcluir.TabIndex = 2;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = false;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // pnlBusca
            // 
            this.pnlBusca.BackColor = System.Drawing.Color.FromArgb(45, 45, 65);
            this.pnlBusca.Controls.Add(this.lblBusca);
            this.pnlBusca.Controls.Add(this.txtBusca);
            this.pnlBusca.Controls.Add(this.btnBuscar);
            this.pnlBusca.Location = new System.Drawing.Point(10, 250);
            this.pnlBusca.Name = "pnlBusca";
            this.pnlBusca.Size = new System.Drawing.Size(914, 40);
            this.pnlBusca.TabIndex = 2;
            // 
            // lblBusca
            // 
            this.lblBusca.AutoSize = true;
            this.lblBusca.ForeColor = System.Drawing.Color.White;
            this.lblBusca.Location = new System.Drawing.Point(10, 12);
            this.lblBusca.Name = "lblBusca";
            this.lblBusca.TabIndex = 0;
            this.lblBusca.Text = "Busca:";
            // 
            // txtBusca
            // 
            this.txtBusca.BackColor = System.Drawing.Color.FromArgb(50, 50, 70);
            this.txtBusca.ForeColor = System.Drawing.Color.White;
            this.txtBusca.Location = new System.Drawing.Point(60, 9);
            this.txtBusca.Name = "txtBusca";
            this.txtBusca.Size = new System.Drawing.Size(720, 23);
            this.txtBusca.TabIndex = 1;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(790, 8);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(110, 25);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dgvHospedes
            // 
            this.dgvHospedes.AllowUserToAddRows = false;
            this.dgvHospedes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHospedes.BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 45);
            this.dgvHospedes.EnableHeadersVisualStyles = false;
            this.dgvHospedes.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(45, 45, 65);
            this.dgvHospedes.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvHospedes.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvHospedes.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(30, 30, 45);
            this.dgvHospedes.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvHospedes.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(40, 40, 58);
            this.dgvHospedes.AlternatingRowsDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvHospedes.Location = new System.Drawing.Point(10, 300);
            this.dgvHospedes.Name = "dgvHospedes";
            this.dgvHospedes.ReadOnly = true;
            this.dgvHospedes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHospedes.Size = new System.Drawing.Size(914, 250);
            this.dgvHospedes.TabIndex = 3;
            this.dgvHospedes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHospedes_CellClick);
            // 
            // frmCadastroHospede
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(30, 30, 45);
            this.ClientSize = new System.Drawing.Size(934, 561);
            this.Controls.Add(this.grpDados);
            this.Controls.Add(this.pnlBotoes);
            this.Controls.Add(this.pnlBusca);
            this.Controls.Add(this.dgvHospedes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmCadastroHospede";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Hóspedes";
            this.Load += new System.EventHandler(this.frmCadastroHospede_Load);
            this.grpDados.ResumeLayout(false);
            this.grpDados.PerformLayout();
            this.pnlBotoes.ResumeLayout(false);
            this.pnlBusca.ResumeLayout(false);
            this.pnlBusca.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHospedes)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox grpDados;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblCPF;
        private System.Windows.Forms.TextBox txtCPF;
        private System.Windows.Forms.Label lblRG;
        private System.Windows.Forms.TextBox txtRG;
        private System.Windows.Forms.Label lblTelefone;
        private System.Windows.Forms.TextBox txtTelefone;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblDataNascimento;
        private System.Windows.Forms.DateTimePicker dtpDataNascimento;
        private System.Windows.Forms.Label lblNacionalidade;
        private System.Windows.Forms.TextBox txtNacionalidade;
        private System.Windows.Forms.Label lblAtivo;
        private System.Windows.Forms.CheckBox chkAtivo;
        private System.Windows.Forms.Panel pnlBotoes;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Panel pnlBusca;
        private System.Windows.Forms.Label lblBusca;
        private System.Windows.Forms.TextBox txtBusca;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dgvHospedes;
    }
}
