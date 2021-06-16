using System;
namespace WebApi.CourseServices
{
    public class SubCourse
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
        string url;
        public String Url
        {
            get { return url; }
            set { url = value; }
        }
        int subCourseID;
        public int SubCourseID
        {
            get { return subCourseID; }
            set { subCourseID = value; }
        }



    }
}
