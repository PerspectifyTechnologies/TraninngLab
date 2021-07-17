using MySql.Data.MySqlClient;
using System;
using System.Diagnostics;

namespace WebApi.RefreshToken
{
    public class RefreshTokenInDB
    {
        public static RefreshTokenInDB Instance = new RefreshTokenInDB();
        internal Tuple<string, string> Check(string username)
        {
            using (MySqlConnection conn = new MySqlConnection(DBCreds.connectionString))
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
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
                finally
                {
                    conn.Close();
                }
                return null;
            }
        }
    }
}
