using System;
using System.Data.SqlClient;

namespace WebApplication7
{
    public class SqlOperation
    {
        SqlConnection connection;
        SqlCommand command;
        public SqlOperation()
        {
            connection = Connection.GetConnection();
            command = new SqlCommand();
        }
        public bool AddToken(string token)
        {
            try
            {
                using (command = new SqlCommand($"INSERT INTO [Tokens] VALUES('{token}')", connection))
                {
                    command.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool CompareTokens(string token)
        {
            using (command = new SqlCommand($"SELECT * FROM [Tokens] WHERE [Token] = '{token}'", connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                        return true;
                }
            }
            return false;
        }
    }
}
