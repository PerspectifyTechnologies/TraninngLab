using MySql.Data.MySqlClient;
using System;

namespace WebApi.AuthServices
{
    public class CheckBlacklist
    {
        public static CheckBlacklist Instance = new CheckBlacklist();
        private CheckBlacklist()
        {
        }
        public bool IfPresent(string token)
        {
            using (MySqlConnection conn = new MySqlConnection(DBCreds.connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("select * from blacklisttokens;", conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string thistoken = reader["Token"].ToString(); 
                        if (thistoken == token)
                        {
                            reader.Close();
                            return true;
                        }
                    }
                }
                catch (Exception)
                {
                }
            }
            return false;
        }
    }
}
