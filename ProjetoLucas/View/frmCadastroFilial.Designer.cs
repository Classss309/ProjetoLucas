namespace ProjetoLucas.View
{
    partial class frmCadastroFilial
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
            this.lblRazaoSocial = new System.Windows.Forms.Label();
            this.txtRazaoSocial = new System.Windows.Forms.TextBox();
            this.lblCNPJ = new System.Windows.Forms.Label();
            this.txtCNPJ = new System.Windows.Forms.TextBox();
            this.lblTelefone = new System.Windows.Forms.Label();
            this.txtTelefone = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblAvaliacao = new System.Windows.Forms.Label();
            this.nudAvaliacao = new System.Windows.Forms.NumericUpDown();
            this.lblEndereco = new System.Windows.Forms.Label();
            this.cboEndereco = new System.Windows.Forms.ComboBox();
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
            this.dgvFiliais = new System.Windows.Forms.DataGridView();
            this.grpDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAvaliacao)).BeginInit();
            this.pnlBotoes.SuspendLayout();
            this.pnlBusca.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiliais)).BeginInit();
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
            this.grpDados.Text = "Dados da Filial";
            this.grpDados.Controls.Add(this.lblRazaoSocial);
            this.grpDados.Controls.Add(this.txtRazaoSocial);
            this.grpDados.Controls.Add(this.lblCNPJ);
            this.grpDados.Controls.Add(this.txtCNPJ);
            this.grpDados.Controls.Add(this.lblTelefone);
            this.grpDados.Controls.Add(this.txtTelefone);
            this.grpDados.Controls.Add(this.lblEmail);
            this.grpDados.Controls.Add(this.txtEmail);
            this.grpDados.Controls.Add(this.lblAvaliacao);
            this.grpDados.Controls.Add(this.nudAvaliacao);
            this.grpDados.Controls.Add(this.lblEndereco);
            this.grpDados.Controls.Add(this.cboEndereco);
            this.grpDados.Controls.Add(this.lblAtivo);
            this.grpDados.Controls.Add(this.chkAtivo);
            // 
            // lblRazaoSocial
            // 
            this.lblRazaoSocial.AutoSize = true;
            this.lblRazaoSocial.ForeColor = System.Drawing.Color.White;
            this.lblRazaoSocial.Location = new System.Drawing.Point(10, 30);
            this.lblRazaoSocial.Name = "lblRazaoSocial";
            this.lblRazaoSocial.Size = new System.Drawing.Size(80, 15);
            this.lblRazaoSocial.TabIndex = 0;
            this.lblRazaoSocial.Text = "Razão Social:";
            // 
            // txtRazaoSocial
            // 
            this.txtRazaoSocial.BackColor = System.Drawing.Color.FromArgb(50, 50, 70);
            this.txtRazaoSocial.ForeColor = System.Drawing.Color.White;
            this.txtRazaoSocial.Location = new System.Drawing.Point(100, 27);
            this.txtRazaoSocial.Name = "txtRazaoSocial";
            this.txtRazaoSocial.Size = new System.Drawing.Size(280, 23);
            this.txtRazaoSocial.TabIndex = 1;
            // 
            // lblCNPJ
            // 
            this.lblCNPJ.AutoSize = true;
            this.lblCNPJ.ForeColor = System.Drawing.Color.White;
            this.lblCNPJ.Location = new System.Drawing.Point(400, 30);
            this.lblCNPJ.Name = "lblCNPJ";
            this.lblCNPJ.Size = new System.Drawing.Size(35, 15);
            this.lblCNPJ.TabIndex = 2;
            this.lblCNPJ.Text = "CNPJ:";
            // 
            // txtCNPJ
            // 
            this.txtCNPJ.BackColor = System.Drawing.Color.FromArgb(50, 50, 70);
            this.txtCNPJ.ForeColor = System.Drawing.Color.White;
            this.txtCNPJ.Location = new System.Drawing.Point(450, 27);
            this.txtCNPJ.MaxLength = 18;
            this.txtCNPJ.Name = "txtCNPJ";
            this.txtCNPJ.Size = new System.Drawing.Size(160, 23);
            this.txtCNPJ.TabIndex = 3;
            // 
            // lblTelefone
            // 
            this.lblTelefone.AutoSize = true;
            this.lblTelefone.ForeColor = System.Drawing.Color.White;
            this.lblTelefone.Location = new System.Drawing.Point(630, 30);
            this.lblTelefone.Name = "lblTelefone";
            this.lblTelefone.Size = new System.Drawing.Size(55, 15);
            this.lblTelefone.TabIndex = 4;
            this.lblTelefone.Text = "Telefone:";
            // 
            // txtTelefone
            // 
            this.txtTelefone.BackColor = System.Drawing.Color.FromArgb(50, 50, 70);
            this.txtTelefone.ForeColor = System.Drawing.Color.White;
            this.txtTelefone.Location = new System.Drawing.Point(695, 27);
            this.txtTelefone.Name = "txtTelefone";
            this.txtTelefone.Size = new System.Drawing.Size(200, 23);
            this.txtTelefone.TabIndex = 5;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.ForeColor = System.Drawing.Color.White;
            this.lblEmail.Location = new System.Drawing.Point(10, 75);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(38, 15);
            this.lblEmail.TabIndex = 6;
            this.lblEmail.Text = "E-mail:";
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.FromArgb(50, 50, 70);
            this.txtEmail.ForeColor = System.Drawing.Color.White;
            this.txtEmail.Location = new System.Drawing.Point(100, 72);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(250, 23);
            this.txtEmail.TabIndex = 7;
            // 
            // lblAvaliacao
            // 
            this.lblAvaliacao.AutoSize = true;
            this.lblAvaliacao.ForeColor = System.Drawing.Color.White;
            this.lblAvaliacao.Location = new System.Drawing.Point(370, 75);
            this.lblAvaliacao.Name = "lblAvaliacao";
            this.lblAvaliacao.Size = new System.Drawing.Size(65, 15);
            this.lblAvaliacao.TabIndex = 8;
            this.lblAvaliacao.Text = "Avaliação:";
            // 
            // nudAvaliacao
            // 
            this.nudAvaliacao.BackColor = System.Drawing.Color.FromArgb(50, 50, 70);
            this.nudAvaliacao.ForeColor = System.Drawing.Color.White;
            this.nudAvaliacao.DecimalPlaces = 1;
            this.nudAvaliacao.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            this.nudAvaliacao.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            this.nudAvaliacao.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudAvaliacao.Location = new System.Drawing.Point(445, 72);
            this.nudAvaliacao.Name = "nudAvaliacao";
            this.nudAvaliacao.Size = new System.Drawing.Size(80, 23);
            this.nudAvaliacao.TabIndex = 9;
            this.nudAvaliacao.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblEndereco
            // 
            this.lblEndereco.AutoSize = true;
            this.lblEndereco.ForeColor = System.Drawing.Color.White;
            this.lblEndereco.Location = new System.Drawing.Point(10, 120);
            this.lblEndereco.Name = "lblEndereco";
            this.lblEndereco.Size = new System.Drawing.Size(60, 15);
            this.lblEndereco.TabIndex = 10;
            this.lblEndereco.Text = "Endereço:";
            // 
            // cboEndereco
            // 
            this.cboEndereco.BackColor = System.Drawing.Color.FromArgb(50, 50, 70);
            this.cboEndereco.ForeColor = System.Drawing.Color.White;
            this.cboEndereco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEndereco.Location = new System.Drawing.Point(100, 117);
            this.cboEndereco.Name = "cboEndereco";
            this.cboEndereco.Size = new System.Drawing.Size(600, 23);
            this.cboEndereco.TabIndex = 11;
            // 
            // lblAtivo
            // 
            this.lblAtivo.AutoSize = true;
            this.lblAtivo.ForeColor = System.Drawing.Color.White;
            this.lblAtivo.Location = new System.Drawing.Point(720, 75);
            this.lblAtivo.Name = "lblAtivo";
            this.lblAtivo.Size = new System.Drawing.Size(34, 15);
            this.lblAtivo.TabIndex = 12;
            this.lblAtivo.Text = "Ativo:";
            // 
            // chkAtivo
            // 
            this.chkAtivo.BackColor = System.Drawing.Color.Transparent;
            this.chkAtivo.Checked = true;
            this.chkAtivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAtivo.ForeColor = System.Drawing.Color.White;
            this.chkAtivo.Location = new System.Drawing.Point(764, 72);
            this.chkAtivo.Name = "chkAtivo";
            this.chkAtivo.Size = new System.Drawing.Size(50, 23);
            this.chkAtivo.TabIndex = 13;
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
            this.lblBusca.Size = new System.Drawing.Size(38, 15);
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
            // dgvFiliais
            // 
            this.dgvFiliais.AllowUserToAddRows = false;
            this.dgvFiliais.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFiliais.BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 45);
            this.dgvFiliais.EnableHeadersVisualStyles = false;
            this.dgvFiliais.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(45, 45, 65);
            this.dgvFiliais.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvFiliais.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvFiliais.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(30, 30, 45);
            this.dgvFiliais.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvFiliais.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(40, 40, 58);
            this.dgvFiliais.AlternatingRowsDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvFiliais.Location = new System.Drawing.Point(10, 300);
            this.dgvFiliais.Name = "dgvFiliais";
            this.dgvFiliais.ReadOnly = true;
            this.dgvFiliais.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFiliais.Size = new System.Drawing.Size(914, 250);
            this.dgvFiliais.TabIndex = 3;
            this.dgvFiliais.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFiliais_CellClick);
            // 
            // frmCadastroFilial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(30, 30, 45);
            this.ClientSize = new System.Drawing.Size(934, 561);
            this.Controls.Add(this.grpDados);
            this.Controls.Add(this.pnlBotoes);
            this.Controls.Add(this.pnlBusca);
            this.Controls.Add(this.dgvFiliais);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmCadastroFilial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Filiais";
            this.Load += new System.EventHandler(this.frmCadastroFilial_Load);
            this.grpDados.ResumeLayout(false);
            this.grpDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAvaliacao)).EndInit();
            this.pnlBotoes.ResumeLayout(false);
            this.pnlBusca.ResumeLayout(false);
            this.pnlBusca.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiliais)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox grpDados;
        private System.Windows.Forms.Label lblRazaoSocial;
        private System.Windows.Forms.TextBox txtRazaoSocial;
        private System.Windows.Forms.Label lblCNPJ;
        private System.Windows.Forms.TextBox txtCNPJ;
        private System.Windows.Forms.Label lblTelefone;
        private System.Windows.Forms.TextBox txtTelefone;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblAvaliacao;
        private System.Windows.Forms.NumericUpDown nudAvaliacao;
        private System.Windows.Forms.Label lblEndereco;
        private System.Windows.Forms.ComboBox cboEndereco;
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
        private System.Windows.Forms.DataGridView dgvFiliais;
    }
}
