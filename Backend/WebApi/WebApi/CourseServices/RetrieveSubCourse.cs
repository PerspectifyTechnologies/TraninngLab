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
    public class RetrieveSubCourse
    {

        
        List<SubCourse> SubCourseList;
        static RetrieveSubCourse retriveSubCourseObject = null;

        public static RetrieveSubCourse getInstance()
        {

            retriveSubCourseObject = new RetrieveSubCourse();
            return retriveSubCourseObject;

        }

        
        public List<SubCourse> GetSubCoursesFromCourseID(int CourseID)
        {
            SubCourseList = new List<SubCourse>();
            

            MySqlConnection con = new MySqlConnection(DBCreds.connectionString);
            try
            {

                con.Open();
                string query = "SELECT * from SubCourseDetails WHERE CourseID=" + CourseID + ";";
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                SubCourse currentSubCourse = new SubCourse();
                                currentSubCourse.Name = rdr.GetString(1);
                                currentSubCourse.SubCourseID = rdr.GetInt32(0);
                                currentSubCourse.Url = rdr.GetString(2);
                                currentSubCourse.CourseID = rdr.GetInt32(3);
                                currentSubCourse.Title = rdr.GetString(4);
                                currentSubCourse.Desc = rdr.GetString(5);
                                SubCourseList.Add(currentSubCourse);
                            }
                        }

                    }
                }
                con.Close();

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());

            }
            return SubCourseList;
        }
        
    }
}


