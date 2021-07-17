using MySql.Data.MySqlClient;
using System;
using System.Diagnostics;
using System.Web.Helpers;

namespace WebApi.AuthServices
{
    public class LoginServices
    {
        private static Lazy<LoginServices> Initializer = new Lazy<LoginServices>(() => new LoginServices());
        public static LoginServices Instance => Initializer.Value;
        public int GetLogIdOfUSer(string username)
        {
            using (MySqlConnection conn = new MySqlConnection(DBCreds.connectionString))
            {
                try
                {
                    conn.Open(); 
                    MySqlCommand cmd = new MySqlCommand("select LogID from UserActivityLog where userName = ?username and LogOutTime is null;", conn);
                    cmd.Parameters.Add(new MySqlParameter("username", username));
                    MySqlDataReader reader = cmd.ExecuteReader();
                    int ID = 0;
                    if(reader.Read())
                        reader.GetInt32(0);
                    reader.Close();
                    return ID;
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            return 0;
        }
        public bool MatchLoginCreds(string username, string password,bool refresh)
        {
            using (MySqlConnection conn = new MySqlConnection(DBCreds.connectionString))
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
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
                finally
                {
                    conn.Close();
                }
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
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }
        public void RemovePrevious(string username)
        {
            using (MySqlConnection conn = new MySqlConnection(DBCreds.connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("update UserActivityLog set LogOutTime='" +
                                                        DateTime.Now.ToString("yyyy-MM-dd H:mm:ss") +
                                                        "' where LogID = '" + GetUserID(conn, username) + "';", conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read()) { }
                    reader.Close();
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        private int GetUserID(MySqlConnection conn, string username)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select max(LogId) from UserActivityLog where userName = '" + username + "';", conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                int ID = reader.GetInt32(0);
                reader.Close();
                return ID;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return 0;
        }
    }
}
