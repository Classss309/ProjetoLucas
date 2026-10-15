using System;
using System.Data;
using System.Data.SqlClient;
using ProjetoLucas.Models;
using ProjetoLucas.Services;

namespace ProjetoLucas.Controller
{
    public class FilialController
    {
        private DataBaseService _database = new DataBaseService();

        public int Inserir(Filial filial)
        {
            string sql = "INSERT INTO tblHotel (RazaoSocial, CNPJ, Telefone, Email, Avaliacao, IdEndereco, Ativo) " +
                         "VALUES (@RazaoSocial, @CNPJ, @Telefone, @Email, @Avaliacao, @IdEndereco, @Ativo)";

            SqlCommand command = new SqlCommand(sql);
            command.Parameters.AddWithValue("@RazaoSocial", filial.RazaoSocial);
            command.Parameters.AddWithValue("@CNPJ", filial.CNPJ);
            command.Parameters.AddWithValue("@Telefone", filial.Telefone);
            command.Parameters.AddWithValue("@Email", filial.Email);
            command.Parameters.AddWithValue("@Avaliacao", filial.Avaliacao);
            command.Parameters.AddWithValue("@IdEndereco", filial.IdEndereco);
            command.Parameters.AddWithValue("@Ativo", filial.Ativo);

            return _database.ExecuteSql(command);
        }

        public int Alterar(Filial filial)
        {
            string sql = "UPDATE tblHotel SET RazaoSocial = @RazaoSocial, CNPJ = @CNPJ, Telefone = @Telefone, " +
                         "Email = @Email, Avaliacao = @Avaliacao, IdEndereco = @IdEndereco, Ativo = @Ativo " +
                         "WHERE IdFilial = @idFilial";

            SqlCommand command = new SqlCommand(sql);
            command.Parameters.AddWithValue("@idFilial", filial.idFilial);
            command.Parameters.AddWithValue("@RazaoSocial", filial.RazaoSocial);
            command.Parameters.AddWithValue("@CNPJ", filial.CNPJ);
            command.Parameters.AddWithValue("@Telefone", filial.Telefone);
            command.Parameters.AddWithValue("@Email", filial.Email);
            command.Parameters.AddWithValue("@Avaliacao", filial.Avaliacao);
            command.Parameters.AddWithValue("@IdEndereco", filial.IdEndereco);
            command.Parameters.AddWithValue("@Ativo", filial.Ativo);

            return _database.ExecuteSql(command);
        }

        public int Excluir(int idFilial)
        {
            string sql = "DELETE FROM tblHotel WHERE IdFilial = @idFilial";

            SqlCommand command = new SqlCommand(sql);
            command.Parameters.AddWithValue("@idFilial", idFilial);

            return _database.ExecuteSql(command);
        }

        public Filial GetById(int idFilial)
        {
            string sql = "SELECT * FROM tblHotel WHERE IdFilial = @idFilial";

            SqlCommand command = new SqlCommand(sql);
            command.Parameters.AddWithValue("@idFilial", idFilial);

            DataTable dataTable = _database.GetDataTable(command);

            if (dataTable.Rows.Count > 0)
            {
                Filial filial = new Filial();
                filial.idFilial = (int)dataTable.Rows[0]["IdFilial"];
                filial.RazaoSocial = dataTable.Rows[0]["RazaoSocial"].ToString();
                filial.CNPJ = dataTable.Rows[0]["CNPJ"].ToString();
                filial.Telefone = dataTable.Rows[0]["Telefone"].ToString();
                filial.Email = dataTable.Rows[0]["Email"].ToString();
                filial.Avaliacao = (decimal)dataTable.Rows[0]["Avaliacao"];
                filial.IdEndereco = dataTable.Rows[0]["IdEndereco"] == DBNull.Value ? 0 : (int)dataTable.Rows[0]["IdEndereco"];
                filial.Ativo = Convert.ToBoolean(dataTable.Rows[0]["Ativo"]);
                return filial;
            }

            return null;
        }

        private FilialColletion GetByFilters(string filtros = "")
        {
            string sql = "SELECT * FROM tblHotel";

            if (filtros != "")
                sql += " WHERE " + filtros;

            sql += " ORDER BY IdFilial";

            SqlCommand command = new SqlCommand(sql);
            DataTable dataTable = _database.GetDataTable(command);
            FilialColletion filiais = new FilialColletion();

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Filial filial = new Filial();
                filial.idFilial = (int)dataTable.Rows[i]["IdFilial"];
                filial.RazaoSocial = dataTable.Rows[i]["RazaoSocial"].ToString();
                filial.CNPJ = dataTable.Rows[i]["CNPJ"].ToString();
                filial.Telefone = dataTable.Rows[i]["Telefone"].ToString();
                filial.Email = dataTable.Rows[i]["Email"].ToString();
                filial.Avaliacao = (decimal)dataTable.Rows[i]["Avaliacao"];
                filial.IdEndereco = dataTable.Rows[i]["IdEndereco"] == DBNull.Value ? 0 : (int)dataTable.Rows[i]["IdEndereco"];
                filial.Ativo = Convert.ToBoolean(dataTable.Rows[i]["Ativo"]);
                filiais.Add(filial);
            }

            return filiais;
        }

        public FilialColletion GetAll()
        {
            return GetByFilters();
        }

        public FilialColletion GetFilials(string value)
        {
            return GetByFilters("RazaoSocial LIKE '%" + value + "%'");
        }
    }
}
