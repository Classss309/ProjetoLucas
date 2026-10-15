using System.Drawing;
using System.Windows.Forms;

namespace ProjetoLucas
{
    partial class frmMenu
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cadastroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrarFilialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hospedeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrarHospedeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enderecoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrarEnderecoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reservarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.novaReservaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrarNovaReservaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobreToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.flpBOTTON = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.flpBOTTON.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(45, 45, 65);
            this.menuStrip1.ForeColor = System.Drawing.Color.White;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.cadastroToolStripMenuItem,
                this.reservarToolStripMenuItem,
                this.sobreToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(934, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cadastroToolStripMenuItem
            // 
            this.cadastroToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.filialToolStripMenuItem,
                this.hospedeToolStripMenuItem,
                this.enderecoToolStripMenuItem});
            this.cadastroToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.cadastroToolStripMenuItem.Name = "cadastroToolStripMenuItem";
            this.cadastroToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.cadastroToolStripMenuItem.Text = "Cadastro";
            // 
            // filialToolStripMenuItem
            // 
            this.filialToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.cadastrarFilialToolStripMenuItem});
            this.filialToolStripMenuItem.Name = "filialToolStripMenuItem";
            this.filialToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.filialToolStripMenuItem.Text = "Filial";
            // 
            // cadastrarFilialToolStripMenuItem
            // 
            this.cadastrarFilialToolStripMenuItem.Name = "cadastrarFilialToolStripMenuItem";
            this.cadastrarFilialToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cadastrarFilialToolStripMenuItem.Text = "Cadastrar Filial";
            this.cadastrarFilialToolStripMenuItem.Click += new System.EventHandler(this.cadastrarFilialToolStripMenuItem_Click);
            // 
            // hospedeToolStripMenuItem
            // 
            this.hospedeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.cadastrarHospedeToolStripMenuItem});
            this.hospedeToolStripMenuItem.Name = "hospedeToolStripMenuItem";
            this.hospedeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.hospedeToolStripMenuItem.Text = "Hóspede";
            // 
            // cadastrarHospedeToolStripMenuItem
            // 
            this.cadastrarHospedeToolStripMenuItem.Name = "cadastrarHospedeToolStripMenuItem";
            this.cadastrarHospedeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cadastrarHospedeToolStripMenuItem.Text = "Cadastrar Hóspede";
            this.cadastrarHospedeToolStripMenuItem.Click += new System.EventHandler(this.cadastrarHospedeToolStripMenuItem_Click);
            // 
            // enderecoToolStripMenuItem
            // 
            this.enderecoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.cadastrarEnderecoToolStripMenuItem});
            this.enderecoToolStripMenuItem.Name = "enderecoToolStripMenuItem";
            this.enderecoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.enderecoToolStripMenuItem.Text = "Endereço";
            // 
            // cadastrarEnderecoToolStripMenuItem
            // 
            this.cadastrarEnderecoToolStripMenuItem.Name = "cadastrarEnderecoToolStripMenuItem";
            this.cadastrarEnderecoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cadastrarEnderecoToolStripMenuItem.Text = "Cadastrar Endereço";
            this.cadastrarEnderecoToolStripMenuItem.Click += new System.EventHandler(this.cadastrarEnderecoToolStripMenuItem_Click);
            // 
            // reservarToolStripMenuItem
            // 
            this.reservarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.novaReservaToolStripMenuItem});
            this.reservarToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.reservarToolStripMenuItem.Name = "reservarToolStripMenuItem";
            this.reservarToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.reservarToolStripMenuItem.Text = "Reservas";
            // 
            // novaReservaToolStripMenuItem
            // 
            this.novaReservaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.cadastrarNovaReservaToolStripMenuItem});
            this.novaReservaToolStripMenuItem.Name = "novaReservaToolStripMenuItem";
            this.novaReservaToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.novaReservaToolStripMenuItem.Text = "Nova Reserva";
            // 
            // cadastrarNovaReservaToolStripMenuItem
            // 
            this.cadastrarNovaReservaToolStripMenuItem.Name = "cadastrarNovaReservaToolStripMenuItem";
            this.cadastrarNovaReservaToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.cadastrarNovaReservaToolStripMenuItem.Text = "Cadastrar Nova Reserva";
            this.cadastrarNovaReservaToolStripMenuItem.Click += new System.EventHandler(this.cadastrarNovaReservaToolStripMenuItem_Click);
            // 
            // sobreToolStripMenuItem
            // 
            this.sobreToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.sobreToolStripMenuItem1});
            this.sobreToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.sobreToolStripMenuItem.Name = "sobreToolStripMenuItem";
            this.sobreToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.sobreToolStripMenuItem.Text = "Sobre";
            // 
            // sobreToolStripMenuItem1
            // 
            this.sobreToolStripMenuItem1.Name = "sobreToolStripMenuItem1";
            this.sobreToolStripMenuItem1.Size = new System.Drawing.Size(104, 22);
            this.sobreToolStripMenuItem1.Text = "Sobre";
            this.sobreToolStripMenuItem1.Click += new System.EventHandler(this.sobreToolStripMenuItem1_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = false;
            this.lblTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(167, 170);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(600, 50);
            this.lblTitulo.TabIndex = 2;
            this.lblTitulo.Text = "Hotel California";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = false;
            this.lblSubtitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.White;
            this.lblSubtitulo.Location = new System.Drawing.Point(167, 230);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(600, 30);
            this.lblSubtitulo.TabIndex = 3;
            this.lblSubtitulo.Text = "Sistema de Gestão Hoteleira";
            this.lblSubtitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flpBOTTON
            // 
            this.flpBOTTON.BackColor = System.Drawing.Color.FromArgb(20, 20, 35);
            this.flpBOTTON.Controls.Add(this.lblStatus);
            this.flpBOTTON.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flpBOTTON.Location = new System.Drawing.Point(0, 533);
            this.flpBOTTON.Name = "flpBOTTON";
            this.flpBOTTON.Size = new System.Drawing.Size(934, 28);
            this.flpBOTTON.TabIndex = 1;
            // 
            // lblStatus
            // 
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatus.ForeColor = System.Drawing.Color.White;
            this.lblStatus.Location = new System.Drawing.Point(0, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(934, 28);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Desenvolvido por: Renan Carvalho dos Santos | João | Cayc";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(30, 30, 45);
            this.ClientSize = new System.Drawing.Size(934, 561);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblSubtitulo);
            this.Controls.Add(this.flpBOTTON);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hotel California — Sistema de Gestão Hoteleira";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.flpBOTTON.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cadastroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hospedeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enderecoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastrarFilialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastrarHospedeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastrarEnderecoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reservarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem novaReservaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobreToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cadastrarNovaReservaToolStripMenuItem;
        private System.Windows.Forms.Panel flpBOTTON;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
    }
}
