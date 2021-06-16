using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;
using WebApi.CourseServices;


namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueryCoursesController : ControllerBase
    {
        public List<Course> GetCourse()
        {


            return Retrieve.getInstance().getAllCourses();

        }
        [HttpGet]
        [Route("SubCourses")]
        public List<SubCourse> GetSubCourse([FromQuery] int SubCourseID)
        {
            return RetrieveSubCourse.getInstance().GetSubCoursesFromCourseID(SubCourseID);
        }
    }
}