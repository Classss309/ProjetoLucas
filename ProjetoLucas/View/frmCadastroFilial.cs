using ProjetoLucas.Controller;
using ProjetoLucas.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProjetoLucas.View
{
    public partial class frmCadastroFilial : Form
    {
        int idAtual = 0;
        FilialController ctrl = new FilialController();
        EnderecoController ctrlEnd = new EnderecoController();

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
            EnderecoCollection enderecos = ctrlEnd.GetAll();
            List<object> itens = new List<object>();

            foreach (Endereco end in enderecos)
            {
                itens.Add(new { Text = end.Logradouro + ", " + end.Numero + " - " + end.Cidade + "/" + end.Estado, Value = end.IdEndereco });
            }

            cboEndereco.DataSource    = itens;
            cboEndereco.DisplayMember = "Text";
            cboEndereco.ValueMember   = "Value";
        }

        private void CarregarGrid()
        {
            dgvFiliais.DataSource = ctrl.GetAll();
        }

        private void LimparCampos()
        {
            idAtual = 0;
            txtRazaoSocial.Text = "";
            txtCNPJ.Text = "";
            txtTelefone.Text = "";
            txtEmail.Text = "";
            nudAvaliacao.Value = 1;
            if (cboEndereco.Items.Count > 0) cboEndereco.SelectedIndex = 0;
            chkAtivo.Checked = true;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtRazaoSocial.Text == "")
            {
                MessageBox.Show("Informe a Razão Social.");
                return;
            }

            Filial f = new Filial();
            f.idFilial    = idAtual;
            f.RazaoSocial = txtRazaoSocial.Text;
            f.CNPJ        = txtCNPJ.Text;
            f.Telefone    = txtTelefone.Text;
            f.Email       = txtEmail.Text;
            f.Avaliacao   = nudAvaliacao.Value;
            f.IdEndereco  = cboEndereco.SelectedValue != null ? Convert.ToInt32(cboEndereco.SelectedValue) : 0;
            f.Ativo       = chkAtivo.Checked;

            if (idAtual == 0)
                ctrl.Inserir(f);
            else
                ctrl.Alterar(f);

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
                MessageBox.Show("Selecione uma filial para excluir.");
                return;
            }

            if (MessageBox.Show(
                "Deseja excluir?",
                "Confirmar",
                MessageBoxButtons.YesNo) != DialogResult.Yes)
            try
            {
                int resultado = ctrl.Excluir(idAtual);

                if (resultado > 0)
                {
                    MessageBox.Show("Filial excluída com sucesso!");
                    LimparCampos();
                    CarregarGrid();
                }
                else
                {
                    MessageBox.Show("Não foi possível excluir a filial.");
                }
            }
            catch (SqlException ex) 
            {
                MessageBox.Show($"Ocorreu um erro ao excluir a filial. {ex.Message}", "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBusca.Text == "")
                CarregarGrid();
            else
                dgvFiliais.DataSource = ctrl.GetFilials(txtBusca.Text);
        }

        private void dgvFiliais_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvFiliais.Rows[e.RowIndex];
            idAtual              = Convert.ToInt32(row.Cells["idFilial"].Value);

            Filial f = ctrl.GetById(idAtual);
            if (f == null) return;

            txtRazaoSocial.Text = f.RazaoSocial;
            txtCNPJ.Text        = f.CNPJ;
            txtTelefone.Text    = f.Telefone;
            txtEmail.Text       = f.Email;
            nudAvaliacao.Value  = f.Avaliacao;
            chkAtivo.Checked    = f.Ativo;
            cboEndereco.SelectedValue = f.IdEndereco;
        }
    }
}
