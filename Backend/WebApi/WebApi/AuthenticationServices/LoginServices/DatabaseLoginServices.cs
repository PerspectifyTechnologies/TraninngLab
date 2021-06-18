using MySql.Data.MySqlClient;
using System;
using System.Web.Helpers;

namespace WebApi.DatabaseServices
{
    public class DatabaseLoginServices : IDatabaseLoginServices
    {
        public int GetLogIdOfUSer(string username)
        {
            using (MySqlConnection conn = new MySqlConnection(DBCreds.ConnectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("select logid from useractivitylog where username = '" + username + "' and logouttime is null;", conn);
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

        public bool MatchLoginCreds(string username, string password,int refresh)
        {
            using (MySqlConnection conn = new MySqlConnection(DBCreds.ConnectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("Select * from userauthentication", conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader["username"].ToString() == username && Crypto.SHA256(password) == reader["password"].ToString())
                        {
                            reader.Close();
                            if(refresh == 0)
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
                string query = "insert into useractivitylog(username,logintime) values('" +
                username + "','" +
                DateTime.UtcNow.ToString("yyyy-MM-dd H:mm:ss") + "');";
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
