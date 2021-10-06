using MvcEvidence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcEvidence.Controllers
{
    public class HomeController : Controller
    {
        readonly CourseDbContext db = new CourseDbContext();
        public ActionResult Index()
        {
            ViewBag.CourseCount = db.Courses.Count();
            ViewBag.StudentCount = db.Students.Count();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}