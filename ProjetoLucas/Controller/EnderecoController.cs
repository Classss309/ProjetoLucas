using System;
using System.Data;
using System.Data.SqlClient;
using ProjetoLucas.Models;
using ProjetoLucas.Services;

namespace ProjetoLucas.Controller
{
    public class EnderecoController
    {
        private DataBaseService _database = new DataBaseService();

        public int Inserir(Endereco endereco)
        {
            string sql = "INSERT INTO tblEndereco (Logradouro, Numero, Complemento, Bairro, Cidade, Estado, CEP) " +
                         "VALUES (@Logradouro, @Numero, @Complemento, @Bairro, @Cidade, @Estado, @CEP)";

            SqlCommand command = new SqlCommand(sql);
            command.Parameters.AddWithValue("@Logradouro", endereco.Logradouro);
            command.Parameters.AddWithValue("@Numero", endereco.Numero);
            command.Parameters.AddWithValue("@Complemento", endereco.Complemento ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Bairro", endereco.Bairro);
            command.Parameters.AddWithValue("@Cidade", endereco.Cidade);
            command.Parameters.AddWithValue("@Estado", endereco.Estado);
            command.Parameters.AddWithValue("@CEP", endereco.CEP);

            return _database.ExecuteSql(command);
        }

        public int Alterar(Endereco endereco)
        {
            string sql = "UPDATE tblEndereco SET Logradouro = @Logradouro, Numero = @Numero, " +
                         "Complemento = @Complemento, Bairro = @Bairro, Cidade = @Cidade, " +
                         "Estado = @Estado, CEP = @CEP WHERE IdEndereco = @IdEndereco";

            SqlCommand command = new SqlCommand(sql);
            command.Parameters.AddWithValue("@IdEndereco", endereco.IdEndereco);
            command.Parameters.AddWithValue("@Logradouro", endereco.Logradouro);
            command.Parameters.AddWithValue("@Numero", endereco.Numero);
            command.Parameters.AddWithValue("@Complemento", endereco.Complemento ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Bairro", endereco.Bairro);
            command.Parameters.AddWithValue("@Cidade", endereco.Cidade);
            command.Parameters.AddWithValue("@Estado", endereco.Estado);
            command.Parameters.AddWithValue("@CEP", endereco.CEP);

            return _database.ExecuteSql(command);
        }

        public int Excluir(int idEndereco)
        {
            string sql = "DELETE FROM tblEndereco WHERE IdEndereco = @IdEndereco";

            SqlCommand command = new SqlCommand(sql);
            command.Parameters.AddWithValue("@IdEndereco", idEndereco);

            return _database.ExecuteSql(command);
        }

        public Endereco GetById(int idEndereco)
        {
            string sql = "SELECT * FROM tblEndereco WHERE IdEndereco = @IdEndereco";

            SqlCommand command = new SqlCommand(sql);
            command.Parameters.AddWithValue("@IdEndereco", idEndereco);

            DataTable dataTable = _database.GetDataTable(command);

            if (dataTable.Rows.Count > 0)
            {
                Endereco endereco = new Endereco();
                endereco.IdEndereco = (int)dataTable.Rows[0]["IdEndereco"];
                endereco.Logradouro = dataTable.Rows[0]["Logradouro"].ToString();
                endereco.Numero = dataTable.Rows[0]["Numero"].ToString();
                endereco.Complemento = dataTable.Rows[0]["Complemento"].ToString();
                endereco.Bairro = dataTable.Rows[0]["Bairro"].ToString();
                endereco.Cidade = dataTable.Rows[0]["Cidade"].ToString();
                endereco.Estado = dataTable.Rows[0]["Estado"].ToString();
                endereco.CEP = dataTable.Rows[0]["CEP"].ToString();
                return endereco;
            }

            return null;
        }

        private EnderecoCollection GetByFilters(string filtros = "")
        {
            string sql = "SELECT * FROM tblEndereco";

            if (filtros != "")
                sql += " WHERE " + filtros;

            sql += " ORDER BY Logradouro";

            SqlCommand command = new SqlCommand(sql);
            DataTable dataTable = _database.GetDataTable(command);
            EnderecoCollection enderecos = new EnderecoCollection();

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Endereco endereco = new Endereco();
                endereco.IdEndereco = (int)dataTable.Rows[i]["IdEndereco"];
                endereco.Logradouro = dataTable.Rows[i]["Logradouro"].ToString();
                endereco.Numero = dataTable.Rows[i]["Numero"].ToString();
                endereco.Complemento = dataTable.Rows[i]["Complemento"].ToString();
                endereco.Bairro = dataTable.Rows[i]["Bairro"].ToString();
                endereco.Cidade = dataTable.Rows[i]["Cidade"].ToString();
                endereco.Estado = dataTable.Rows[i]["Estado"].ToString();
                endereco.CEP = dataTable.Rows[i]["CEP"].ToString();
                enderecos.Add(endereco);
            }

            return enderecos;
        }

        public EnderecoCollection GetAll()
        {
            return GetByFilters();
        }

        public EnderecoCollection GetEnderecos(string value)
        {
            return GetByFilters("Logradouro LIKE '%" + value + "%'");
        }
    }
}
