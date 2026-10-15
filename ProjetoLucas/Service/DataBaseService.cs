using System.Data;
using System.Data.SqlClient;

namespace ProjetoLucas.Services
{
    public class DataBaseService
    {
        private SqlConnection GetConnection()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString =
                "Data Source=LOCALHOST;" +
                "Initial Catalog=gs600hotelCalifornia;" +
                "Integrated Security=SSPI;";
            con.Open();
            return con;
        }

        public int ExecuteSql(SqlCommand command)
        {
            command.Connection = GetConnection();
            return command.ExecuteNonQuery();
        }

        public DataTable GetDataTable(SqlCommand command)
        {
            command.Connection = GetConnection();
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dt);
            return dt;
        }
    }
}
