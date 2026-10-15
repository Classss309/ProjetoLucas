using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ProjetoLucas.Controller;
using ProjetoLucas.Models;

namespace ProjetoLucas.View
{
    public partial class frmCadastroReserva : Form
    {
        int idAtual = 0;
        ReservaController ctrl = new ReservaController();
        HospedeController ctrlHosp = new HospedeController();
        FilialController ctrlFilial = new FilialController();

        public frmCadastroReserva()
        {
            InitializeComponent();
        }

        private void frmCadastroReserva_Load(object sender, EventArgs e)
        {
            CarregarComboHospedes();
            CarregarComboFiliais();
            CarregarGrid();
        }

        private void CarregarComboHospedes()
        {
            HospedeCollection hospedes = ctrlHosp.GetAll();
            List<object> itens = new List<object>();

            foreach (Hospede h in hospedes)
            {
                itens.Add(new { Text = h.Nome + " - " + h.CPF, Value = h.IdHospede });
            }

            cboHospede.DataSource    = itens;
            cboHospede.DisplayMember = "Text";
            cboHospede.ValueMember   = "Value";
        }

        private void CarregarComboFiliais()
        {
            FilialColletion filiais = ctrlFilial.GetAll();
            List<object> itens = new List<object>();

            foreach (Filial f in filiais)
            {
                itens.Add(new { Text = f.RazaoSocial, Value = f.idFilial });
            }

            cboFilial.DataSource    = itens;
            cboFilial.DisplayMember = "Text";
            cboFilial.ValueMember   = "Value";
        }

        private void CarregarGrid()
        {
            dgvReservas.DataSource = ctrl.GetDataTableAll();
        }

        private void LimparCampos()
        {
            idAtual = 0;
            if (cboHospede.Items.Count > 0) cboHospede.SelectedIndex = 0;
            if (cboFilial.Items.Count > 0) cboFilial.SelectedIndex = 0;
            nudNumeroQuarto.Value = 1;
            if (cboTipoQuarto.Items.Count > 0) cboTipoQuarto.SelectedIndex = 0;
            dtpCheckin.Value = DateTime.Today;
            dtpCheckout.Value = DateTime.Today.AddDays(1);
            txtValorDiaria.Text = "";
            txtObservacoes.Text = "";
            if (cboStatus.Items.Count > 0) cboStatus.SelectedIndex = 0;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtValorDiaria.Text == "")
            {
                MessageBox.Show("Informe o valor da diária.");
                return;
            }

            Reserva r = new Reserva();
            r.IdReserva    = idAtual;
            r.IdHospede    = Convert.ToInt32(cboHospede.SelectedValue);
            r.IdFilial     = Convert.ToInt32(cboFilial.SelectedValue);
            r.NumeroQuarto = (int)nudNumeroQuarto.Value;
            r.TipoQuarto   = cboTipoQuarto.SelectedItem.ToString();
            r.DataCheckin  = dtpCheckin.Value;
            r.DataCheckout = dtpCheckout.Value;
            r.ValorDiaria  = Convert.ToDecimal(txtValorDiaria.Text);
            r.Observacoes  = txtObservacoes.Text;
            r.Status       = cboStatus.SelectedItem.ToString();

            if (idAtual == 0)
                ctrl.Inserir(r);
            else
                ctrl.Alterar(r);

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
                MessageBox.Show("Selecione uma reserva para excluir.");
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
                dgvReservas.DataSource = ctrl.GetReservas(txtBusca.Text);
        }

        private void dgvReservas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvReservas.Rows[e.RowIndex];
            idAtual = Convert.ToInt32(row.Cells["IdReserva"].Value);

            Reserva r = ctrl.GetById(idAtual);
            if (r == null) return;

            cboHospede.SelectedValue  = r.IdHospede;
            cboFilial.SelectedValue   = r.IdFilial;
            nudNumeroQuarto.Value     = r.NumeroQuarto;
            cboTipoQuarto.SelectedItem = r.TipoQuarto;
            dtpCheckin.Value          = r.DataCheckin;
            dtpCheckout.Value         = r.DataCheckout;
            txtValorDiaria.Text       = r.ValorDiaria.ToString();
            txtObservacoes.Text       = r.Observacoes;
            cboStatus.SelectedItem    = r.Status;
        }
    }
}
