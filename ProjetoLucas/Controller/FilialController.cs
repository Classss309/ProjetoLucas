using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoLucas.Models;
using ProjetoLucas.Services;
using System.Data.SqlClient;
using System.Data;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;

namespace ProjetoLucas.Controller
{
    public class FilialController
    {
        DataBaseService _database = new DataBaseService();

        public int Inserir(Filial filial)
        {

            string Inserir = "INSERT INTO tblHotel (RazaoSocial, CNPJ, Telefone, Email, Avalicao, Ativo)" +
                "VALUES (@RazaoSocial , @CNPJ, @Telefone , @Email, @Avalicao, Ativo";

            SqlCommand command = new SqlCommand(Inserir);

            
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
            string Alterar = "UPDATE tblHotel SET " +
                "RazaoSocial = @RazaoSocial, CNPJ = @CNPJ, Telefone = @Telefone , Email = @Email, Avaliacao = @Avalicao, IdEndereco = @IdEndereco, Ativo = @Ativo" +
                "WHERE IdFilial = @idFilial";

            SqlCommand command = new SqlCommand(Alterar);

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

            string exclusao = "DELETE FROM tblHotel" +
                              "WHERE IdFilial = @idFilial";

            SqlCommand command = new SqlCommand(exclusao);

            command.Parameters.AddWithValue("@IdFilial", idFilial);

            return _database.ExecuteSql(command);
        }

        public Filial GetById(int idFilial)
        {
            string consulta = "SELECT * FROM tblHotel" +
                "WHERE IdFilial = @idFilial";

            SqlCommand command = new SqlCommand(consulta);

            command.Parameters.AddWithValue("@IdFilial", idFilial);

            DataTable dataTable = _database.GetDataTable(command);

            if (dataTable.Rows.Count > 0)
            {
                Filial filial = new Filial();

                filial.idFilial = (int)dataTable.Rows[0]["idFilial"];
                filial.RazaoSocial = (string)dataTable.Rows[0]["RazaoSocial"];
                filial.CNPJ = (string)dataTable.Rows[0]["CNPJ"];
                filial.Telefone = (string)dataTable.Rows[0]["Telefone"];
                filial.Email = (string)dataTable.Rows[0]["Email"];
                filial.Avaliacao = (decimal)dataTable.Rows[0]["Avaliacao"];
                filial.IdEndereco = (int)dataTable.Rows[0]["IdEndereco"];
                filial.Ativo = (int)dataTable.Rows[0]["Ativo"];

                return filial;
            }
            else
                return null;
        }

        private FilialColletion
            GetByFilters(string filtros = "")
        {

            string filtro = "SELECT * FROM tblHotel";

            if (filtros != "")
                filtros += "WHERE @filtros";

            filtros += "ORDER BY idFilial";

            SqlCommand command = new SqlCommand(filtros);

            command.Parameters.AddWithValue("@filtros", filtro);

            DataTable dataTable = _database.GetDataTable(command);

            FilialColletion filiais = new FilialColletion();

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {

                Filial filial = new Filial();

                filial.idFilial = (int)dataTable.Rows[0]["idFilial"];
                filial.RazaoSocial = (string)dataTable.Rows[0]["RazaoSocial"];
                filial.CNPJ = (string)dataTable.Rows[0]["CNPJ"];
                filial.Telefone = (string)dataTable.Rows[0]["Telefone"];
                filial.Email = (string)dataTable.Rows[0]["Email"];
                filial.Avaliacao = (decimal)dataTable.Rows[0]["Avaliacao"];
                filial.IdEndereco = (int)dataTable.Rows[0]["IdEndereco"];
                filial.Ativo = (int)dataTable.Rows[0]["Ativo"];

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
