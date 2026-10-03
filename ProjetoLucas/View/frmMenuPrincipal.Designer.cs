namespace ProjetoLucas
{
    partial class frmMenu
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenu));
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
            this.flpBOTTON = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.flpBOTTON.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
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
            this.cadastroToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonFace;
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
            this.hospedeToolStripMenuItem.Text = "Hospede";
            // 
            // cadastrarHospedeToolStripMenuItem
            // 
            this.cadastrarHospedeToolStripMenuItem.Name = "cadastrarHospedeToolStripMenuItem";
            this.cadastrarHospedeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cadastrarHospedeToolStripMenuItem.Text = "Cadastrar Hospede";
            this.cadastrarHospedeToolStripMenuItem.Click += new System.EventHandler(this.cadastrarHospedeToolStripMenuItem_Click);
            // 
            // enderecoToolStripMenuItem
            // 
            this.enderecoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrarEnderecoToolStripMenuItem});
            this.enderecoToolStripMenuItem.Name = "enderecoToolStripMenuItem";
            this.enderecoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.enderecoToolStripMenuItem.Text = "Endereco";
            // 
            // cadastrarEnderecoToolStripMenuItem
            // 
            this.cadastrarEnderecoToolStripMenuItem.Name = "cadastrarEnderecoToolStripMenuItem";
            this.cadastrarEnderecoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cadastrarEnderecoToolStripMenuItem.Text = "Cadastrar Endereco";
            this.cadastrarEnderecoToolStripMenuItem.Click += new System.EventHandler(this.cadastrarEnderecoToolStripMenuItem_Click);
            // 
            // reservarToolStripMenuItem
            // 
            this.reservarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novaReservaToolStripMenuItem});
            this.reservarToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.reservarToolStripMenuItem.Name = "reservarToolStripMenuItem";
            this.reservarToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.reservarToolStripMenuItem.Text = "Reservar";
            // 
            // novaReservaToolStripMenuItem
            // 
            this.novaReservaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrarNovaReservaToolStripMenuItem});
            this.novaReservaToolStripMenuItem.Name = "novaReservaToolStripMenuItem";
            this.novaReservaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
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
            this.sobreToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.sobreToolStripMenuItem.Name = "sobreToolStripMenuItem";
            this.sobreToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.sobreToolStripMenuItem.Text = "Sobre";
            // 
            // sobreToolStripMenuItem1
            // 
            this.sobreToolStripMenuItem1.Name = "sobreToolStripMenuItem1";
            this.sobreToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.sobreToolStripMenuItem1.Text = "Sobre";
            this.sobreToolStripMenuItem1.Click += new System.EventHandler(this.sobreToolStripMenuItem1_Click);
            // 
            // flpBOTTON
            // 
            this.flpBOTTON.BackColor = System.Drawing.Color.Transparent;
            this.flpBOTTON.Controls.Add(this.label1);
            this.flpBOTTON.Controls.Add(this.label2);
            this.flpBOTTON.Location = new System.Drawing.Point(0, 464);
            this.flpBOTTON.Name = "flpBOTTON";
            this.flpBOTTON.Size = new System.Drawing.Size(934, 53);
            this.flpBOTTON.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "DESENVOLVIDO POR:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(129, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Renan Carvalho dos Santos";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(934, 511);
            this.Controls.Add(this.flpBOTTON);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMenu";
            this.Text = "Menu Principal";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.flpBOTTON.ResumeLayout(false);
            this.flpBOTTON.PerformLayout();
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
        private System.Windows.Forms.FlowLayoutPanel flpBOTTON;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem cadastrarNovaReservaToolStripMenuItem;
    }
}

