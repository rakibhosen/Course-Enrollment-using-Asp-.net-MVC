using MvcEvidence.Models.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcEvidence.Models
{
    [MetadataType(typeof(StudentType))]
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentImage { get; set; }
        public int CourseId { get; set; }
        public System.DateTime EnrollmentDate { get; set; }

        public virtual Course Course { get; set; }
    }
}