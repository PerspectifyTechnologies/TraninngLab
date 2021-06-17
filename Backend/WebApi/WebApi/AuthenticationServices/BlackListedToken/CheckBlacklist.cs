using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.DatabaseServices
{
    public class CheckBlacklist : ICheckBlackList
    {
        public bool IfPresent(string token)
        {
            using (MySqlConnection conn = new MySqlConnection(DBCreds.ConnectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("select * from blacklisttokens;", conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string thistoken = reader["token"].ToString(); 
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
