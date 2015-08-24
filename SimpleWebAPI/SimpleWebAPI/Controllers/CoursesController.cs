using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

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
        public class Course
        {
            String Name;
            int TemplateID;
            int ID;
            DateTime StartDate;
            DateTime EndDate;
        }

        public class Student
        {
            int SSN;
            String Name;
        }

        [HttpGet]
        [Route("courses")]
        public List<Course> GetCourses(){
            return null;
        }

    }
}
