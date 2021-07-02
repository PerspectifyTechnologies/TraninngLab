using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.TestServices.Models;

namespace WebApi.TestServices
{
    public class QnA
    {
        private static Lazy<QnA> Initializer = new Lazy<QnA>(() => new QnA());
        public static QnA Instance => Initializer.Value; 
        private QnA()
        {
        }
        internal async Task<IDictionary<int,QnAModel>> GetRandomTen(int testID)
        {
            IDictionary<int, QnAModel> Test = new Dictionary<int, QnAModel>();
            using (MySqlConnection conn = new MySqlConnection(DBCreds.ConnectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("select Distinct(QuestionID, Question) from QAndA where QuestionID in (" +
                                                        "select QuestionID from TestCatalog where testID = '"+testID+
                                                        "' order by rand() limit 10) order by QuestionID;", conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    int questionID = 0;
                    while (reader.Read())
                    {
                        await Task.Delay(2);
                        Test.Add(questionID+1,GetQuestionsAndOptions(Convert.ToInt32(reader["QuestionID"])));
                    }
                }
                catch (Exception)
                { }
            }
            return Test;
        }

        private QnAModel GetQuestionsAndOptions(int questionID)
        {
            List<string> options = new List<string>();
            string question = null;
            int answer=0;
            using (MySqlConnection conn = new MySqlConnection(DBCreds.ConnectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("select * from QAndA where QuestionID =" + questionID +"';", conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        options.Add(reader["Answer"].ToString());
                        if (Convert.ToBoolean(reader["Answer"]) == true)
                            answer = options.Count;
                        if (question == null)
                            question = reader["Question"].ToString();
                    }
                }
                catch (Exception)
                { }
            }
            return new QnAModel(){
                Question = question,
                Options = options,
                Answer = answer };

        }
    }
}
