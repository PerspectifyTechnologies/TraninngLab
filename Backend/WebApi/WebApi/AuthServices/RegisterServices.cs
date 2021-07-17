using MySql.Data.MySqlClient;
using System;
using System.Diagnostics;
using System.Web.Helpers;
using WebApi.AuthServices.Models;

namespace WebApi.AuthServices
{
    public class RegisterServices
    {
        private static Lazy<RegisterServices> Initializer = new Lazy<RegisterServices>(() => new RegisterServices());
        public static RegisterServices Instance => Initializer.Value;
        public bool RegisterRecordsIfValid(RegisterModel registerModel)
        {
            using (MySqlConnection conn = new MySqlConnection(DBCreds.connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("select * from InviteList;", conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader["email"].ToString() == registerModel.Email)
                        {
                            reader.Close();
                            DeleteInvitation(conn, registerModel.Email);
                            StoreUserEntries(conn, registerModel);
                            InitializeUserLevel(conn, registerModel.UserPayload.Username);
                            return false;
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
            }
            return true ;
        }

        private void InitializeUserLevel(MySqlConnection conn, string userName)
        {
            try
            {
                string query = "insert into UserLevel(userName) values('" +
                userName + "');";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        private void DeleteInvitation(MySqlConnection conn,string email)
        {
            try
            {
                string query = "delete from testinglab.InviteList where email ='" + email + "';";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        private void StoreUserEntries(MySqlConnection conn,RegisterModel registerModel)
        {
            try
            {
                string query = "insert into UserAuthentication(username,password,email) values('" +
                registerModel.UserPayload.Username + "','" +
                Crypto.SHA256(registerModel.UserPayload.Payload) + "','" +
                registerModel.Email + "');";
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
