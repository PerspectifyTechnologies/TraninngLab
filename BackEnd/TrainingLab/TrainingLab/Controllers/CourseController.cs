using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using TrainingLab.Models;


namespace TrainingLab.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseController : Controller
    {
       SQLiteConnection con = new SQLiteConnection("Data Source=C:\\Users\\HIMANI\\OneDrive\\BackEnd\\TrainingLab\\TrainingLab\\TrainingLabDB.db");
        SQLiteCommand cmd = new SQLiteCommand();
        SQLiteCommand cmdd = new SQLiteCommand();

        [HttpGet]
        public string GetCourses()
        {
            cmd.Connection = con;
            cmdd.Connection = con;
            con.Open();
            cmd.CommandText = "select * from Course";
            SQLiteDataReader dr = cmd.ExecuteReader();
            StringBuilder sb = new StringBuilder();
            int i = 0;
            CourseModel courseModel = new CourseModel();
            sb.Append("\"courses\": ");
            if(dr.HasRows)
            {
                while(dr.Read())
                {
                    if (i != 0)
                        sb.Append(",");
                    sb.Append("_" + i + ":");                    
                    courseModel.Id = int.Parse(dr["Id"].ToString());
                    sb.Append("{\"id\":\"" + dr["Id"] + "\",");
                    sb.Append("\"courseName\":\"" + dr["CourseName"] + "\",");
                    sb.Append("\"authorName\":\"" + dr["AuthorName"] + "\",");
                    sb.Append(getChapters(int.Parse(dr["Id"].ToString()))+"}");
                    i++;
                }
            }
            dr.Close();
            con.Close();
            return sb.ToString();
        }
        public string getChapters(int id)
        {
            StringBuilder sb = new StringBuilder();
            cmdd.CommandText = "select * from Chapter where CourseId='" + id+ "'";
            SQLiteDataReader drr = cmdd.ExecuteReader();
            sb.Append("\"chapters\":\"{");
            int j = 0;
            if (drr.HasRows)
            {
                while (drr.Read())
                {
                    if (j != 0)
                        sb.Append(",");
                    sb.Append(drr["ChapterName"].ToString());
                    j++;
                }
            }
            sb.Append("}\"");
            drr.Close();
            return sb.ToString();
        }
        [HttpGet("chapter")]
        public string GetChapters([FromQuery] string course)
        {
            cmd.Connection = con;
            cmdd.Connection = con;
            con.Open();
            cmd.CommandText = "select * from Chapter ch inner join Course c on c.Id=ch.CourseId where c.CourseName='"+course+"'";
            SQLiteDataReader dr = cmd.ExecuteReader();
            StringBuilder sb = new StringBuilder();
            int i = 0;
            CourseModel courseModel = new CourseModel();
            sb.Append("\"chapters\": ");
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    if (i != 0)
                        sb.Append(",");
                    sb.Append("_" + i + ":");
                    courseModel.Id = int.Parse(dr["Id"].ToString());
                    sb.Append("{\"id\":\"" + dr["Id"] + "\",");
                    sb.Append("\"courseName\":\"" + dr["CourseName"] + "\",");
                    sb.Append("\"authorName\":\"" + dr["AuthorName"] + "\",");
                    sb.Append("\"chapterName\":\"" + dr["ChapterName"] + "\",");
                    sb.Append(getTopics(int.Parse(dr["Id"].ToString()))+"}");
                    i++;
                }
            }
            dr.Close();
            con.Close();
            return sb.ToString();
        }
        public string getTopics(int id)
        {
            StringBuilder sb = new StringBuilder();
            cmdd.CommandText = "select * from Topic where ChapterId='" + id + "'";
            SQLiteDataReader drr = cmdd.ExecuteReader();
            sb.Append("\"topics\":\"{");
            int j = 0;
            if (drr.HasRows)
            {
                while (drr.Read())
                {
                    if (j != 0)
                        sb.Append(",");
                    sb.Append(drr["TopicName"].ToString());
                    j++;
                }
            }
            sb.Append("}\"");
            drr.Close();
            return sb.ToString();
        }
        [HttpGet("topic")]
        public string GetTopics([FromQuery] string course,[FromQuery] string chapter)
        {
            cmd.Connection = con;
            cmdd.Connection = con;
            con.Open();
            cmd.CommandText = "select * from Topic t inner join Chapter ch on ch.Id=t.ChapterId inner join Course c on c.Id=ch.CourseId where c.CourseName='" + course + "' and ch.ChapterName='"+chapter+"'";
            SQLiteDataReader dr = cmd.ExecuteReader();
            StringBuilder sb = new StringBuilder();
            int i = 0;
            CourseModel courseModel = new CourseModel();
            sb.Append("\"chapters\": ");
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    if (i != 0)
                        sb.Append(",");
                    sb.Append("_" + i + ":");
                    courseModel.Id = int.Parse(dr["Id"].ToString());
                    sb.Append("{\"id\":\"" + dr["Id"] + "\",");
                    sb.Append("\"courseName\":\"" + dr["CourseName"] + "\",");
                    sb.Append("\"authorName\":\"" + dr["AuthorName"] + "\",");
                    sb.Append("\"chapterName\":\"" + dr["ChapterName"] + "\",");
                    sb.Append("\"TopicName\":\"" + dr["TopicName"] + "\",");
                    sb.Append("\"videoURL\":\"" + dr["VideoURL"] + "\",");
                    sb.Append("\"notesURL\":\"" + dr["NotesURL"]+"\"}");
                    // sb.Append(getTopics(int.Parse(dr["Id"].ToString())));
                    i++;
                }
            }
            dr.Close();
            con.Close();
            return sb.ToString();
        }       
    }
}
