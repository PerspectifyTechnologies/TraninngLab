using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using WebApi.TestServices.Model;
using WebApi.TestServices.Models;

namespace WebApi.TestServices
{
    public class QnA
    {
        private int QuesID;
        private static Lazy<QnA> Initializer = new Lazy<QnA>(() => new QnA());
        public static QnA Instance => Initializer.Value;
        internal List<QnAModel> GetRandomTen(int testID)
        {
            QuesID = 0;
            List<QnAModel> Test = new List<QnAModel>();
            using (MySqlConnection conn = new MySqlConnection(DBCreds.connectionString))
            {
                try
                {
                    string query = "select * from testquestions where testID = '" + testID +
                                                        "' order by rand() limit 5;";
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query , conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    int questionID = 0;
                    while (reader.Read())
                    {
                        Test.Add(GetQuestionsAndOptions(Convert.ToInt32(reader["QuestionID"])));
                        questionID += 1;
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
            return Test;
        }

        private QnAModel GetQuestionsAndOptions(int questionID)
        {
            List<Option> options = new List<Option>();
            string question = null;
            using (MySqlConnection conn = new MySqlConnection(DBCreds.connectionString))
            {
                try
                {
                    conn.Open(); string query = "select * from quesans where questionid =" + questionID + ";";
                    
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader(); int count = 1;
                    while (reader.Read())
                    { }
                    while (count <= 4)
                    {
                        options.Add(new Option()
                        {
                            Answer = reader["Option" + count.ToString()].ToString(),
                            IsCorrect = (Convert.ToInt32(reader["Answer"]) == count) ? true : false
                        });
                        count += 1;
                    }
                    question = reader["Question"].ToString();
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
            return new QnAModel() {
                QuesID = ++QuesID,
                Question = question,
                Options = options };

        }
    }
}
