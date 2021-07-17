using MySql.Data.MySqlClient;
using System;
using System.Diagnostics;

namespace WebApi.AuthServices
{
    public class CheckIfSessionActive
    {
        private static Lazy<CheckIfSessionActive> Initializer = new Lazy<CheckIfSessionActive>(() => new CheckIfSessionActive());
        public static CheckIfSessionActive Instance => Initializer.Value;
        private CheckIfSessionActive()
        {
        }
        public bool IfInvalid(string username)
        {
            using (MySqlConnection conn = new MySqlConnection(DBCreds.connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("select * from refreshtokens where username = '" + username +
                                                        "' and DATE_ADD(expirationdate,interval 6 day) < now();", conn);//CONFIGURE THE EXPIRATION
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read() == true)
                    {
                        UpdateUserActivity(conn,username);
                        return true;
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

        private void UpdateUserActivity(MySqlConnection conn,string username)
        {
                try
                {
                    conn.Open();
                    DeleteRefreshToken(conn,username);
                    MySqlCommand cmd = new MySqlCommand("update UserActivityLog set LogOutTime='" + DateTime.Now.ToString("yyyy-MM-dd H:mm:ss") +
                        "' where LogID = '" + GetUserID(conn,username) + "';", conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
        }

        private int GetUserID(MySqlConnection conn,string username)
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
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
            return 0;
        }

        private void DeleteRefreshToken(MySqlConnection conn,string username)
        {
                try
                {
                    conn.Open();
                    string query = "delete from refreshokens where username ='" + username + "';";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    reader.Close();
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
        }
    }
}
