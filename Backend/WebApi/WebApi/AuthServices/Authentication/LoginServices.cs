using MySql.Data.MySqlClient;
using System;
using System.Web.Helpers;

namespace WebApi.AuthServices.Authentication
{
    public class LoginServices
    {
        public int GetLogIdOfUSer(string username)
        {
            using (MySqlConnection conn = new MySqlConnection(DBCreds.ConnectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("select LogID from UserActivityLog where userName = '" + username + 
                                                        "' and LogOutTime is null;", conn);
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
        public bool MatchLoginCreds(string username, string password,bool refresh)
        {
            using (MySqlConnection conn = new MySqlConnection(DBCreds.ConnectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("select * from UserAuthentication", conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader["userName"].ToString() == username && Crypto.SHA256(password) == reader["password"].ToString())
                        {
                            reader.Close();
                            if(!refresh)
                                AddInUserActivityLog(conn,username);
                            return true;
                        }
                    }
                }
                catch (Exception)
                { }
                return false;
            }
        }
        private void AddInUserActivityLog(MySqlConnection conn,string username)
        {
            try
            {
                string query = "insert into UserActivityLog(userName,LogInTime) values('" +
                username + "','" +
                DateTime.Now.ToString("yyyy-MM-dd H:mm:ss") + "');";
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
