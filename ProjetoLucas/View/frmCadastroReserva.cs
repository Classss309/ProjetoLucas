using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using ProjetoLucas.Controller;
using ProjetoLucas.Models;

namespace ProjetoLucas.View
{
    public partial class frmCadastroReserva : Form
    {
        private int _idReservaAtual = 0;
        private ReservaController _reservaCtrl = new ReservaController();
        private HospedeController _hospedeCtrl = new HospedeController();
        private FilialController _filialCtrl = new FilialController();

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
            try
            {
                HospedeCollection hospedes = _hospedeCtrl.GetAll();
                var itens = new List<object>();
                foreach (Hospede h in hospedes)
                {
                    itens.Add(new { Text = h.Nome + " – " + h.CPF, Value = h.IdHospede });
                }
                cboHospede.DataSource = itens;
                cboHospede.DisplayMember = "Text";
                cboHospede.ValueMember = "Value";
                if (itens.Count == 0)
                    cboHospede.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar hóspedes: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarComboFiliais()
        {
            try
            {
                FilialColletion filiais = _filialCtrl.GetAll();
                var itens = new List<object>();
                foreach (Filial f in filiais)
                {
                    itens.Add(new { Text = f.RazaoSocial, Value = f.idFilial });
                }
                cboFilial.DataSource = itens;
                cboFilial.DisplayMember = "Text";
                cboFilial.ValueMember = "Value";
                if (itens.Count == 0)
                    cboFilial.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar filiais: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarGrid()
        {
            try
            {
                dgvReservas.DataSource = _reservaCtrl.GetDataTableAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar reservas: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparCampos()
        {
            _idReservaAtual = 0;
            if (cboHospede.Items.Count > 0) cboHospede.SelectedIndex = 0;
            if (cboFilial.Items.Count > 0) cboFilial.SelectedIndex = 0;
            nudNumeroQuarto.Value = 1;
            if (cboTipoQuarto.Items.Count > 0) cboTipoQuarto.SelectedIndex = 0;
            dtpCheckin.Value = DateTime.Today;
            dtpCheckout.Value = DateTime.Today.AddDays(1);
            txtValorDiaria.Text = string.Empty;
            txtObservacoes.Text = string.Empty;
            if (cboStatus.Items.Count > 0) cboStatus.SelectedIndex = 0;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (cboHospede.SelectedValue == null || cboFilial.SelectedValue == null)
            {
                MessageBox.Show("Selecione o hóspede e a filial.", "Validação",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal valorDiaria;
            if (!decimal.TryParse(txtValorDiaria.Text.Trim(), out valorDiaria))
            {
                MessageBox.Show("Valor da diária inválido.", "Validação",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Reserva reserva = new Reserva();
                reserva.IdReserva = _idReservaAtual;
                reserva.IdHospede = Convert.ToInt32(cboHospede.SelectedValue);
                reserva.IdFilial = Convert.ToInt32(cboFilial.SelectedValue);
                reserva.NumeroQuarto = (int)nudNumeroQuarto.Value;
                reserva.TipoQuarto = cboTipoQuarto.SelectedItem?.ToString() ?? string.Empty;
                reserva.DataCheckin = dtpCheckin.Value;
                reserva.DataCheckout = dtpCheckout.Value;
                reserva.ValorDiaria = valorDiaria;
                reserva.Observacoes = txtObservacoes.Text.Trim();
                reserva.Status = cboStatus.SelectedItem?.ToString() ?? "Ativa";

                if (_idReservaAtual == 0)
                    _reservaCtrl.Inserir(reserva);
                else
                    _reservaCtrl.Alterar(reserva);

                MessageBox.Show("Reserva salva com sucesso!", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();
                CarregarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar reserva: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (_idReservaAtual == 0)
            {
                MessageBox.Show("Selecione uma reserva para excluir.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Deseja realmente excluir esta reserva?", "Confirmação",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    _reservaCtrl.Excluir(_idReservaAtual);
                    MessageBox.Show("Reserva excluída com sucesso!", "Sucesso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCampos();
                    CarregarGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao excluir reserva: " + ex.Message, "Erro",
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
                    dgvReservas.DataSource = _reservaCtrl.GetReservas(txtBusca.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar reservas: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvReservas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                DataGridViewRow row = dgvReservas.Rows[e.RowIndex];
                _idReservaAtual = Convert.ToInt32(row.Cells["IdReserva"].Value);

                Reserva reserva = _reservaCtrl.GetById(_idReservaAtual);
                if (reserva == null) return;

                try { cboHospede.SelectedValue = reserva.IdHospede; } catch { }
                try { cboFilial.SelectedValue = reserva.IdFilial; } catch { }
                nudNumeroQuarto.Value = reserva.NumeroQuarto;
                cboTipoQuarto.SelectedItem = reserva.TipoQuarto;
                dtpCheckin.Value = reserva.DataCheckin;
                dtpCheckout.Value = reserva.DataCheckout;
                txtValorDiaria.Text = reserva.ValorDiaria.ToString("F2");
                txtObservacoes.Text = reserva.Observacoes;
                cboStatus.SelectedItem = reserva.Status;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao selecionar reserva: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
