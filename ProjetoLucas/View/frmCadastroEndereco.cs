using ProjetoLucas.Controller;
using ProjetoLucas.Models;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace ProjetoLucas.View
{
    public partial class frmCadastroEndereco : Form
    {

        // Aqui eu deixei 0 para ficar mais fácil de dar o retorno do id vazio vazias (Sem seleção)
        int idAtual = 0;
        EnderecoController ctrlEnd = new EnderecoController();

        //Carregar tela
        public frmCadastroEndereco()
        {
            InitializeComponent();
            //Já Chamei o Carregar grid para já chamar a tela populada.
            CarregarGrid();
        }


        #region Metodos

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
        void VerificarCampos()
        {
            Endereco endereco = new Endereco();
            try
            {
                TextBox[] campos = { txtBairro, txtCidade, txtCEP, txtLogradouro, txtNumero };

                for (int i = 0; i < campos.Length; i++)
                {
                    if (string.IsNullOrWhiteSpace(campos[i].Text))
                    {
                        MessageBox.Show("Preencha todos os campos.");
                        return;
                    }
                }
                endereco.Logradouro = txtLogradouro.Text;
                endereco.Numero = txtNumero.Text;
                endereco.Complemento = txtComplemento.Text;
                endereco.Bairro = txtBairro.Text;
                endereco.Cidade = txtCidade.Text;
                endereco.Estado = cboEstado.Text;
                endereco.CEP = txtCEP.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Não foi possível concluir a operação. Detalhes: {ex.Message}"
                );
            }

        }
        #endregion
        #region Botões

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            VerificarCampos();           
            CarregarGrid();
            LimparCampos();
        }
        private void btnNovo_Click(object sender, EventArgs e)
        {
            Endereco endereco = new Endereco();
            if (idAtual == 0)
                ctrlEnd.Inserir(endereco);
            else
            {
                MessageBox.Show($"O endereço de código{idAtual} já existe, Deseja Alterar?", 
                    "Confirmação",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if(DialogResult == DialogResult.Yes)
                {
                    ctrlEnd.Alterar(endereco);
                }
            }
            VerificarCampos();
            LimparCampos();
            CarregarGrid();
        }



        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                int resultado = ctrlEnd.Excluir(idAtual);

                if (resultado > 0)
                {
                    MessageBox.Show("Endereco excluída com sucesso!");
                    LimparCampos();
                    CarregarGrid();
                }
                if (idAtual == 0)
                {
                    MessageBox.Show("Selecione um endereço para excluir.");
                    return;
                }
            }
            catch (SqlException ex)
            {
                if(ex.Number == 547)
                MessageBox.Show($"Não foi possível excluir o Endereço, existe uma Reserva vinculada ao Hotel.", "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimparCampos();
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
            if (e.RowIndex < 0)
            {
                MessageBox.Show("Nenhuma Linha encontrada");
            }
            DataGridViewRow linha = dgvEnderecos.Rows[e.RowIndex];
            idAtual = Convert.ToInt32(linha.Cells["IdEndereco"].Value);
            txtLogradouro.Text = linha.Cells["Logradouro"].Value.ToString();
            txtNumero.Text = linha.Cells["Numero"].Value.ToString();
            txtComplemento.Text = linha.Cells["Complemento"].Value.ToString();
            txtBairro.Text = linha.Cells["Bairro"].Value.ToString();
            txtCidade.Text = linha.Cells["Cidade"].Value.ToString();
            cboEstado.SelectedItem = linha.Cells["Estado"].Value.ToString().Trim();
            txtCEP.Text = linha.Cells["CEP"].Value.ToString();
        }
        #endregion
    }


}   