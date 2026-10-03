using System.Data;
using System.Data.SqlClient;

namespace ProjetoLucas.Services
{
    public class DataBaseService
    {
        private SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString =
                "Data Source=.\\SQLEXPRESS;" + //Host
                "Initial Catalog=gs600hotelCalifornia;" + //Nome Banco
                "Integrated Security=SSPI;"; //Autenticação do Windows
            connection.Open();
            return connection;
        }
        public int ExecuteSql(SqlCommand command)
        {
            command.Connection = GetConnection();
            return command.ExecuteNonQuery();
        }
        public DataTable GetDataTable(SqlCommand command)
        {
            command.Connection = GetConnection();
            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dataTable);
            return dataTable;
        }
    }
}
