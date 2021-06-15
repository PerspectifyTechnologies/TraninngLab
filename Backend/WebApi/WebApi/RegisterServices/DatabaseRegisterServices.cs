using MySql.Data.MySqlClient;
using System;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace WebApi.DatabaseModel
{
    public class DatabaseRegisterServices : IDatabaseRegisterServices
    {


        public void RecordEntries(RegisterModel registerModel)
        {
            using (MySqlConnection conn = new MySqlConnection("server = localhost; userid = root; password = Abhi@1214; database = training_lab"))
            {
                try
                {
                    conn.Open();
                    string query = "insert into users_info(username,email,hashpassword,firstname,lastname) values('" +
                    registerModel.UserName + "','" +
                    registerModel.Email + "','" +
                    Crypto.SHA256(registerModel.Password) + "','" +
                    registerModel.FirstName + "','" +
                    registerModel.LastName + "');";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    reader.Close();
                }
                catch (Exception)
                {
                }
            }
        }


        public bool RecordExists(RegisterModel registerModel)
        {
            using (MySqlConnection conn = new MySqlConnection("server = localhost; " +
                                                              "userid = root; " +
                                                              "password = Abhi@1214; " +
                                                              "database = training_lab"))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("select * from users_info;",conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader["username"].ToString() == registerModel.UserName || reader["email"].ToString() == registerModel.Email)
                            return true;
                    }
                }
                catch (Exception)
                {
                }
            }
            RecordEntries(registerModel);
            return false;
        }

    }
}
