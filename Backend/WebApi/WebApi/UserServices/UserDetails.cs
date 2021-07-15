using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.UserServices.Models;

namespace WebApi.UserServices
{
    public class UserDetails
    {
        private static Lazy<UserDetails> Initializer = new Lazy<UserDetails>(() => new UserDetails());
        public static UserDetails Instance => Initializer.Value;
        private UserDetails()
        {
        }
        public UserModel Get(string username)
        {
            int score = 0;
            string level = "Amateur";
            using (MySqlConnection conn = new MySqlConnection(DBCreds.ConnectionString))
            {
                try
                {
                    string query = "select testscore from userlevel where username = '"+username+"'; ";
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    score =  Convert.ToInt32(reader["testscore"]);
                    reader.Close();
                    query = "select levelname from levelslab where minimumscore = (select max(minimumscore) from levelslab where minimumscore < "+score+") ;";
                    cmd = new MySqlCommand(query, conn);
                    reader = cmd.ExecuteReader();
                    reader.Read();
                    level = reader["levelname"].ToString();
                    reader.Close();
                }
                catch (Exception e)
                { }
            }
            return new UserModel {
                Username = username,
                Level = level,
                Score = score
            };
        }

        internal void UpdateTestDetails(int courseID, int levelID)
        {
            using (MySqlConnection conn = new MySqlConnection(DBCreds.ConnectionString))
            {
                try
                {
                    string query = "update testdetails set hastaken = " + true + " where courseid = '" + courseID + "' and testlevelid = '"+levelID+"'; ";
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    reader.Close();
                }
                catch (Exception e)
                { }
            }
        }
    }
}
