using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleWebAPI.Models
{
    public class Course
    {
        public String Name { get; set; }
        public String TemplateID { get; set; }
        public int ID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Student> Students { get; set; }
    }
}