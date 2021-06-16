using System;
namespace WebApi.CourseServices
{
    public class Course
    {
        int courseID;
        public int CourseID
        {
            get { return courseID; }
            set { courseID = value; }
        }
        string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }



    }
}
