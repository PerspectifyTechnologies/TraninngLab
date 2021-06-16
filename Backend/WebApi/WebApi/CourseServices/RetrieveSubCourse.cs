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

        //public void Add(Course course)
        //{
        //    CourseList.Add(course);
        //    String cs = "server = localhost; userid = root; password = Abh1Ank1; database = TrainingLab";

        //    MySqlConnection con = new MySqlConnection(cs);
        //    try
        //    {


        //        con.Open();
        //        string query = "Insert INTO CourseDetails(Name) VALUES(\"" + course.Name + "\");";
        //        MySqlCommand command = new MySqlCommand(query, con);

        //        MySqlDataReader reader = command.ExecuteReader();



        //        con.Close();
        //    }
        //    catch (Exception e)
        //    {
        //        Debug.WriteLine(e.ToString());
        //    }
        //}
        //public int Remove(int CourseID)
        //{
        //    for (int i = 0; i < CourseList.Count; i++)
        //    {
        //        Course courseAtIndex = CourseList.ElementAt(i);
        //        if (courseAtIndex.CourseID.Equals(CourseID))
        //        {
        //            CourseList.RemoveAt(i);


        //            String cs = "Data Source=/Users/abii/Projects/Bank/Bank/bankDatabase.db; Version=3;";

        //            MySqlConnection con = new MySqlConnection(cs);
        //            try
        //            {
        //                con.Open();
        //                string query = "DELETE FROM CourseDetails WHERE CourseID=" + courseAtIndex.CourseID + ";";
        //                MySqlCommand command = new MySqlCommand(query, con);

        //                MySqlDataReader reader = command.ExecuteReader();
        //                con.Close();
        //                return 1;
        //            }
        //            catch (Exception e)
        //            {
        //                Debug.WriteLine(e.ToString());
        //            }
        //        }

        //    }
        //    return 0;
        //}
        //public List<SubCourse> getAllSCourses()
        //{

        //    return CourseList;
        //}
        //public Course GetCourseFromID(int CourseID)
        //{
        //    for (int i = 0; i < CourseList.Count; i++)
        //    {
        //        Course CourseAtIndex = CourseList.ElementAt(i);
        //        if (CourseAtIndex.CourseID.Equals(CourseID))
        //        {
        //            return CourseAtIndex;
        //        }
        //    }
        //    return null;
        //}
        public List<SubCourse> GetSubCoursesFromCourseID(int CourseID)
        {
            SubCourseList = new List<SubCourse>();
            String cs = "server = localhost; userid = root; password = Abh1Ank1; database = TrainingLab";

            MySqlConnection con = new MySqlConnection(cs);
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
        //public int UpdateUser(User user)
        //{
        //    for (int i = 0; i < userList.Count; i++)
        //    {
        //        User userAtIndex = userList.ElementAt(i);
        //        if (userAtIndex.AccNo.Equals(user.AccNo))
        //        {
        //            userList[i] = user;

        //            String cs = "Data Source=/Users/abii/Projects/Bank/Bank/bankDatabase.db; Version=3;";

        //            SQLiteConnection con = new SQLiteConnection(cs);
        //            con.Open();
        //            string query = "UPDATE BankAcc SET Name=\"" + user.Name + "\", AccNo=" + user.AccNo + ", Balance=" + user.Bal + " WHERE AccNo=" + user.AccNo + ";";
        //            SQLiteCommand command = new SQLiteCommand(con);

        //            command.CommandText = query;

        //            command.ExecuteNonQuery();
        //            con.Close();

        //            return 1;
        //        }

        //    }

        //    return 0;
        //}
    }
}


