using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SimpleWebAPI.Models
{
    public class Student
    {
        /// <summary>
        /// Social security number of this student
        /// </summary>
        [Required]
        public String SSN;

        /// <summary>
        /// The name of this student
        /// </summary>
        [Required]
        public String Name;
    }
}