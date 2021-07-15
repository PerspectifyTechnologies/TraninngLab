using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;
using WebApi.CourseServices;
/*
 * Changes mentioned in the last code review were related to naming convention of routes.
 * These changes are not implemented as it has already been implemented in the front end.
 * We as a team will sit together and clean up the code. A sit together with front end 
 * and backend was not possible before the code review. 
 */

namespace WebApi.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class QueryCoursesController : ControllerBase
    {
        public List<Course> GetCourse()
        {


            return RetrieveCourse.getInstance().getAllCourses();

        }
        [HttpGet]
        [Route("SubCourses")]
        public List<SubCourse> GetSubCourse([FromQuery] int SubCourseID)
        {
            return RetrieveSubCourse.getInstance().GetSubCoursesFromCourseID(SubCourseID);
        }
    }
}