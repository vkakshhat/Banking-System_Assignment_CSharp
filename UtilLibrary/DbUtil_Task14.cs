using System;
using Microsoft.Data.SqlClient;


namespace UtilLibrary
{
    public class DBUtil_Task14
    {
        private static readonly string connectionString = "Data Source=AK\\SQLEXPRESS;Initial Catalog=HMBank;Integrated Security=True;Trust Server Certificate=True";

        public static SqlConnection getDBConn()
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
                return conn;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error establishing database connection: " + ex.Message);
                return null;
            }
        }
    }
}

