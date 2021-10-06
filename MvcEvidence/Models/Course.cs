using MvcEvidence.Models.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcEvidence.Models
{
    [MetadataType(typeof(CourseType))]
    public class Course
    {

        public Course()
        {

            this.Students = new List<Student>();
        }

        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}