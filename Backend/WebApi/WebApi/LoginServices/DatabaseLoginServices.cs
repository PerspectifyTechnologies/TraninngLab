using MySql.Data.MySqlClient;
using System;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace WebApi.DatabaseModel
{
    public class DatabaseLoginServices : IDatabaseLoginServices
    {
      

        public bool LoginMatchCreds(string username, string password)
        {
            using (MySqlConnection conn = new MySqlConnection("server = localhost; " +
                                                              "userid = root; " +
                                                              "password = Abhi@1214; " +
                                                              "database = training_lab"))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("select * from users_info", conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader["username"].ToString() == username && Crypto.SHA256(password) == reader["hashpassword"].ToString())
                            return true;
                    }
                    return false;
                }
                catch (Exception)
                { }
                    return false;
            }
        }
    }
}
