using System;
using System.Windows.Forms;
using ProjetoLucas.Controller;
using ProjetoLucas.Models;

namespace ProjetoLucas.View
{
    public partial class frmCadastroHospede : Form
    {
        private int _idHospedeAtual = 0;
        private HospedeController _hospedeCtrl = new HospedeController();

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
            try
            {
                dgvHospedes.DataSource = _hospedeCtrl.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar hóspedes: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparCampos()
        {
            _idHospedeAtual = 0;
            txtNome.Text = string.Empty;
            txtCPF.Text = string.Empty;
            txtRG.Text = string.Empty;
            txtTelefone.Text = string.Empty;
            txtEmail.Text = string.Empty;
            dtpDataNascimento.Value = DateTime.Today;
            txtNacionalidade.Text = string.Empty;
            chkAtivo.Checked = true;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("Nome é obrigatório.", "Validação",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Hospede hospede = new Hospede();
                hospede.IdHospede = _idHospedeAtual;
                hospede.Nome = txtNome.Text.Trim();
                hospede.CPF = txtCPF.Text.Trim();
                hospede.RG = txtRG.Text.Trim();
                hospede.Telefone = txtTelefone.Text.Trim();
                hospede.Email = txtEmail.Text.Trim();
                hospede.DataNascimento = dtpDataNascimento.Value;
                hospede.Nacionalidade = txtNacionalidade.Text.Trim();
                hospede.Ativo = chkAtivo.Checked;

                if (_idHospedeAtual == 0)
                    _hospedeCtrl.Inserir(hospede);
                else
                    _hospedeCtrl.Alterar(hospede);

                MessageBox.Show("Hóspede salvo com sucesso!", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();
                CarregarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar hóspede: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (_idHospedeAtual == 0)
            {
                MessageBox.Show("Selecione um hóspede para excluir.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Deseja realmente excluir este hóspede?", "Confirmação",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    _hospedeCtrl.Excluir(_idHospedeAtual);
                    MessageBox.Show("Hóspede excluído com sucesso!", "Sucesso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCampos();
                    CarregarGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao excluir hóspede: " + ex.Message, "Erro",
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
                    dgvHospedes.DataSource = _hospedeCtrl.GetHospedes(txtBusca.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar hóspedes: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvHospedes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                DataGridViewRow row = dgvHospedes.Rows[e.RowIndex];
                _idHospedeAtual = Convert.ToInt32(row.Cells["IdHospede"].Value);
                txtNome.Text = row.Cells["Nome"].Value?.ToString() ?? string.Empty;
                txtCPF.Text = row.Cells["CPF"].Value?.ToString() ?? string.Empty;
                txtRG.Text = row.Cells["RG"].Value?.ToString() ?? string.Empty;
                txtTelefone.Text = row.Cells["Telefone"].Value?.ToString() ?? string.Empty;
                txtEmail.Text = row.Cells["Email"].Value?.ToString() ?? string.Empty;
                if (row.Cells["DataNascimento"].Value != null)
                    dtpDataNascimento.Value = Convert.ToDateTime(row.Cells["DataNascimento"].Value);
                txtNacionalidade.Text = row.Cells["Nacionalidade"].Value?.ToString() ?? string.Empty;
                chkAtivo.Checked = Convert.ToBoolean(row.Cells["Ativo"].Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao selecionar hóspede: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
