using MvcEvidence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcEvidence.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        readonly CourseDbContext db = new CourseDbContext();
        // GET: Home
        public ActionResult Index()
        {

            return View(db.Courses.ToList());
        }


        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(Course c)
        {
            if (ModelState.IsValid)
            {

                db.Courses.Add(c);
                db.SaveChanges();

                return PartialView("_ResultPartial", true);
            }

            return View(c);

        }

        public ActionResult Edit(int id)
        {

            var c = db.Courses.First(x => x.CourseId == id);

            return View(new Course { CourseId = c.CourseId, CourseName = c.CourseName });

        }

        [HttpPost]
        public ActionResult Edit(Course c)
        {
            var cs = db.Courses.First(x => x.CourseId == c.CourseId);
            if (ModelState.IsValid)
            {
                cs.CourseName = c.CourseName;
                db.SaveChanges();
                return PartialView("_ResultPartial", true);
            }
            return View(c);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult Delete(int id)
        {


            Course c = new Course { CourseId = id };
            db.Entry(c).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}