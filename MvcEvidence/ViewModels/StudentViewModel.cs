using MvcEvidence.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcEvidence.ViewModels
{
    public class StudentViewModel
    {
        public int StudentId { get; set; }
        [Required, Display(Name = "Course Name")]
        public int CourseId { get; set; }

        [Required, StringLength(50), Display(Name = "Student Name")]
        public string StudentName { get; set; }

        [Required, Display(Name = "Enrollment Date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime EnrollmentDate { get; set; }

        [Display(Name = "Student Image")]
        public HttpPostedFileBase StudentImage { get; set; }
        public virtual Course Course { get; set; }
    }
}