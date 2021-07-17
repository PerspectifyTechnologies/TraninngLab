using MySql.Data.MySqlClient;
using System;
using System.Diagnostics;
using WebApi.TestServices.Model;
using WebApi.UserServices;

namespace WebApi.TestServices
{
    public class ScoreCalc
    {
        private static Lazy<ScoreCalc> Initializer = new Lazy<ScoreCalc>(() => new ScoreCalc());
        public static ScoreCalc Instance => Initializer.Value;
        public void UpdateScore(int courseID,int levelID, ScoreModel scoreModel)
        {
            UserDetails.Instance.UpdateTestDetails(courseID,levelID);
            UpdateScoreByCourse(courseID,scoreModel); 
            using (MySqlConnection conn = new MySqlConnection(DBCreds.connectionString))
            {
                try
                {
                    conn.Open();
                    int prevScore = 0;
                    string query = "select testscore from userlevel where username = '" + scoreModel.Username + "';";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        prevScore = Convert.ToInt32(reader["testscore"]);
                    }
                    reader.Close();
                    query = "update userlevel set testscore = "+(scoreModel.Score + prevScore) +" where username = '"+scoreModel.Username+"';";
                    cmd = new MySqlCommand(query, conn);
                    reader = cmd.ExecuteReader();
                    reader.Read();
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

        private void UpdateScoreByCourse(int courseID, ScoreModel scoreModel)
        {
            int flag = 0;
            using (MySqlConnection conn = new MySqlConnection(DBCreds.connectionString))
            {
                try
                {
                    conn.Open();
                    int prevScore = 0;
                    string query = "select score from userprogress where username = '" + scoreModel.Username +
                        "' and courseID = "+courseID+";";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        prevScore = Convert.ToInt32(reader["score"]);
                    }
                    else
                    {
                        reader.Close();
                        query = "insert into userprogress(username,score,courseid) values('" +
                                   scoreModel.Username + "',"+
                                   (scoreModel.Score)+", "+
                                   courseID+");";
                        cmd = new MySqlCommand(query, conn);
                        reader = cmd.ExecuteReader();
                        reader.Read();
                        flag = 1;
                    }
                    if(flag == 0)
                    {
                        reader.Close();
                        query = "update userprogress set score = " + ((scoreModel.Score) + prevScore) +
                            " where username = '" + scoreModel.Username +
                            "' and courseID = " + courseID + ";";
                        cmd = new MySqlCommand(query, conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        { }
                        reader.Close();
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
        }
    }
}
