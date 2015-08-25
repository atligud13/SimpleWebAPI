using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SimpleWebAPI.Models
{
    public class Course
    {
        /// <summary>
        /// Name of the course
        /// </summary>
        [Required]
        public String Name { get; set; }

        /// <summary>
        /// Template ID of the course
        /// </summary>
        [Required]
        public String TemplateID { get; set; }

        /// <summary>
        /// Database ID for this course
        /// </summary>
        [Required]
        public int ID { get; set; }

        /// <summary>
        /// Start date of this course
        /// </summary>
        [Required]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// End date of this course
        /// </summary>
        [Required]
        public DateTime EndDate { get; set; }

        /// <summary>
        /// A list of students enrolled in the course
        /// </summary>
        [Required]
        public List<Student> Students { get; set; }
    }
}