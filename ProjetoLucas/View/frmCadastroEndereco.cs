using ProjetoLucas.Controller;
using ProjetoLucas.Models;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProjetoLucas.View
{
    public partial class frmCadastroEndereco : Form
    {
        int idAtual = 0;
        EnderecoController ctrlEnd = new EnderecoController();

        public frmCadastroEndereco()
        {
            InitializeComponent();
        }

        private void frmCadastroEndereco_Load(object sender, EventArgs e)
        {
            CarregarGrid();
        }

        private void CarregarGrid()
        {
            dgvEnderecos.DataSource = ctrlEnd.GetAll();
        }

        private void LimparCampos()
        {
            idAtual = 0;
            txtLogradouro.Text = "";
            txtNumero.Text = "";
            txtComplemento.Text = "";
            txtBairro.Text = "";
            txtCidade.Text = "";
            cboEstado.SelectedIndex = -1;
            txtCEP.Text = "";
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtLogradouro.Text == "")
            {
                MessageBox.Show("Informe o logradouro.");
                return;
            }

            Endereco end = new Endereco();
            end.IdEndereco  = idAtual;
            end.Logradouro  = txtLogradouro.Text;
            end.Numero      = txtNumero.Text;
            end.Complemento = txtComplemento.Text;
            end.Bairro      = txtBairro.Text;
            end.Cidade      = txtCidade.Text;
            end.Estado      = cboEstado.SelectedItem != null ? cboEstado.SelectedItem.ToString() : "";
            end.CEP         = txtCEP.Text;

            if (idAtual == 0)
                ctrlEnd.Inserir(end);
            else
                ctrlEnd.Alterar(end);

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
                MessageBox.Show("Selecione um endereço para excluir.");
                return;
            }

            try
            {
                int resultado = ctrlEnd.Excluir(idAtual);

                if (resultado < 0)
                {
                    MessageBox.Show("Endereco excluída com sucesso!");
                    LimparCampos();
                    CarregarGrid();
                }
                else
                {
                    MessageBox.Show("Não foi possível excluir Endereco.");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Ocorreu um erro ao excluir Endereco. {ex.Message}", "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBusca.Text == "")
                CarregarGrid();
            else
                dgvEnderecos.DataSource = ctrlEnd.GetEnderecos(txtBusca.Text);
        }

        private void dgvEnderecos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvEnderecos.Rows[e.RowIndex];
            idAtual             = Convert.ToInt32(row.Cells["IdEndereco"].Value);
            txtLogradouro.Text  = row.Cells["Logradouro"].Value.ToString();
            txtNumero.Text      = row.Cells["Numero"].Value.ToString();
            txtComplemento.Text = row.Cells["Complemento"].Value.ToString();
            txtBairro.Text      = row.Cells["Bairro"].Value.ToString();
            txtCidade.Text      = row.Cells["Cidade"].Value.ToString();
            cboEstado.SelectedItem = row.Cells["Estado"].Value.ToString().Trim();
            txtCEP.Text         = row.Cells["CEP"].Value.ToString();
        }
    }
}
