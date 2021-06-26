using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace WebApi.CourseServices
{
    public class RetrieveCourse
    {
        
        List<Course> CourseList;
        
        static RetrieveCourse retrieveCourseObject = null;

        private RetrieveCourse()
        {
            CourseList = new List<Course>();
            

            MySqlConnection con = new MySqlConnection(DBCreds.ConnectionString);
            try {

                con.Open();
                string query = "SELECT * from CourseDetails;";
                using (MySqlCommand cmd = new MySqlCommand(query,con))
                {
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                Course currentCourse = new Course();
                                currentCourse.Name = rdr.GetString(1);
                                currentCourse.CourseID = rdr.GetInt32(0);
                                CourseList.Add(currentCourse);
                            }
                        }
                    }
                }
                con.Close();
            }
            catch ( Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        public static RetrieveCourse getInstance()
        {
            
            retrieveCourseObject = new RetrieveCourse();
            return retrieveCourseObject;
            
        }

        public void Add(Course course)
        {
            CourseList.Add(course);
            

            MySqlConnection con = new MySqlConnection(DBCreds.ConnectionString);
            try
            {


                con.Open();
                string query = "Insert INTO CourseDetails(Name) VALUES(\"" + course.Name +"\");";
                MySqlCommand command = new MySqlCommand(query, con);
                
                MySqlDataReader reader = command.ExecuteReader();
                

                
                con.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
        }
        public int Remove(int CourseID)
        {
            for (int i = 0; i < CourseList.Count; i++)
            {
                Course courseAtIndex = CourseList.ElementAt(i);
                if (courseAtIndex.CourseID.Equals(CourseID))
                {
                    CourseList.RemoveAt(i);


                    

                    MySqlConnection con = new MySqlConnection(DBCreds.ConnectionString);
                    try
                    {
                        con.Open();
                        string query = "DELETE FROM CourseDetails WHERE CourseID=" + courseAtIndex.CourseID + ";";
                        MySqlCommand command = new MySqlCommand(query,con);

                        MySqlDataReader reader = command.ExecuteReader();
                        con.Close();
                        return 1;
                    }
                    catch(Exception e)
                    {
                        Debug.WriteLine(e.ToString());
                    }
                }

            }
            return 0;
        }
        public List<Course> getAllCourses()
        {

            return CourseList;
        }
        public Course GetCourseFromID(int CourseID)
        {
            for (int i = 0; i < CourseList.Count; i++)
            {
                Course CourseAtIndex = CourseList.ElementAt(i);
                if (CourseAtIndex.CourseID.Equals(CourseID))
                {
                    return CourseAtIndex;
                }
            }
            return null;
        }
        
        
    }
}


