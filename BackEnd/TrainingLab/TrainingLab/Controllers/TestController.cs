using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingLab.Models;

namespace TrainingLab.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        SQLiteConnection con = new SQLiteConnection("Data Source=C:\\Users\\HIMANI\\OneDrive\\BackEnd\\TrainingLab\\TrainingLab\\TrainingLabDB.db");
        SQLiteCommand cmd = new SQLiteCommand();
        SQLiteCommand cmdd = new SQLiteCommand();
        [HttpGet]
        public string GetCourses([FromQuery] string courseName)
        {
            cmd.Connection = con;
            con.Open();
            if (courseName==null)
            {
                cmd.CommandText = "select CourseName from Course";
                SQLiteDataReader dr = cmd.ExecuteReader();
                dr.Close();
                dr = cmd.ExecuteReader();
                StringBuilder sb = new StringBuilder();
                int i = 0;
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        if (i != 0)
                            sb.Append(",");
                        sb.Append("{\"CourseName\":\""+dr["CourseName"].ToString()+"\"}");
                        i++;
                    }
                }
                return sb.ToString();
            }
            else
            {
                cmd.CommandText = "select c.CourseName,l.LevelName,q.QuestionText,q.OptionList,q.TypeOfQuestion,q.CorrectAnswer from Test t inner join Course c on c.Id=t.CourseId inner join Questionnaire q on t.Id=q.TestId inner join Level l on l.Id=t.LevelId where c.CourseName='"+courseName+"'";
                SQLiteDataReader dr = cmd.ExecuteReader();

                int i = 0;
                StringBuilder sb = new StringBuilder();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        if (i != 0)
                        {
                            sb.Append(",");
                        }
                        sb.Append("{\"CourseName\":\"" + dr["CourseName"].ToString() + "\",\"LevelName\":\"" + dr["LevelName"].ToString() + "\",\"QuetionText\":\"" + dr["QuestionText"].ToString() + "\",\"OptionList\":{" + dr["OptionList"].ToString() + "},\"TypeOfQuestion\":\"" + dr["TypeOfQuestion"].ToString() + "\",\"CorrectAnswer\":\"" + dr["CorrectAnswer"].ToString() + "\"}");
                        i++;
                    }
                }
                dr.Close();
                con.Close();
                return sb.ToString();
            }
        }
       
       
    }
}
