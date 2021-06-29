using MySql.Data.MySqlClient;
using System;

namespace WebApi.AuthServices.Authentication
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
                    MySqlCommand cmd = new MySqlCommand("select * from refreshtokens where username = '" + username +
                                                        "' and DATE_ADD(expirationdate,interval 40 second) < now();", conn);//CONFIGURE THE EXPIRATION
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
                        "' where LogID = '" + GetID(username) + "';", conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                }
                catch (Exception)
                {
                }
            }
        }

        private int GetID(string username)
        {
            using (MySqlConnection conn = new MySqlConnection(DBCreds.ConnectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("select max(LogID) from UserActivityLog where UserName = '" + username + "';", conn);
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
                    string query = "delete from refreshokens where username ='" + username + "';";
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
