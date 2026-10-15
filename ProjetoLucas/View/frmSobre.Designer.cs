namespace ProjetoLucas.View
{
    partial class frmSobre
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
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.lblNome = new System.Windows.Forms.Label();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.lblVersao = new System.Windows.Forms.Label();
            this.lblEquipe = new System.Windows.Forms.Label();
            this.lblMembros = new System.Windows.Forms.Label();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.btnFechar = new System.Windows.Forms.Button();
            this.pnlInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlInfo
            // 
            this.pnlInfo.BackColor = System.Drawing.Color.FromArgb(45, 45, 65);
            this.pnlInfo.Controls.Add(this.lblNome);
            this.pnlInfo.Controls.Add(this.lblDescricao);
            this.pnlInfo.Controls.Add(this.lblVersao);
            this.pnlInfo.Controls.Add(this.lblEquipe);
            this.pnlInfo.Controls.Add(this.lblMembros);
            this.pnlInfo.Controls.Add(this.lblCopyright);
            this.pnlInfo.Location = new System.Drawing.Point(50, 40);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(400, 220);
            this.pnlInfo.TabIndex = 0;
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = false;
            this.lblNome.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblNome.ForeColor = System.Drawing.Color.White;
            this.lblNome.Location = new System.Drawing.Point(0, 15);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(400, 28);
            this.lblNome.TabIndex = 0;
            this.lblNome.Text = "Hotel California";
            this.lblNome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = false;
            this.lblDescricao.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
            this.lblDescricao.ForeColor = System.Drawing.Color.White;
            this.lblDescricao.Location = new System.Drawing.Point(0, 50);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(400, 22);
            this.lblDescricao.TabIndex = 1;
            this.lblDescricao.Text = "Sistema de Gestão Hoteleira";
            this.lblDescricao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVersao
            // 
            this.lblVersao.AutoSize = false;
            this.lblVersao.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblVersao.ForeColor = System.Drawing.Color.White;
            this.lblVersao.Location = new System.Drawing.Point(0, 80);
            this.lblVersao.Name = "lblVersao";
            this.lblVersao.Size = new System.Drawing.Size(400, 20);
            this.lblVersao.TabIndex = 2;
            this.lblVersao.Text = "Versão 1.0";
            this.lblVersao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEquipe
            // 
            this.lblEquipe.AutoSize = false;
            this.lblEquipe.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblEquipe.ForeColor = System.Drawing.Color.White;
            this.lblEquipe.Location = new System.Drawing.Point(0, 115);
            this.lblEquipe.Name = "lblEquipe";
            this.lblEquipe.Size = new System.Drawing.Size(400, 20);
            this.lblEquipe.TabIndex = 3;
            this.lblEquipe.Text = "Equipe:";
            this.lblEquipe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMembros
            // 
            this.lblMembros.AutoSize = false;
            this.lblMembros.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMembros.ForeColor = System.Drawing.Color.White;
            this.lblMembros.Location = new System.Drawing.Point(0, 140);
            this.lblMembros.Name = "lblMembros";
            this.lblMembros.Size = new System.Drawing.Size(400, 20);
            this.lblMembros.TabIndex = 4;
            this.lblMembros.Text = "Renan Carvalho dos Santos | João | Cayc";
            this.lblMembros.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCopyright
            // 
            this.lblCopyright.AutoSize = false;
            this.lblCopyright.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.lblCopyright.ForeColor = System.Drawing.Color.White;
            this.lblCopyright.Location = new System.Drawing.Point(0, 190);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(400, 18);
            this.lblCopyright.TabIndex = 5;
            this.lblCopyright.Text = "© 2026 RCJ Desenvolvimento. Todos os direitos reservados.";
            this.lblCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnFechar
            // 
            this.btnFechar.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFechar.ForeColor = System.Drawing.Color.White;
            this.btnFechar.Location = new System.Drawing.Point(175, 280);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(150, 35);
            this.btnFechar.TabIndex = 1;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = false;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // frmSobre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(30, 30, 45);
            this.ClientSize = new System.Drawing.Size(500, 340);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.pnlInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmSobre";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sobre — Hotel California";
            this.pnlInfo.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.Label lblVersao;
        private System.Windows.Forms.Label lblEquipe;
        private System.Windows.Forms.Label lblMembros;
        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.Button btnFechar;
    }
}
