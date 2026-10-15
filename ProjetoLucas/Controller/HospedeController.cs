using System;
using System.Data;
using System.Data.SqlClient;
using ProjetoLucas.Models;
using ProjetoLucas.Services;

namespace ProjetoLucas.Controller
{
    public class HospedeController
    {
        DataBaseService banco = new DataBaseService();

        public int Inserir(Hospede hospede)
        {
            string sql = "INSERT INTO tblHospede (Nome, CPF, RG, Telefone, Email, DataNascimento, Nacionalidade, Ativo) " +
                         "VALUES (@Nome, @CPF, @RG, @Telefone, @Email, @DataNascimento, @Nacionalidade, @Ativo)";

            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@Nome", hospede.Nome);
            cmd.Parameters.AddWithValue("@CPF", hospede.CPF);
            cmd.Parameters.AddWithValue("@RG", hospede.RG);
            cmd.Parameters.AddWithValue("@Telefone", hospede.Telefone);
            cmd.Parameters.AddWithValue("@Email", hospede.Email);
            cmd.Parameters.AddWithValue("@DataNascimento", hospede.DataNascimento);
            cmd.Parameters.AddWithValue("@Nacionalidade", hospede.Nacionalidade);
            cmd.Parameters.AddWithValue("@Ativo", hospede.Ativo);

            return banco.ExecuteSql(cmd);
        }

        public int Alterar(Hospede hospede)
        {
            string sql = "UPDATE tblHospede SET Nome = @Nome, CPF = @CPF, RG = @RG, " +
                         "Telefone = @Telefone, Email = @Email, DataNascimento = @DataNascimento, " +
                         "Nacionalidade = @Nacionalidade, Ativo = @Ativo WHERE IdHospede = @IdHospede";

            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@IdHospede", hospede.IdHospede);
            cmd.Parameters.AddWithValue("@Nome", hospede.Nome);
            cmd.Parameters.AddWithValue("@CPF", hospede.CPF);
            cmd.Parameters.AddWithValue("@RG", hospede.RG);
            cmd.Parameters.AddWithValue("@Telefone", hospede.Telefone);
            cmd.Parameters.AddWithValue("@Email", hospede.Email);
            cmd.Parameters.AddWithValue("@DataNascimento", hospede.DataNascimento);
            cmd.Parameters.AddWithValue("@Nacionalidade", hospede.Nacionalidade);
            cmd.Parameters.AddWithValue("@Ativo", hospede.Ativo);

            return banco.ExecuteSql(cmd);
        }

        public int Excluir(int idHospede)
        {
            string sql = "DELETE FROM tblHospede WHERE IdHospede = @IdHospede";

            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@IdHospede", idHospede);
            return banco.ExecuteSql(cmd);
        }

        public Hospede GetById(int idHospede)
        {
            string sql = "SELECT * FROM tblHospede WHERE IdHospede = @IdHospede";

            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@IdHospede", idHospede);

            DataTable dt = banco.GetDataTable(cmd);

            if (dt.Rows.Count > 0)
            {
                Hospede hospede = new Hospede();
                hospede.IdHospede      = (int)dt.Rows[0]["IdHospede"];
                hospede.Nome           = dt.Rows[0]["Nome"].ToString();
                hospede.CPF            = dt.Rows[0]["CPF"].ToString();
                hospede.RG             = dt.Rows[0]["RG"].ToString();
                hospede.Telefone       = dt.Rows[0]["Telefone"].ToString();
                hospede.Email          = dt.Rows[0]["Email"].ToString();
                hospede.DataNascimento = Convert.ToDateTime(dt.Rows[0]["DataNascimento"]);
                hospede.Nacionalidade  = dt.Rows[0]["Nacionalidade"].ToString();
                hospede.Ativo          = Convert.ToBoolean(dt.Rows[0]["Ativo"]);
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

            SqlCommand cmd = new SqlCommand(sql);
            DataTable dt = banco.GetDataTable(cmd);

            HospedeCollection lista = new HospedeCollection();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Hospede hospede = new Hospede();
                hospede.IdHospede      = (int)dt.Rows[i]["IdHospede"];
                hospede.Nome           = dt.Rows[i]["Nome"].ToString();
                hospede.CPF            = dt.Rows[i]["CPF"].ToString();
                hospede.RG             = dt.Rows[i]["RG"].ToString();
                hospede.Telefone       = dt.Rows[i]["Telefone"].ToString();
                hospede.Email          = dt.Rows[i]["Email"].ToString();
                hospede.DataNascimento = Convert.ToDateTime(dt.Rows[i]["DataNascimento"]);
                hospede.Nacionalidade  = dt.Rows[i]["Nacionalidade"].ToString();
                hospede.Ativo          = Convert.ToBoolean(dt.Rows[i]["Ativo"]);
                lista.Add(hospede);
            }

            return lista;
        }

        public HospedeCollection GetAll()
        {
            return GetByFilters();
        }

        public HospedeCollection GetHospedes(string valor)
        {
            return GetByFilters("Nome LIKE '%" + valor + "%'");
        }
    }
}
