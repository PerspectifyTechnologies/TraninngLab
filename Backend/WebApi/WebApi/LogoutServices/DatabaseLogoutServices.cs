using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.DatabaseServices
{
    public class DatabaseLogoutServices : IDatabaseLogoutServices
    {
        //but have not figured out what to do with the JWTtoken

        public void Logout(string username,string token)
        {
            using (MySqlConnection conn = new MySqlConnection(DBCreds.ConnectionString))
            {
                try
                {
                    conn.Open();
                    DeleteRefreshToken(conn,username);
                    BlackListToken(conn,token);
                    MySqlCommand cmd = new MySqlCommand("update useractivitylog set logouttime='"+ DateTime.Now.ToString("yyyy-MM-dd H:mm:ss")+
                        "' where logid = '"+GetUserID(conn,username)+"';", conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read()) { }
                }
                catch (Exception)
                {
                }
            }
        }

        private void DeleteRefreshToken(MySqlConnection conn,string username)
        {
            try
            {
                string query = "delete from testinglab.RefreshTokens where username ='" + username + "';";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Close();
            }
            catch (Exception)
            {
            }
        }

        private void BlackListToken(MySqlConnection conn,string token)
        {
            try
            {
                string query = "insert into BlackListTokens(token,entrytime) values('"+token+"',now());";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Close();
            }
            catch (Exception)
            {
            }
        }

        private int GetUserID(MySqlConnection conn, string username)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select max(logid) from useractivitylog where username = '" + username + "';", conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                int ID = reader.GetInt32(0);
                reader.Close();
                return ID;
            }
            catch (Exception)
            {
            }
            return 0;
        }
    }
}
