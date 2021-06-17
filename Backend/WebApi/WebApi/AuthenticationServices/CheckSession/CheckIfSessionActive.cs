using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.AuthenticationServices.CheckSession
{
    public class CheckIfSessionActive
    {
        public bool IfInvalid(string username)
        {
            using (MySqlConnection conn = new MySqlConnection(DBCreds.ConnectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("select * from RefreshTokens where username = '" + username + "' and DATE_ADD(expirationdate,interval 30 second) < now();", conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read() == false)
                    {
                        return true;
                    }
                }
                catch (Exception)
                { }
                return false;
            }
        }
    }
}
