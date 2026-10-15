using System;
using System.Windows.Forms;
using ProjetoLucas.Controller;
using ProjetoLucas.Models;

namespace ProjetoLucas.View
{
    public partial class frmCadastroHospede : Form
    {
        int idAtual = 0;
        HospedeController ctrl = new HospedeController();

        public frmCadastroHospede()
        {
            InitializeComponent();
        }

        private void frmCadastroHospede_Load(object sender, EventArgs e)
        {
            CarregarGrid();
        }

        private void CarregarGrid()
        {
            dgvHospedes.DataSource = ctrl.GetAll();
        }

        private void LimparCampos()
        {
            idAtual = 0;
            txtNome.Text = "";
            txtCPF.Text = "";
            txtRG.Text = "";
            txtTelefone.Text = "";
            txtEmail.Text = "";
            dtpDataNascimento.Value = DateTime.Today;
            txtNacionalidade.Text = "";
            chkAtivo.Checked = true;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == "")
            {
                MessageBox.Show("Informe o nome do hóspede.");
                return;
            }

            Hospede h = new Hospede();
            h.IdHospede      = idAtual;
            h.Nome           = txtNome.Text;
            h.CPF            = txtCPF.Text;
            h.RG             = txtRG.Text;
            h.Telefone       = txtTelefone.Text;
            h.Email          = txtEmail.Text;
            h.DataNascimento = dtpDataNascimento.Value;
            h.Nacionalidade  = txtNacionalidade.Text;
            h.Ativo          = chkAtivo.Checked;

            if (idAtual == 0)
                ctrl.Inserir(h);
            else
                ctrl.Alterar(h);

            MessageBox.Show("Salvo com sucesso!");
            LimparCampos();
            CarregarGrid();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (idAtual == 0)
            {
                MessageBox.Show("Selecione um hóspede para excluir.");
                return;
            }

            if (MessageBox.Show("Deseja excluir?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ctrl.Excluir(idAtual);
                MessageBox.Show("Excluído com sucesso!");
                LimparCampos();
                CarregarGrid();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBusca.Text == "")
                CarregarGrid();
            else
                dgvHospedes.DataSource = ctrl.GetHospedes(txtBusca.Text);
        }

        private void dgvHospedes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvHospedes.Rows[e.RowIndex];
            idAtual              = Convert.ToInt32(row.Cells["IdHospede"].Value);
            txtNome.Text         = row.Cells["Nome"].Value.ToString();
            txtCPF.Text          = row.Cells["CPF"].Value.ToString();
            txtRG.Text           = row.Cells["RG"].Value.ToString();
            txtTelefone.Text     = row.Cells["Telefone"].Value.ToString();
            txtEmail.Text        = row.Cells["Email"].Value.ToString();
            dtpDataNascimento.Value = Convert.ToDateTime(row.Cells["DataNascimento"].Value);
            txtNacionalidade.Text   = row.Cells["Nacionalidade"].Value.ToString();
            chkAtivo.Checked        = Convert.ToBoolean(row.Cells["Ativo"].Value);
        }
    }
}
