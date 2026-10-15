using System;
using System.Windows.Forms;
using ProjetoLucas.Controller;
using ProjetoLucas.Models;

namespace ProjetoLucas.View
{
    public partial class frmCadastroEndereco : Form
    {
        private int _idEnderecoAtual = 0;
        private EnderecoController _enderecoCtrl = new EnderecoController();

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
            try
            {
                dgvEnderecos.DataSource = _enderecoCtrl.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar endereços: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparCampos()
        {
            _idEnderecoAtual = 0;
            txtLogradouro.Text = string.Empty;
            txtNumero.Text = string.Empty;
            txtComplemento.Text = string.Empty;
            txtBairro.Text = string.Empty;
            txtCidade.Text = string.Empty;
            cboEstado.SelectedIndex = -1;
            txtCEP.Text = string.Empty;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLogradouro.Text))
            {
                MessageBox.Show("Logradouro é obrigatório.", "Validação",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Endereco endereco = new Endereco();
                endereco.IdEndereco = _idEnderecoAtual;
                endereco.Logradouro = txtLogradouro.Text.Trim();
                endereco.Numero = txtNumero.Text.Trim();
                endereco.Complemento = txtComplemento.Text.Trim();
                endereco.Bairro = txtBairro.Text.Trim();
                endereco.Cidade = txtCidade.Text.Trim();
                endereco.Estado = cboEstado.SelectedItem != null ? cboEstado.SelectedItem.ToString() : string.Empty;
                endereco.CEP = txtCEP.Text.Trim();

                if (_idEnderecoAtual == 0)
                    _enderecoCtrl.Inserir(endereco);
                else
                    _enderecoCtrl.Alterar(endereco);

                MessageBox.Show("Endereço salvo com sucesso!", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();
                CarregarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar endereço: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (_idEnderecoAtual == 0)
            {
                MessageBox.Show("Selecione um endereço para excluir.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Deseja realmente excluir este endereço?", "Confirmação",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    _enderecoCtrl.Excluir(_idEnderecoAtual);
                    MessageBox.Show("Endereço excluído com sucesso!", "Sucesso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCampos();
                    CarregarGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao excluir endereço: " + ex.Message, "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtBusca.Text))
                    CarregarGrid();
                else
                    dgvEnderecos.DataSource = _enderecoCtrl.GetEnderecos(txtBusca.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar endereços: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvEnderecos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                DataGridViewRow row = dgvEnderecos.Rows[e.RowIndex];
                _idEnderecoAtual = Convert.ToInt32(row.Cells["IdEndereco"].Value);
                txtLogradouro.Text = row.Cells["Logradouro"].Value?.ToString() ?? string.Empty;
                txtNumero.Text = row.Cells["Numero"].Value?.ToString() ?? string.Empty;
                txtComplemento.Text = row.Cells["Complemento"].Value?.ToString() ?? string.Empty;
                txtBairro.Text = row.Cells["Bairro"].Value?.ToString() ?? string.Empty;
                txtCidade.Text = row.Cells["Cidade"].Value?.ToString() ?? string.Empty;
                string estado = row.Cells["Estado"].Value?.ToString() ?? string.Empty;
                cboEstado.SelectedItem = estado.Trim();
                txtCEP.Text = row.Cells["CEP"].Value?.ToString() ?? string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao selecionar endereço: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
