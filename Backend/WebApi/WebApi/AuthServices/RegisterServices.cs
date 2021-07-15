using MySql.Data.MySqlClient;
using System;
using System.Web.Helpers;
using WebApi.AuthServices.Models;

namespace WebApi.AuthServices
{
    public class RegisterServices
    {
        public static RegisterServices Instance = new RegisterServices();
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
                            InitializeUserLevel(conn, registerModel.UserName);
                            return false;
                        }
                    }
                }
                catch (Exception)
                {}
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
            catch (Exception)
            {}
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
            catch (Exception)
            {}
        }

        private void StoreUserEntries(MySqlConnection conn,RegisterModel registerModel)
        {
            try
            {
                string query = "insert into UserAuthentication(username,password,email) values('" +
                registerModel.UserName + "','" +
               // registerModel.FirstName + "','" +
               // registerModel.LastName + "','" +
                Crypto.SHA256(registerModel.Password) + "','" +
                registerModel.Email + "');";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Close();
            }
            catch (Exception)
            {}
        }
    }
}
