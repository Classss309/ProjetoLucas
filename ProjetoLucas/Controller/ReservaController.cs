using System;
using System.Data;
using System.Data.SqlClient;
using ProjetoLucas.Models;
using ProjetoLucas.Services;

namespace ProjetoLucas.Controller
{
    public class ReservaController
    {
        private DataBaseService _database = new DataBaseService();

        public int Inserir(Reserva reserva)
        {
            string sql = "INSERT INTO tblReserva (IdHospede, IdFilial, NumeroQuarto, TipoQuarto, DataCheckin, DataCheckout, ValorDiaria, Observacoes, Status) " +
                         "VALUES (@IdHospede, @IdFilial, @NumeroQuarto, @TipoQuarto, @DataCheckin, @DataCheckout, @ValorDiaria, @Observacoes, @Status)";

            SqlCommand command = new SqlCommand(sql);
            command.Parameters.AddWithValue("@IdHospede", reserva.IdHospede);
            command.Parameters.AddWithValue("@IdFilial", reserva.IdFilial);
            command.Parameters.AddWithValue("@NumeroQuarto", reserva.NumeroQuarto);
            command.Parameters.AddWithValue("@TipoQuarto", reserva.TipoQuarto);
            command.Parameters.AddWithValue("@DataCheckin", reserva.DataCheckin);
            command.Parameters.AddWithValue("@DataCheckout", reserva.DataCheckout);
            command.Parameters.AddWithValue("@ValorDiaria", reserva.ValorDiaria);
            command.Parameters.AddWithValue("@Observacoes", reserva.Observacoes ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Status", reserva.Status);

            return _database.ExecuteSql(command);
        }

        public int Alterar(Reserva reserva)
        {
            string sql = "UPDATE tblReserva SET IdHospede = @IdHospede, IdFilial = @IdFilial, " +
                         "NumeroQuarto = @NumeroQuarto, TipoQuarto = @TipoQuarto, DataCheckin = @DataCheckin, " +
                         "DataCheckout = @DataCheckout, ValorDiaria = @ValorDiaria, Observacoes = @Observacoes, " +
                         "Status = @Status WHERE IdReserva = @IdReserva";

            SqlCommand command = new SqlCommand(sql);
            command.Parameters.AddWithValue("@IdReserva", reserva.IdReserva);
            command.Parameters.AddWithValue("@IdHospede", reserva.IdHospede);
            command.Parameters.AddWithValue("@IdFilial", reserva.IdFilial);
            command.Parameters.AddWithValue("@NumeroQuarto", reserva.NumeroQuarto);
            command.Parameters.AddWithValue("@TipoQuarto", reserva.TipoQuarto);
            command.Parameters.AddWithValue("@DataCheckin", reserva.DataCheckin);
            command.Parameters.AddWithValue("@DataCheckout", reserva.DataCheckout);
            command.Parameters.AddWithValue("@ValorDiaria", reserva.ValorDiaria);
            command.Parameters.AddWithValue("@Observacoes", reserva.Observacoes ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Status", reserva.Status);

            return _database.ExecuteSql(command);
        }

        public int Excluir(int idReserva)
        {
            string sql = "DELETE FROM tblReserva WHERE IdReserva = @IdReserva";

            SqlCommand command = new SqlCommand(sql);
            command.Parameters.AddWithValue("@IdReserva", idReserva);

            return _database.ExecuteSql(command);
        }

        public Reserva GetById(int idReserva)
        {
            string sql = "SELECT r.*, h.Nome AS NomeHospede, f.RazaoSocial " +
                         "FROM tblReserva r " +
                         "INNER JOIN tblHospede h ON r.IdHospede = h.IdHospede " +
                         "INNER JOIN tblHotel f ON r.IdFilial = f.IdFilial " +
                         "WHERE r.IdReserva = @IdReserva";

            SqlCommand command = new SqlCommand(sql);
            command.Parameters.AddWithValue("@IdReserva", idReserva);

            DataTable dataTable = _database.GetDataTable(command);

            if (dataTable.Rows.Count > 0)
            {
                Reserva reserva = new Reserva();
                reserva.IdReserva = (int)dataTable.Rows[0]["IdReserva"];
                reserva.IdHospede = (int)dataTable.Rows[0]["IdHospede"];
                reserva.IdFilial = (int)dataTable.Rows[0]["IdFilial"];
                reserva.NumeroQuarto = (int)dataTable.Rows[0]["NumeroQuarto"];
                reserva.TipoQuarto = dataTable.Rows[0]["TipoQuarto"].ToString();
                reserva.DataCheckin = Convert.ToDateTime(dataTable.Rows[0]["DataCheckin"]);
                reserva.DataCheckout = Convert.ToDateTime(dataTable.Rows[0]["DataCheckout"]);
                reserva.ValorDiaria = (decimal)dataTable.Rows[0]["ValorDiaria"];
                reserva.Observacoes = dataTable.Rows[0]["Observacoes"].ToString();
                reserva.Status = dataTable.Rows[0]["Status"].ToString();
                return reserva;
            }

            return null;
        }

        private ReservaCollection GetByFilters(string filtros = "")
        {
            string sql = "SELECT r.*, h.Nome AS NomeHospede, f.RazaoSocial " +
                         "FROM tblReserva r " +
                         "INNER JOIN tblHospede h ON r.IdHospede = h.IdHospede " +
                         "INNER JOIN tblHotel f ON r.IdFilial = f.IdFilial";

            if (filtros != "")
                sql += " WHERE " + filtros;

            sql += " ORDER BY r.IdReserva";

            SqlCommand command = new SqlCommand(sql);
            DataTable dataTable = _database.GetDataTable(command);
            ReservaCollection reservas = new ReservaCollection();

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Reserva reserva = new Reserva();
                reserva.IdReserva = (int)dataTable.Rows[i]["IdReserva"];
                reserva.IdHospede = (int)dataTable.Rows[i]["IdHospede"];
                reserva.IdFilial = (int)dataTable.Rows[i]["IdFilial"];
                reserva.NumeroQuarto = (int)dataTable.Rows[i]["NumeroQuarto"];
                reserva.TipoQuarto = dataTable.Rows[i]["TipoQuarto"].ToString();
                reserva.DataCheckin = Convert.ToDateTime(dataTable.Rows[i]["DataCheckin"]);
                reserva.DataCheckout = Convert.ToDateTime(dataTable.Rows[i]["DataCheckout"]);
                reserva.ValorDiaria = (decimal)dataTable.Rows[i]["ValorDiaria"];
                reserva.Observacoes = dataTable.Rows[i]["Observacoes"].ToString();
                reserva.Status = dataTable.Rows[i]["Status"].ToString();
                reservas.Add(reserva);
            }

            return reservas;
        }

        public ReservaCollection GetAll()
        {
            return GetByFilters();
        }

        public ReservaCollection GetReservas(string value)
        {
            return GetByFilters("r.Status LIKE '%" + value + "%'");
        }

        public DataTable GetDataTableAll()
        {
            string sql = "SELECT r.IdReserva, r.NumeroQuarto, r.TipoQuarto, r.DataCheckin, r.DataCheckout, " +
                         "r.ValorDiaria, r.Status, r.Observacoes, r.IdHospede, r.IdFilial, " +
                         "h.Nome AS NomeHospede, f.RazaoSocial " +
                         "FROM tblReserva r " +
                         "INNER JOIN tblHospede h ON r.IdHospede = h.IdHospede " +
                         "INNER JOIN tblHotel f ON r.IdFilial = f.IdFilial " +
                         "ORDER BY r.DataCheckin DESC";

            SqlCommand command = new SqlCommand(sql);
            return _database.GetDataTable(command);
        }
    }
}
