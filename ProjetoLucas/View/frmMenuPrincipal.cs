
//Renan; Cayc ; João dodoi autista
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjetoLucas.View;

namespace ProjetoLucas
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }
        // Região para abrir as telas (NÃO FOI FEITA POR IA)
        #region MenuStrip
        private void cadastrarFilialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastroFilial frm = new frmCadastroFilial();
            frm.ShowDialog();
        }
        private void cadastrarHospedeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastroHospede frm = new frmCadastroHospede();
            frm.ShowDialog();
        }
        private void cadastrarEnderecoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastroEndereco frm = new frmCadastroEndereco();
            frm.ShowDialog();
        }
        private void cadastrarNovaReservaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastroReserva frm = new frmCadastroReserva();
            frm.ShowDialog();
        }
        private void sobreToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmSobre frm = new frmSobre();
            frm.ShowDialog();
        }















        #endregion



    }
}
