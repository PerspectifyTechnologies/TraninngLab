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
                    MySqlCommand cmd = new MySqlCommand("select * from RefreshTokens where username = '" + username + "' and DATE_ADD(expirationdate,interval 40 second) < now();", conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read() == true)
                    {
                        UpdateUserActivity(username);
                        return true;
                    }
                }
                catch (Exception)
                { }
                return false;
            }
        }

        private void UpdateUserActivity(string username)
        {
            using (MySqlConnection conn = new MySqlConnection(DBCreds.ConnectionString))
            {
                try
                {
                    conn.Open();
                    DeleteRefreshToken(username);
                    MySqlCommand cmd = new MySqlCommand("update UserActivityLog set LogOutTime='" + DateTime.Now.ToString("yyyy-MM-dd H:mm:ss") +
                        "' where LogID = '" + GetUsID(username) + "';", conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                }
                catch (Exception)
                {
                }
            }
        }

        private int GetUsID(string username)
        {
            using (MySqlConnection conn = new MySqlConnection(DBCreds.ConnectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("select max(logid) from UserActivityLog where userName = '" + username + "';", conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    int ID = reader.GetInt32(0);
                    reader.Close();
                    return ID;
                }
                catch (Exception)
                {
                }
            }
            return 0;
        }

        private void DeleteRefreshToken(string username)
        {
            using (MySqlConnection conn = new MySqlConnection(DBCreds.ConnectionString))
            {
                try
                {
                    conn.Open();
                    string query = "delete from TestingLab.RefreshTokens where userName ='" + username + "';";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    reader.Close();
                }
                catch (Exception)
                {
                }
            }
        }
    }
}
