using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Windows.Forms;
using ProjetoLucas.Models;
using ProjetoLucas.Services;

namespace ProjetoLucas.Controller
{
    public class FilialController
    {
        DataBaseService banco = new DataBaseService();

        public int Inserir(Filial filial)
        {
            string sql = "INSERT INTO tblHotel (RazaoSocial, CNPJ, Telefone, Email, Avaliacao, IdEndereco, Ativo) " +
                         "VALUES (@RazaoSocial, @CNPJ, @Telefone, @Email, @Avaliacao, @IdEndereco, @Ativo)";

            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@RazaoSocial", filial.RazaoSocial);
            cmd.Parameters.AddWithValue("@CNPJ", filial.CNPJ);
            cmd.Parameters.AddWithValue("@Telefone", filial.Telefone);
            cmd.Parameters.AddWithValue("@Email", filial.Email);
            cmd.Parameters.AddWithValue("@Avaliacao", filial.Avaliacao);
            cmd.Parameters.AddWithValue("@IdEndereco", filial.IdEndereco);
            cmd.Parameters.AddWithValue("@Ativo", filial.Ativo);

            return banco.ExecuteSql(cmd);
        }

        public int Alterar(Filial filial)
        {
            string sql = "UPDATE tblHotel SET RazaoSocial = @RazaoSocial, CNPJ = @CNPJ, " +
                         "Telefone = @Telefone, Email = @Email, Avaliacao = @Avaliacao, " +
                         "IdEndereco = @IdEndereco, Ativo = @Ativo WHERE IdFilial = @IdFilial";

            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@IdFilial", filial.idFilial);
            cmd.Parameters.AddWithValue("@RazaoSocial", filial.RazaoSocial);
            cmd.Parameters.AddWithValue("@CNPJ", filial.CNPJ);
            cmd.Parameters.AddWithValue("@Telefone", filial.Telefone);
            cmd.Parameters.AddWithValue("@Email", filial.Email);
            cmd.Parameters.AddWithValue("@Avaliacao", filial.Avaliacao);
            cmd.Parameters.AddWithValue("@IdEndereco", filial.IdEndereco);
            cmd.Parameters.AddWithValue("@Ativo", filial.Ativo);

            return banco.ExecuteSql(cmd);
        }

        public int Excluir(int idFilial)
        {
            string sql = "DELETE FROM tblHotel WHERE IdFilial = @IdFilial";

            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@IdFilial", idFilial);
            return banco.ExecuteSql(cmd);

        }

        public Filial GetById(int idFilial)
        {
            string sql = "SELECT * FROM tblHotel WHERE IdFilial = @IdFilial";

            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@IdFilial", idFilial);

            DataTable dt = banco.GetDataTable(cmd);

            if (dt.Rows.Count > 0)
            {
                Filial filial = new Filial();
                filial.idFilial    = (int)dt.Rows[0]["IdFilial"];
                filial.RazaoSocial = dt.Rows[0]["RazaoSocial"].ToString();
                filial.CNPJ        = dt.Rows[0]["CNPJ"].ToString();
                filial.Telefone    = dt.Rows[0]["Telefone"].ToString();
                filial.Email       = dt.Rows[0]["Email"].ToString();
                filial.Avaliacao   = (decimal)dt.Rows[0]["Avaliacao"];
                filial.IdEndereco  = dt.Rows[0]["IdEndereco"] == DBNull.Value ? 0 : (int)dt.Rows[0]["IdEndereco"];
                filial.Ativo       = Convert.ToBoolean(dt.Rows[0]["Ativo"]);
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

            SqlCommand cmd = new SqlCommand(sql);
            DataTable dt = banco.GetDataTable(cmd);

            FilialColletion lista = new FilialColletion();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Filial filial = new Filial();
                filial.idFilial    = (int)dt.Rows[i]["IdFilial"];
                filial.RazaoSocial = dt.Rows[i]["RazaoSocial"].ToString();
                filial.CNPJ        = dt.Rows[i]["CNPJ"].ToString();
                filial.Telefone    = dt.Rows[i]["Telefone"].ToString();
                filial.Email       = dt.Rows[i]["Email"].ToString();
                filial.Avaliacao   = (decimal)dt.Rows[i]["Avaliacao"];
                filial.IdEndereco  = dt.Rows[i]["IdEndereco"] == DBNull.Value ? 0 : (int)dt.Rows[i]["IdEndereco"];
                filial.Ativo       = Convert.ToBoolean(dt.Rows[i]["Ativo"]);
                lista.Add(filial);
            }

            return lista;
        }

        public FilialColletion GetAll()
        {
            return GetByFilters();
        }

        public FilialColletion GetFilials(string valor)
        {
            return GetByFilters("RazaoSocial LIKE '%" + valor + "%'");
        }
    }
}
