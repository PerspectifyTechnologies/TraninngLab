using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.TestServices
{
    public class GetQnA
    {
        internal IDictionary<int,QnA> GetRandomTen(int testID)
        {
            IDictionary<int, QnA> Test = new Dictionary<int, QnA>();
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
                            Test.Add(questionID+1,GetQuestionsAndOptions(Convert.ToInt32(reader["QuestionID"])));
                    }
                }
                catch (Exception)
                { }
            }
            return Test;
        }

        private QnA GetQuestionsAndOptions(int questionID)
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
            return new QnA()
            {
                Question = question,
                Options = options,
                Answer = answer
            };

        }
    }
}
