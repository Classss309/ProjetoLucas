using System.Data;
using System.Data.SqlClient;

namespace ProjetoLucas.Services
{
    public class DataBaseService
    {
        private const string connectionString =
            "Data Source=.\\SQLEXPRESS;" +
            "Initial Catalog=gs600hotelCalifornia;" +
            "Integrated Security=SSPI;";

        public int ExecuteSql(SqlCommand command)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                command.Connection = conn;
                conn.Open();
                return command.ExecuteNonQuery();
            }
        }

        public DataTable GetDataTable(SqlCommand command)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                command.Connection = conn;
                conn.Open();
                DataTable dataTable = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataTable);
                return dataTable;
            }
        }
    }
}
