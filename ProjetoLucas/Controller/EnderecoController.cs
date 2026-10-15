using System.Data;
using System.Data.SqlClient;
using ProjetoLucas.Models;
using ProjetoLucas.Services;

namespace ProjetoLucas.Controller
{
    public class EnderecoController
    {
        DataBaseService banco = new DataBaseService();

        public int Inserir(Endereco endereco)
        {
            string sql = "INSERT INTO tblEndereco (Logradouro, Numero, Complemento, Bairro, Cidade, Estado, CEP) " +
                         "VALUES (@Logradouro, @Numero, @Complemento, @Bairro, @Cidade, @Estado, @CEP)";

            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@Logradouro", endereco.Logradouro);
            cmd.Parameters.AddWithValue("@Numero", endereco.Numero);
            cmd.Parameters.AddWithValue("@Complemento", endereco.Complemento);
            cmd.Parameters.AddWithValue("@Bairro", endereco.Bairro);
            cmd.Parameters.AddWithValue("@Cidade", endereco.Cidade);
            cmd.Parameters.AddWithValue("@Estado", endereco.Estado);
            cmd.Parameters.AddWithValue("@CEP", endereco.CEP);

            return banco.ExecuteSql(cmd);
        }

        public int Alterar(Endereco endereco)
        {
            string sql = "UPDATE tblEndereco SET Logradouro = @Logradouro, Numero = @Numero, " +
                         "Complemento = @Complemento, Bairro = @Bairro, Cidade = @Cidade, " +
                         "Estado = @Estado, CEP = @CEP WHERE IdEndereco = @IdEndereco";

            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@IdEndereco", endereco.IdEndereco);
            cmd.Parameters.AddWithValue("@Logradouro", endereco.Logradouro);
            cmd.Parameters.AddWithValue("@Numero", endereco.Numero);
            cmd.Parameters.AddWithValue("@Complemento", endereco.Complemento);
            cmd.Parameters.AddWithValue("@Bairro", endereco.Bairro);
            cmd.Parameters.AddWithValue("@Cidade", endereco.Cidade);
            cmd.Parameters.AddWithValue("@Estado", endereco.Estado);
            cmd.Parameters.AddWithValue("@CEP", endereco.CEP);

            return banco.ExecuteSql(cmd);
        }

        public int Excluir(int idEndereco)
        {
            string sql = "DELETE FROM tblEndereco WHERE IdEndereco = @IdEndereco";

            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@IdEndereco", idEndereco);

            return banco.ExecuteSql(cmd);
        }

        public Endereco GetById(int idEndereco)
        {
            string sql = "SELECT * FROM tblEndereco WHERE IdEndereco = @IdEndereco";

            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@IdEndereco", idEndereco);

            DataTable dt = banco.GetDataTable(cmd);

            if (dt.Rows.Count > 0)
            {
                Endereco endereco = new Endereco();
                endereco.IdEndereco  = (int)dt.Rows[0]["IdEndereco"];
                endereco.Logradouro  = dt.Rows[0]["Logradouro"].ToString();
                endereco.Numero      = dt.Rows[0]["Numero"].ToString();
                endereco.Complemento = dt.Rows[0]["Complemento"].ToString();
                endereco.Bairro      = dt.Rows[0]["Bairro"].ToString();
                endereco.Cidade      = dt.Rows[0]["Cidade"].ToString();
                endereco.Estado      = dt.Rows[0]["Estado"].ToString();
                endereco.CEP         = dt.Rows[0]["CEP"].ToString();
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

            SqlCommand cmd = new SqlCommand(sql);
            DataTable dt = banco.GetDataTable(cmd);

            EnderecoCollection lista = new EnderecoCollection();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Endereco endereco = new Endereco();
                endereco.IdEndereco  = (int)dt.Rows[i]["IdEndereco"];
                endereco.Logradouro  = dt.Rows[i]["Logradouro"].ToString();
                endereco.Numero      = dt.Rows[i]["Numero"].ToString();
                endereco.Complemento = dt.Rows[i]["Complemento"].ToString();
                endereco.Bairro      = dt.Rows[i]["Bairro"].ToString();
                endereco.Cidade      = dt.Rows[i]["Cidade"].ToString();
                endereco.Estado      = dt.Rows[i]["Estado"].ToString();
                endereco.CEP         = dt.Rows[i]["CEP"].ToString();
                lista.Add(endereco);
            }

            return lista;
        }

        public EnderecoCollection GetAll()
        {
            return GetByFilters();
        }

        public EnderecoCollection GetEnderecos(string valor)
        {
            return GetByFilters("Logradouro LIKE '%" + valor + "%'");
        }
    }
}
