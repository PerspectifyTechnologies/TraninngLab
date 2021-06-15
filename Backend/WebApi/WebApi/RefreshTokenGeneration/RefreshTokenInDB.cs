using MySql.Data.MySqlClient;
using System;

namespace WebApi.RefreshTokenGeneration
{
    public class RefreshTokenInDB
    {
        internal Tuple<string, string> Check(string username)
        {
            using (MySqlConnection conn = new MySqlConnection("server = localhost; " +
                                                                 "userid = root; " +
                                                                 "password = Abhi@1214; " +
                                                                 "database = training_lab"))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("select * from user_refresh_token;", conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ////
                        //need to change from (EMAIL TO USERNAME)
                        ////
                        if (reader["email"].ToString() == "daddawada@da.cm")
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
