using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcEvidence.Models.Metadata
{
    public partial class StudentType
    {
        public int StudentId { get; set; }
        [Required, StringLength(50), Display(Name = "Student Name")]
        public string StudentName { get; set; }

        [StringLength(150), Display(Name = "Student Image")]
        public string StudentImage { get; set; }
        [Required, Display(Name = "Course Name")]
        public int CourseId { get; set; }
        [Required, DataType(DataType.Date), Display(Name = "Enrollment Date"),
           DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime EnrollmentDate { get; set; }


    }
    public class CourseType
    {
        public int CourseId { get; set; }
        [Required, StringLength(50), Display(Name = "Course Name")]
        public string CourseName { get; set; }

    }
}