using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SimpleWebAPI.Models;

namespace SimpleWebAPI.Controllers
{
    /// <summary>
	/// Courses is the main resource for course instances, i.e. a course
	/// which is taught on a given semester. For simplicity, the term
	/// "course" will always refer to an instance of a course in the
	/// documentation.
	/// </summary>
	///[RoutePrefix(System.Web.Mvc.Routing.PROJECT_ROOT + Routing.ROUTE_PREFIX + "courses")]
    public class CoursesController : ApiController
    {
        private static List<Course> _courses;
        public CoursesController()
        {
            if(_courses == null)
            {
                _courses = new List<Course>
                {
                    new Course
                    {
                        ID         = 1,
                        Name       = "Web services",
                        TemplateID = "T-514-VEFT",
                        StartDate  = DateTime.Now,
                        EndDate    = DateTime.Now.AddMonths(3)
                    },
                    new Course
                    {
                        ID         = 2,
                        Name       = "App Development",
                        TemplateID = "T-433-ANDR",
                        StartDate  = DateTime.Now,
                        EndDate    = DateTime.Now.AddMonths(3)
                    }
                };
            }
        }

        [HttpGet]
        [Route("courses")]
        public List<Course> GetCourses(){
            return null;
        }

    }
}
