using System;
using System.Data;
using System.Data.SqlClient;
using ProjetoLucas.Models;
using ProjetoLucas.Services;

namespace ProjetoLucas.Controller
{
    public class ReservaController
    {
        DataBaseService banco = new DataBaseService();

        public int Inserir(Reserva reserva)
        {
            string sql = "INSERT INTO tblReserva (IdHospede, IdFilial, NumeroQuarto, TipoQuarto, DataCheckin, DataCheckout, ValorDiaria, Observacoes, Status) " +
                         "VALUES (@IdHospede, @IdFilial, @NumeroQuarto, @TipoQuarto, @DataCheckin, @DataCheckout, @ValorDiaria, @Observacoes, @Status)";

            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@IdHospede", reserva.IdHospede);
            cmd.Parameters.AddWithValue("@IdFilial", reserva.IdFilial);
            cmd.Parameters.AddWithValue("@NumeroQuarto", reserva.NumeroQuarto);
            cmd.Parameters.AddWithValue("@TipoQuarto", reserva.TipoQuarto);
            cmd.Parameters.AddWithValue("@DataCheckin", reserva.DataCheckin);
            cmd.Parameters.AddWithValue("@DataCheckout", reserva.DataCheckout);
            cmd.Parameters.AddWithValue("@ValorDiaria", reserva.ValorDiaria);
            cmd.Parameters.AddWithValue("@Observacoes", reserva.Observacoes);
            cmd.Parameters.AddWithValue("@Status", reserva.Status);

            return banco.ExecuteSql(cmd);
        }

        public int Alterar(Reserva reserva)
        {
            string sql = "UPDATE tblReserva SET IdHospede = @IdHospede, IdFilial = @IdFilial, " +
                         "NumeroQuarto = @NumeroQuarto, TipoQuarto = @TipoQuarto, DataCheckin = @DataCheckin, " +
                         "DataCheckout = @DataCheckout, ValorDiaria = @ValorDiaria, Observacoes = @Observacoes, " +
                         "Status = @Status WHERE IdReserva = @IdReserva";

            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@IdReserva", reserva.IdReserva);
            cmd.Parameters.AddWithValue("@IdHospede", reserva.IdHospede);
            cmd.Parameters.AddWithValue("@IdFilial", reserva.IdFilial);
            cmd.Parameters.AddWithValue("@NumeroQuarto", reserva.NumeroQuarto);
            cmd.Parameters.AddWithValue("@TipoQuarto", reserva.TipoQuarto);
            cmd.Parameters.AddWithValue("@DataCheckin", reserva.DataCheckin);
            cmd.Parameters.AddWithValue("@DataCheckout", reserva.DataCheckout);
            cmd.Parameters.AddWithValue("@ValorDiaria", reserva.ValorDiaria);
            cmd.Parameters.AddWithValue("@Observacoes", reserva.Observacoes);
            cmd.Parameters.AddWithValue("@Status", reserva.Status);

            return banco.ExecuteSql(cmd);
        }

        public int Excluir(int idReserva)
        {
            string sql = "DELETE FROM tblReserva WHERE IdReserva = @IdReserva";

            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@IdReserva", idReserva);

            return banco.ExecuteSql(cmd);
        }

        public Reserva GetById(int idReserva)
        {
            string sql = "SELECT * FROM tblReserva WHERE IdReserva = @IdReserva";

            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@IdReserva", idReserva);

            DataTable dt = banco.GetDataTable(cmd);

            if (dt.Rows.Count > 0)
            {
                Reserva reserva = new Reserva();
                reserva.IdReserva    = (int)dt.Rows[0]["IdReserva"];
                reserva.IdHospede    = (int)dt.Rows[0]["IdHospede"];
                reserva.IdFilial     = (int)dt.Rows[0]["IdFilial"];
                reserva.NumeroQuarto = (int)dt.Rows[0]["NumeroQuarto"];
                reserva.TipoQuarto   = dt.Rows[0]["TipoQuarto"].ToString();
                reserva.DataCheckin  = Convert.ToDateTime(dt.Rows[0]["DataCheckin"]);
                reserva.DataCheckout = Convert.ToDateTime(dt.Rows[0]["DataCheckout"]);
                reserva.ValorDiaria  = (decimal)dt.Rows[0]["ValorDiaria"];
                reserva.Observacoes  = dt.Rows[0]["Observacoes"].ToString();
                reserva.Status       = dt.Rows[0]["Status"].ToString();
                return reserva;
            }

            return null;
        }

        private ReservaCollection GetByFilters(string filtros = "")
        {
            string sql = "SELECT * FROM tblReserva";

            if (filtros != "")
                sql += " WHERE " + filtros;

            sql += " ORDER BY IdReserva";

            SqlCommand cmd = new SqlCommand(sql);
            DataTable dt = banco.GetDataTable(cmd);

            ReservaCollection lista = new ReservaCollection();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Reserva reserva = new Reserva();
                reserva.IdReserva    = (int)dt.Rows[i]["IdReserva"];
                reserva.IdHospede    = (int)dt.Rows[i]["IdHospede"];
                reserva.IdFilial     = (int)dt.Rows[i]["IdFilial"];
                reserva.NumeroQuarto = (int)dt.Rows[i]["NumeroQuarto"];
                reserva.TipoQuarto   = dt.Rows[i]["TipoQuarto"].ToString();
                reserva.DataCheckin  = Convert.ToDateTime(dt.Rows[i]["DataCheckin"]);
                reserva.DataCheckout = Convert.ToDateTime(dt.Rows[i]["DataCheckout"]);
                reserva.ValorDiaria  = (decimal)dt.Rows[i]["ValorDiaria"];
                reserva.Observacoes  = dt.Rows[i]["Observacoes"].ToString();
                reserva.Status       = dt.Rows[i]["Status"].ToString();
                lista.Add(reserva);
            }

            return lista;
        }

        public ReservaCollection GetAll()
        {
            return GetByFilters();
        }

        public ReservaCollection GetReservas(string valor)
        {
            return GetByFilters("Status LIKE '%" + valor + "%'");
        }

        // Retorna DataTable com JOIN para mostrar nome do hospede e hotel no grid
        public DataTable GetDataTableAll()
        {
            string sql = "SELECT r.IdReserva, h.Nome AS Hospede, f.RazaoSocial AS Hotel, " +
                         "r.NumeroQuarto, r.TipoQuarto, r.DataCheckin, r.DataCheckout, " +
                         "r.ValorDiaria, r.Status, r.IdHospede, r.IdFilial " +
                         "FROM tblReserva r " +
                         "INNER JOIN tblHospede h ON r.IdHospede = h.IdHospede " +
                         "INNER JOIN tblHotel f ON r.IdFilial = f.IdFilial " +
                         "ORDER BY r.DataCheckin DESC";

            SqlCommand cmd = new SqlCommand(sql);
            return banco.GetDataTable(cmd);
        }
    }
}
