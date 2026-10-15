using System;
using System.Data;
using System.Data.SqlClient;
using ProjetoLucas.Models;
using ProjetoLucas.Services;

namespace ProjetoLucas.Controller
{
    public class HospedeController
    {
        private DataBaseService _database = new DataBaseService();

        public int Inserir(Hospede hospede)
        {
            string sql = "INSERT INTO tblHospede (Nome, CPF, RG, Telefone, Email, DataNascimento, Nacionalidade, Ativo) " +
                         "VALUES (@Nome, @CPF, @RG, @Telefone, @Email, @DataNascimento, @Nacionalidade, @Ativo)";

            SqlCommand command = new SqlCommand(sql);
            command.Parameters.AddWithValue("@Nome", hospede.Nome);
            command.Parameters.AddWithValue("@CPF", hospede.CPF);
            command.Parameters.AddWithValue("@RG", hospede.RG ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Telefone", hospede.Telefone ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Email", hospede.Email ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@DataNascimento", hospede.DataNascimento);
            command.Parameters.AddWithValue("@Nacionalidade", hospede.Nacionalidade);
            command.Parameters.AddWithValue("@Ativo", hospede.Ativo);

            return _database.ExecuteSql(command);
        }

        public int Alterar(Hospede hospede)
        {
            string sql = "UPDATE tblHospede SET Nome = @Nome, CPF = @CPF, RG = @RG, Telefone = @Telefone, " +
                         "Email = @Email, DataNascimento = @DataNascimento, Nacionalidade = @Nacionalidade, " +
                         "Ativo = @Ativo WHERE IdHospede = @IdHospede";

            SqlCommand command = new SqlCommand(sql);
            command.Parameters.AddWithValue("@IdHospede", hospede.IdHospede);
            command.Parameters.AddWithValue("@Nome", hospede.Nome);
            command.Parameters.AddWithValue("@CPF", hospede.CPF);
            command.Parameters.AddWithValue("@RG", hospede.RG ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Telefone", hospede.Telefone ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Email", hospede.Email ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@DataNascimento", hospede.DataNascimento);
            command.Parameters.AddWithValue("@Nacionalidade", hospede.Nacionalidade);
            command.Parameters.AddWithValue("@Ativo", hospede.Ativo);

            return _database.ExecuteSql(command);
        }

        public int Excluir(int idHospede)
        {
            string sql = "DELETE FROM tblHospede WHERE IdHospede = @IdHospede";

            SqlCommand command = new SqlCommand(sql);
            command.Parameters.AddWithValue("@IdHospede", idHospede);

            return _database.ExecuteSql(command);
        }

        public Hospede GetById(int idHospede)
        {
            string sql = "SELECT * FROM tblHospede WHERE IdHospede = @IdHospede";

            SqlCommand command = new SqlCommand(sql);
            command.Parameters.AddWithValue("@IdHospede", idHospede);

            DataTable dataTable = _database.GetDataTable(command);

            if (dataTable.Rows.Count > 0)
            {
                Hospede hospede = new Hospede();
                hospede.IdHospede = (int)dataTable.Rows[0]["IdHospede"];
                hospede.Nome = dataTable.Rows[0]["Nome"].ToString();
                hospede.CPF = dataTable.Rows[0]["CPF"].ToString();
                hospede.RG = dataTable.Rows[0]["RG"].ToString();
                hospede.Telefone = dataTable.Rows[0]["Telefone"].ToString();
                hospede.Email = dataTable.Rows[0]["Email"].ToString();
                hospede.DataNascimento = Convert.ToDateTime(dataTable.Rows[0]["DataNascimento"]);
                hospede.Nacionalidade = dataTable.Rows[0]["Nacionalidade"].ToString();
                hospede.Ativo = Convert.ToBoolean(dataTable.Rows[0]["Ativo"]);
                return hospede;
            }

            return null;
        }

        private HospedeCollection GetByFilters(string filtros = "")
        {
            string sql = "SELECT * FROM tblHospede";

            if (filtros != "")
                sql += " WHERE " + filtros;

            sql += " ORDER BY Nome";

            SqlCommand command = new SqlCommand(sql);
            DataTable dataTable = _database.GetDataTable(command);
            HospedeCollection hospedes = new HospedeCollection();

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Hospede hospede = new Hospede();
                hospede.IdHospede = (int)dataTable.Rows[i]["IdHospede"];
                hospede.Nome = dataTable.Rows[i]["Nome"].ToString();
                hospede.CPF = dataTable.Rows[i]["CPF"].ToString();
                hospede.RG = dataTable.Rows[i]["RG"].ToString();
                hospede.Telefone = dataTable.Rows[i]["Telefone"].ToString();
                hospede.Email = dataTable.Rows[i]["Email"].ToString();
                hospede.DataNascimento = Convert.ToDateTime(dataTable.Rows[i]["DataNascimento"]);
                hospede.Nacionalidade = dataTable.Rows[i]["Nacionalidade"].ToString();
                hospede.Ativo = Convert.ToBoolean(dataTable.Rows[i]["Ativo"]);
                hospedes.Add(hospede);
            }

            return hospedes;
        }

        public HospedeCollection GetAll()
        {
            return GetByFilters();
        }

        public HospedeCollection GetHospedes(string value)
        {
            string sql = "SELECT * FROM tblHospede WHERE Nome LIKE @valor ORDER BY Nome";
            SqlCommand command = new SqlCommand(sql);
            command.Parameters.AddWithValue("@valor", "%" + value + "%");

            DataTable dataTable = _database.GetDataTable(command);
            HospedeCollection hospedes = new HospedeCollection();

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Hospede hospede = new Hospede();
                hospede.IdHospede      = (int)dataTable.Rows[i]["IdHospede"];
                hospede.Nome           = dataTable.Rows[i]["Nome"].ToString();
                hospede.CPF            = dataTable.Rows[i]["CPF"].ToString();
                hospede.RG             = dataTable.Rows[i]["RG"].ToString();
                hospede.Telefone       = dataTable.Rows[i]["Telefone"].ToString();
                hospede.Email          = dataTable.Rows[i]["Email"].ToString();
                hospede.DataNascimento = Convert.ToDateTime(dataTable.Rows[i]["DataNascimento"]);
                hospede.Nacionalidade  = dataTable.Rows[i]["Nacionalidade"].ToString();
                hospede.Ativo          = Convert.ToBoolean(dataTable.Rows[i]["Ativo"]);
                hospedes.Add(hospede);
            }

            return hospedes;
        }
    }
}
