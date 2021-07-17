using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.TestServices.Model;
using WebApi.UserServices.Models;

namespace WebApi.TestServices
{
    public class LevelDetails
    {
        private static Lazy<LevelDetails> Initializer = new Lazy<LevelDetails>(() => new LevelDetails());
        public static LevelDetails Instance => Initializer.Value;
        internal List<TestlevelModels> GetLevelInfo(int courseid)
        {
            int first = 1;
            List<TestlevelModels> LevelDetails = new List<TestlevelModels>();
            using (MySqlConnection conn = new MySqlConnection(DBCreds.connectionString))
            {
                bool nextinline = false;
                try
                {
                    string query = "select testlevelid, testlevelname, hastaken from testdetails where courseid = '"+courseid+"' order by testlevelid";
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (!Convert.ToBoolean(reader["hastaken"]) && first == 1)
                        {
                            first = 0;
                            nextinline = true;
                        }
                        else
                        {
                            nextinline = false;
                        }
                        LevelDetails.Add(new TestlevelModels
                        {
                            LevelID = Convert.ToInt32(reader["testlevelid"]),
                            LevelName = reader["testlevelname"].ToString(),
                            HasTaken = Convert.ToBoolean(reader["hastaken"]),
                            NextInLine = nextinline
                        }) ;
                    }
                    reader.Close();
                }
                catch (Exception)
                { }
            }
            return LevelDetails;
        }
    }
}
