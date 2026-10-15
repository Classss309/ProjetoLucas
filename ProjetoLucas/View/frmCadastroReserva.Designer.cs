namespace ProjetoLucas.View
{
    partial class frmCadastroReserva
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
            this.lblHospede = new System.Windows.Forms.Label();
            this.cboHospede = new System.Windows.Forms.ComboBox();
            this.lblFilial = new System.Windows.Forms.Label();
            this.cboFilial = new System.Windows.Forms.ComboBox();
            this.lblNumeroQuarto = new System.Windows.Forms.Label();
            this.nudNumeroQuarto = new System.Windows.Forms.NumericUpDown();
            this.lblTipoQuarto = new System.Windows.Forms.Label();
            this.cboTipoQuarto = new System.Windows.Forms.ComboBox();
            this.lblCheckin = new System.Windows.Forms.Label();
            this.dtpCheckin = new System.Windows.Forms.DateTimePicker();
            this.lblCheckout = new System.Windows.Forms.Label();
            this.dtpCheckout = new System.Windows.Forms.DateTimePicker();
            this.lblValorDiaria = new System.Windows.Forms.Label();
            this.txtValorDiaria = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.lblObservacoes = new System.Windows.Forms.Label();
            this.txtObservacoes = new System.Windows.Forms.TextBox();
            this.pnlBotoes = new System.Windows.Forms.Panel();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.pnlBusca = new System.Windows.Forms.Panel();
            this.lblBusca = new System.Windows.Forms.Label();
            this.txtBusca = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgvReservas = new System.Windows.Forms.DataGridView();
            this.grpDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumeroQuarto)).BeginInit();
            this.pnlBotoes.SuspendLayout();
            this.pnlBusca.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservas)).BeginInit();
            this.SuspendLayout();
            // 
            // grpDados
            // 
            this.grpDados.BackColor = System.Drawing.Color.FromArgb(45, 45, 65);
            this.grpDados.ForeColor = System.Drawing.Color.White;
            this.grpDados.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.grpDados.Location = new System.Drawing.Point(10, 10);
            this.grpDados.Name = "grpDados";
            this.grpDados.Size = new System.Drawing.Size(914, 185);
            this.grpDados.TabIndex = 0;
            this.grpDados.TabStop = false;
            this.grpDados.Text = "Dados da Reserva";
            this.grpDados.Controls.Add(this.lblHospede);
            this.grpDados.Controls.Add(this.cboHospede);
            this.grpDados.Controls.Add(this.lblFilial);
            this.grpDados.Controls.Add(this.cboFilial);
            this.grpDados.Controls.Add(this.lblNumeroQuarto);
            this.grpDados.Controls.Add(this.nudNumeroQuarto);
            this.grpDados.Controls.Add(this.lblTipoQuarto);
            this.grpDados.Controls.Add(this.cboTipoQuarto);
            this.grpDados.Controls.Add(this.lblCheckin);
            this.grpDados.Controls.Add(this.dtpCheckin);
            this.grpDados.Controls.Add(this.lblCheckout);
            this.grpDados.Controls.Add(this.dtpCheckout);
            this.grpDados.Controls.Add(this.lblValorDiaria);
            this.grpDados.Controls.Add(this.txtValorDiaria);
            this.grpDados.Controls.Add(this.lblStatus);
            this.grpDados.Controls.Add(this.cboStatus);
            this.grpDados.Controls.Add(this.lblObservacoes);
            this.grpDados.Controls.Add(this.txtObservacoes);
            // 
            // lblHospede
            // 
            this.lblHospede.AutoSize = true;
            this.lblHospede.ForeColor = System.Drawing.Color.White;
            this.lblHospede.Location = new System.Drawing.Point(10, 30);
            this.lblHospede.Name = "lblHospede";
            this.lblHospede.TabIndex = 0;
            this.lblHospede.Text = "Hóspede:";
            // 
            // cboHospede
            // 
            this.cboHospede.BackColor = System.Drawing.Color.FromArgb(50, 50, 70);
            this.cboHospede.ForeColor = System.Drawing.Color.White;
            this.cboHospede.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHospede.Location = new System.Drawing.Point(85, 27);
            this.cboHospede.Name = "cboHospede";
            this.cboHospede.Size = new System.Drawing.Size(320, 23);
            this.cboHospede.TabIndex = 1;
            // 
            // lblFilial
            // 
            this.lblFilial.AutoSize = true;
            this.lblFilial.ForeColor = System.Drawing.Color.White;
            this.lblFilial.Location = new System.Drawing.Point(425, 30);
            this.lblFilial.Name = "lblFilial";
            this.lblFilial.TabIndex = 2;
            this.lblFilial.Text = "Filial:";
            // 
            // cboFilial
            // 
            this.cboFilial.BackColor = System.Drawing.Color.FromArgb(50, 50, 70);
            this.cboFilial.ForeColor = System.Drawing.Color.White;
            this.cboFilial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilial.Location = new System.Drawing.Point(470, 27);
            this.cboFilial.Name = "cboFilial";
            this.cboFilial.Size = new System.Drawing.Size(430, 23);
            this.cboFilial.TabIndex = 3;
            // 
            // lblNumeroQuarto
            // 
            this.lblNumeroQuarto.AutoSize = true;
            this.lblNumeroQuarto.ForeColor = System.Drawing.Color.White;
            this.lblNumeroQuarto.Location = new System.Drawing.Point(10, 70);
            this.lblNumeroQuarto.Name = "lblNumeroQuarto";
            this.lblNumeroQuarto.TabIndex = 4;
            this.lblNumeroQuarto.Text = "Nº Quarto:";
            // 
            // nudNumeroQuarto
            // 
            this.nudNumeroQuarto.BackColor = System.Drawing.Color.FromArgb(50, 50, 70);
            this.nudNumeroQuarto.ForeColor = System.Drawing.Color.White;
            this.nudNumeroQuarto.Location = new System.Drawing.Point(90, 67);
            this.nudNumeroQuarto.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            this.nudNumeroQuarto.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudNumeroQuarto.Name = "nudNumeroQuarto";
            this.nudNumeroQuarto.Size = new System.Drawing.Size(80, 23);
            this.nudNumeroQuarto.TabIndex = 5;
            this.nudNumeroQuarto.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblTipoQuarto
            // 
            this.lblTipoQuarto.AutoSize = true;
            this.lblTipoQuarto.ForeColor = System.Drawing.Color.White;
            this.lblTipoQuarto.Location = new System.Drawing.Point(190, 70);
            this.lblTipoQuarto.Name = "lblTipoQuarto";
            this.lblTipoQuarto.TabIndex = 6;
            this.lblTipoQuarto.Text = "Tipo:";
            // 
            // cboTipoQuarto
            // 
            this.cboTipoQuarto.BackColor = System.Drawing.Color.FromArgb(50, 50, 70);
            this.cboTipoQuarto.ForeColor = System.Drawing.Color.White;
            this.cboTipoQuarto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoQuarto.Items.AddRange(new object[] { "Simples", "Duplo", "Suíte", "Master" });
            this.cboTipoQuarto.Location = new System.Drawing.Point(230, 67);
            this.cboTipoQuarto.Name = "cboTipoQuarto";
            this.cboTipoQuarto.Size = new System.Drawing.Size(130, 23);
            this.cboTipoQuarto.TabIndex = 7;
            // 
            // lblCheckin
            // 
            this.lblCheckin.AutoSize = true;
            this.lblCheckin.ForeColor = System.Drawing.Color.White;
            this.lblCheckin.Location = new System.Drawing.Point(380, 70);
            this.lblCheckin.Name = "lblCheckin";
            this.lblCheckin.TabIndex = 8;
            this.lblCheckin.Text = "Check-in:";
            // 
            // dtpCheckin
            // 
            this.dtpCheckin.CalendarForeColor = System.Drawing.Color.White;
            this.dtpCheckin.CalendarMonthBackground = System.Drawing.Color.FromArgb(50, 50, 70);
            this.dtpCheckin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCheckin.Location = new System.Drawing.Point(450, 67);
            this.dtpCheckin.Name = "dtpCheckin";
            this.dtpCheckin.Size = new System.Drawing.Size(130, 23);
            this.dtpCheckin.TabIndex = 9;
            // 
            // lblCheckout
            // 
            this.lblCheckout.AutoSize = true;
            this.lblCheckout.ForeColor = System.Drawing.Color.White;
            this.lblCheckout.Location = new System.Drawing.Point(600, 70);
            this.lblCheckout.Name = "lblCheckout";
            this.lblCheckout.TabIndex = 10;
            this.lblCheckout.Text = "Check-out:";
            // 
            // dtpCheckout
            // 
            this.dtpCheckout.CalendarForeColor = System.Drawing.Color.White;
            this.dtpCheckout.CalendarMonthBackground = System.Drawing.Color.FromArgb(50, 50, 70);
            this.dtpCheckout.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCheckout.Location = new System.Drawing.Point(680, 67);
            this.dtpCheckout.Name = "dtpCheckout";
            this.dtpCheckout.Size = new System.Drawing.Size(130, 23);
            this.dtpCheckout.TabIndex = 11;
            // 
            // lblValorDiaria
            // 
            this.lblValorDiaria.AutoSize = true;
            this.lblValorDiaria.ForeColor = System.Drawing.Color.White;
            this.lblValorDiaria.Location = new System.Drawing.Point(10, 115);
            this.lblValorDiaria.Name = "lblValorDiaria";
            this.lblValorDiaria.TabIndex = 12;
            this.lblValorDiaria.Text = "Valor Diária:";
            // 
            // txtValorDiaria
            // 
            this.txtValorDiaria.BackColor = System.Drawing.Color.FromArgb(50, 50, 70);
            this.txtValorDiaria.ForeColor = System.Drawing.Color.White;
            this.txtValorDiaria.Location = new System.Drawing.Point(100, 112);
            this.txtValorDiaria.Name = "txtValorDiaria";
            this.txtValorDiaria.Size = new System.Drawing.Size(100, 23);
            this.txtValorDiaria.TabIndex = 13;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.ForeColor = System.Drawing.Color.White;
            this.lblStatus.Location = new System.Drawing.Point(220, 115);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.TabIndex = 14;
            this.lblStatus.Text = "Status:";
            // 
            // cboStatus
            // 
            this.cboStatus.BackColor = System.Drawing.Color.FromArgb(50, 50, 70);
            this.cboStatus.ForeColor = System.Drawing.Color.White;
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.Items.AddRange(new object[] { "Ativa", "Concluída", "Cancelada" });
            this.cboStatus.Location = new System.Drawing.Point(270, 112);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(130, 23);
            this.cboStatus.TabIndex = 15;
            // 
            // lblObservacoes
            // 
            this.lblObservacoes.AutoSize = true;
            this.lblObservacoes.ForeColor = System.Drawing.Color.White;
            this.lblObservacoes.Location = new System.Drawing.Point(420, 115);
            this.lblObservacoes.Name = "lblObservacoes";
            this.lblObservacoes.TabIndex = 16;
            this.lblObservacoes.Text = "Observações:";
            // 
            // txtObservacoes
            // 
            this.txtObservacoes.BackColor = System.Drawing.Color.FromArgb(50, 50, 70);
            this.txtObservacoes.ForeColor = System.Drawing.Color.White;
            this.txtObservacoes.Location = new System.Drawing.Point(510, 112);
            this.txtObservacoes.Multiline = true;
            this.txtObservacoes.Name = "txtObservacoes";
            this.txtObservacoes.Size = new System.Drawing.Size(390, 60);
            this.txtObservacoes.TabIndex = 17;
            // 
            // pnlBotoes
            // 
            this.pnlBotoes.BackColor = System.Drawing.Color.FromArgb(45, 45, 65);
            this.pnlBotoes.Controls.Add(this.btnSalvar);
            this.pnlBotoes.Controls.Add(this.btnNovo);
            this.pnlBotoes.Controls.Add(this.btnExcluir);
            this.pnlBotoes.Location = new System.Drawing.Point(10, 205);
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
            this.pnlBusca.Location = new System.Drawing.Point(10, 260);
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
            this.lblBusca.Text = "Busca (Status):";
            // 
            // txtBusca
            // 
            this.txtBusca.BackColor = System.Drawing.Color.FromArgb(50, 50, 70);
            this.txtBusca.ForeColor = System.Drawing.Color.White;
            this.txtBusca.Location = new System.Drawing.Point(105, 9);
            this.txtBusca.Name = "txtBusca";
            this.txtBusca.Size = new System.Drawing.Size(675, 23);
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
            // dgvReservas
            // 
            this.dgvReservas.AllowUserToAddRows = false;
            this.dgvReservas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReservas.BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 45);
            this.dgvReservas.EnableHeadersVisualStyles = false;
            this.dgvReservas.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(45, 45, 65);
            this.dgvReservas.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvReservas.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvReservas.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(30, 30, 45);
            this.dgvReservas.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvReservas.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(40, 40, 58);
            this.dgvReservas.AlternatingRowsDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvReservas.Location = new System.Drawing.Point(10, 310);
            this.dgvReservas.Name = "dgvReservas";
            this.dgvReservas.ReadOnly = true;
            this.dgvReservas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReservas.Size = new System.Drawing.Size(914, 240);
            this.dgvReservas.TabIndex = 3;
            this.dgvReservas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReservas_CellClick);
            // 
            // frmCadastroReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(30, 30, 45);
            this.ClientSize = new System.Drawing.Size(934, 561);
            this.Controls.Add(this.grpDados);
            this.Controls.Add(this.pnlBotoes);
            this.Controls.Add(this.pnlBusca);
            this.Controls.Add(this.dgvReservas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmCadastroReserva";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Reservas";
            this.Load += new System.EventHandler(this.frmCadastroReserva_Load);
            this.grpDados.ResumeLayout(false);
            this.grpDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumeroQuarto)).EndInit();
            this.pnlBotoes.ResumeLayout(false);
            this.pnlBusca.ResumeLayout(false);
            this.pnlBusca.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservas)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox grpDados;
        private System.Windows.Forms.Label lblHospede;
        private System.Windows.Forms.ComboBox cboHospede;
        private System.Windows.Forms.Label lblFilial;
        private System.Windows.Forms.ComboBox cboFilial;
        private System.Windows.Forms.Label lblNumeroQuarto;
        private System.Windows.Forms.NumericUpDown nudNumeroQuarto;
        private System.Windows.Forms.Label lblTipoQuarto;
        private System.Windows.Forms.ComboBox cboTipoQuarto;
        private System.Windows.Forms.Label lblCheckin;
        private System.Windows.Forms.DateTimePicker dtpCheckin;
        private System.Windows.Forms.Label lblCheckout;
        private System.Windows.Forms.DateTimePicker dtpCheckout;
        private System.Windows.Forms.Label lblValorDiaria;
        private System.Windows.Forms.TextBox txtValorDiaria;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Label lblObservacoes;
        private System.Windows.Forms.TextBox txtObservacoes;
        private System.Windows.Forms.Panel pnlBotoes;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Panel pnlBusca;
        private System.Windows.Forms.Label lblBusca;
        private System.Windows.Forms.TextBox txtBusca;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dgvReservas;
    }
}
