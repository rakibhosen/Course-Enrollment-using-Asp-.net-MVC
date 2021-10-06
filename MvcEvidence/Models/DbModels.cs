using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcEvidence.Models
{
    public class CourseDbContext : DbContext
    {
        public CourseDbContext() : base("CourseDbContext")
        {
        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}