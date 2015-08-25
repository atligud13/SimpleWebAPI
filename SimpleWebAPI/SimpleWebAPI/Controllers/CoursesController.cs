using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SimpleWebAPI.Models;
using System.Web.Http.Description;

namespace SimpleWebAPI.Controllers
{
    /// <summary>
	/// Courses is the main resource for course instances, i.e. a course
	/// which is taught on a given semester. For simplicity, the term
	/// "course" will always refer to an instance of a course in the
	/// documentation.
	/// </summary>
    [RoutePrefix("api/v1/courses")]
    public class CoursesController : ApiController
    {
        // Mock list of courses being used for this assignment
        private static List<Course> _courses;

        // Initiates a new list of mock objects if not already created
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
                        EndDate    = DateTime.Now.AddMonths(3),
                        Students   = new List<Student>
                        {
                            new Student
                            {
                                SSN = "1507922319",
                                Name = "Atli Guðlaugsson"
                            },
                            new Student
                            {
                                SSN = "0101922189",
                                Name = "Kormákur Þorláksson"
                            }
                        }
                    },
                    new Course
                    {
                        ID         = 2,
                        Name       = "App Development",
                        TemplateID = "T-433-ANDR",
                        StartDate  = DateTime.Now,
                        EndDate    = DateTime.Now.AddMonths(3),
                        Students   = new List<Student>
                        {
                            new Student
                            {
                                SSN = "1507922319",
                                Name = "Daníel Brandur"
                            }
                        }
                    }
                };
            }
        }

        /// <summary>
        /// Returns a list of all courses
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public List<Course> GetCourses(){
            return _courses;
        }

        /// <summary>
        /// Returns a single course with the given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}", Name = "GetCourse")]
        public Course GetCourseById(int id)
        {
            var course = _courses.Find(x => id == x.ID);
            if (course == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return course;
        }

        /// <summary>
        /// Adds a new course to the list
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(Course))]
        public IHttpActionResult AddCourse(Course newCourse)
        {
            // Checking if the object is not valid
            if (newCourse == null) throw new HttpResponseException(HttpStatusCode.PreconditionFailed);
            if (!ModelState.IsValid) throw new HttpResponseException(HttpStatusCode.PreconditionFailed);

            // Generating an ID for the object
            int id = _courses.Last().ID + 1;

            // Creating the course and adding it to the list
            Course course = new Course
            {
                ID = id,
                Name = newCourse.Name,
                TemplateID = newCourse.TemplateID,
                StartDate = newCourse.StartDate,
                EndDate = newCourse.EndDate
            };
            _courses.Add(course);

            // Getting the location and returning the create status code
            var location = Url.Link("GetCourse", new { id = course.ID });
            return Created(location, course);
        }

        /// <summary>
        /// Updates the course with the given id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newCourse"></param>
        /// <returns></returns>
        [HttpPut]
        [ResponseType(typeof(Course))]
        [Route("{id:int}")]
        public IHttpActionResult UpdateCourse(int id, Course newCourse)
        {
            // Checking if the object is not valid
            if (newCourse == null) throw new HttpResponseException(HttpStatusCode.PreconditionFailed);
            if (!ModelState.IsValid) throw new HttpResponseException(HttpStatusCode.PreconditionFailed);

            // Finding the course
            var course = _courses.Find(x => newCourse.ID == x.ID);
            if (course == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            //Course was found, updating it
            course.Name = newCourse.Name;
            course.TemplateID = newCourse.TemplateID;
            course.StartDate = newCourse.StartDate;
            course.EndDate = newCourse.EndDate;
            return Ok();
        }

        /// <summary>
        /// Deletes the course with the given ID
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete]
        [Route("{id:int}")]
        public void DeleteCourse(int id)
        {
            // Finding the course
            var course = _courses.Find(x => id == x.ID);
            if (course == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            // Course was found, deleting it
            _courses.Remove(course);

            // Void returns 204
        }

        /// <summary>
        /// Returns the student list from a course with the given ID
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}/students", Name = "GetStudents")]
        public List<Student> GetStudents(int id)
        {
            // Finding the course
            var course = _courses.Find(x => id == x.ID);
            if (course == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            // Course was found, returning the student list
            return course.Students;
        }

        /// <summary>
        /// Adds the student to the course with the given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("{id:int}/students")]
        public IHttpActionResult AddStudent(int id, Student newStudent)
        {
            // Checking if the object is not valid
            if (newStudent == null) throw new HttpResponseException(HttpStatusCode.PreconditionFailed);
            if (!ModelState.IsValid) throw new HttpResponseException(HttpStatusCode.PreconditionFailed);

            // Finding the course
            var course = _courses.Find(x => id == x.ID);
            if (course == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            // Course was found, creating the student and adding 
            // it to the user list
            Student student = new Student
            {
                SSN = newStudent.SSN,
                Name = newStudent.Name
            };
            course.Students.Add(student);
            var location = Url.Link("GetStudents", new { id = course.ID });
            return Created(location, student);
        }
    }
}
