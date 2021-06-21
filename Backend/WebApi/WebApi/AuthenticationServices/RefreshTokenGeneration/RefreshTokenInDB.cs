using MySql.Data.MySqlClient;
using System;

namespace WebApi.RefreshTokenGeneration
{
    public class RefreshTokenInDB
    {
        internal Tuple<string, string> Check(string username)
        {
            using (MySqlConnection conn = new MySqlConnection(DBCreds.ConnectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("select * from refreshtokens;", conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader["username"].ToString() == username)
                            return new Tuple<string, string>(reader["refreshtoken"].ToString(), reader["expirationdate"].ToString());
                    }
                    return null;
                }
                catch (Exception)
                { }
                return null;
            }
        }
    }
}
