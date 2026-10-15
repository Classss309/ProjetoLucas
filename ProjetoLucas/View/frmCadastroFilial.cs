using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ProjetoLucas.Controller;
using ProjetoLucas.Models;

namespace ProjetoLucas.View
{
    public partial class frmCadastroFilial : Form
    {
        private int _idFilialAtual = 0;
        private FilialController _filialCtrl = new FilialController();
        private EnderecoController _enderecoCtrl = new EnderecoController();

        public frmCadastroFilial()
        {
            InitializeComponent();
        }

        private void frmCadastroFilial_Load(object sender, EventArgs e)
        {
            CarregarComboEnderecos();
            CarregarGrid();
        }

        private void CarregarComboEnderecos()
        {
            try
            {
                EnderecoCollection enderecos = _enderecoCtrl.GetAll();
                var itens = new List<object>();
                foreach (Endereco end in enderecos)
                {
                    itens.Add(new { Text = end.Logradouro + ", " + end.Numero + " – " + end.Cidade + "/" + end.Estado, Value = end.IdEndereco });
                }
                cboEndereco.DataSource = itens;
                cboEndereco.DisplayMember = "Text";
                cboEndereco.ValueMember = "Value";
                if (itens.Count == 0)
                    cboEndereco.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar endereços: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarGrid()
        {
            try
            {
                dgvFiliais.DataSource = _filialCtrl.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar filiais: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparCampos()
        {
            _idFilialAtual = 0;
            txtRazaoSocial.Text = string.Empty;
            txtCNPJ.Text = string.Empty;
            txtTelefone.Text = string.Empty;
            txtEmail.Text = string.Empty;
            nudAvaliacao.Value = 1;
            if (cboEndereco.Items.Count > 0) cboEndereco.SelectedIndex = 0;
            chkAtivo.Checked = true;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRazaoSocial.Text))
            {
                MessageBox.Show("Razão Social é obrigatória.", "Validação",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Filial filial = new Filial();
                filial.idFilial = _idFilialAtual;
                filial.RazaoSocial = txtRazaoSocial.Text.Trim();
                filial.CNPJ = txtCNPJ.Text.Trim();
                filial.Telefone = txtTelefone.Text.Trim();
                filial.Email = txtEmail.Text.Trim();
                filial.Avaliacao = nudAvaliacao.Value;
                filial.IdEndereco = cboEndereco.SelectedValue != null ? Convert.ToInt32(cboEndereco.SelectedValue) : 0;
                filial.Ativo = chkAtivo.Checked;

                if (_idFilialAtual == 0)
                    _filialCtrl.Inserir(filial);
                else
                    _filialCtrl.Alterar(filial);

                MessageBox.Show("Filial salva com sucesso!", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();
                CarregarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar filial: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (_idFilialAtual == 0)
            {
                MessageBox.Show("Selecione uma filial para excluir.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Deseja realmente excluir esta filial?", "Confirmação",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    _filialCtrl.Excluir(_idFilialAtual);
                    MessageBox.Show("Filial excluída com sucesso!", "Sucesso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCampos();
                    CarregarGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao excluir filial: " + ex.Message, "Erro",
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
                    dgvFiliais.DataSource = _filialCtrl.GetFilials(txtBusca.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar filiais: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvFiliais_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                DataGridViewRow row = dgvFiliais.Rows[e.RowIndex];
                _idFilialAtual = Convert.ToInt32(row.Cells["idFilial"].Value);

                Filial filial = _filialCtrl.GetById(_idFilialAtual);
                if (filial == null) return;

                txtRazaoSocial.Text = filial.RazaoSocial;
                txtCNPJ.Text = filial.CNPJ;
                txtTelefone.Text = filial.Telefone;
                txtEmail.Text = filial.Email;
                nudAvaliacao.Value = filial.Avaliacao >= nudAvaliacao.Minimum && filial.Avaliacao <= nudAvaliacao.Maximum
                    ? filial.Avaliacao : nudAvaliacao.Minimum;
                chkAtivo.Checked = filial.Ativo;

                try { cboEndereco.SelectedValue = filial.IdEndereco; } catch { }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao selecionar filial: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
