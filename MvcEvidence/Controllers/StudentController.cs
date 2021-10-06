using MvcEvidence.Models;
using MvcEvidence.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcEvidence.Controllers
{
    public class StudentController : Controller
    {
        readonly CourseDbContext db = new CourseDbContext();
        // GET: Home
        public ActionResult Index()
        {

            return View(db.Students.ToList());
        }


        public ActionResult Create()
        {
            ViewBag.Courses = db.Courses.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(StudentViewModel s)
        {
            if (ModelState.IsValid)
            {
                Student st = new Student { StudentName = s.StudentName, CourseId = s.CourseId, StudentImage = "no-pic.png", EnrollmentDate = s.EnrollmentDate };
                if (s.StudentImage != null)
                {
                    string fileName = Guid.NewGuid() + Path.GetExtension(s.StudentImage.FileName);
                    s.StudentImage.SaveAs(Server.MapPath("~/Images/") + fileName);
                    st.StudentImage = fileName;
                }
                db.Students.Add(st);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Courses = db.Courses.ToList();
            return View(s);
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Courses = db.Courses.ToList();
            var s = db.Students.First(x => x.StudentId == id);
            ViewBag.Pic = s.StudentImage;
            return View(new Student { StudentId = s.StudentId, StudentName = s.StudentName, CourseId = s.CourseId, EnrollmentDate = s.EnrollmentDate });

        }

        [HttpPost]
        public ActionResult Edit(StudentViewModel s)
        {
            var st = db.Students.First(x => x.StudentId == s.StudentId);
            if (ModelState.IsValid)
            {

                st.StudentName = s.StudentName;
                st.EnrollmentDate = s.EnrollmentDate;

                st.CourseId = s.CourseId;
                if (s.StudentImage != null)
                {
                    string fileName = Guid.NewGuid() + Path.GetExtension(s.StudentImage.FileName);
                    s.StudentImage.SaveAs(Server.MapPath("~/Images/") + fileName);
                    st.StudentImage = fileName;
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Pic = s.StudentImage;
            ViewBag.Courses = db.Courses.ToList();
            return View(s);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            Student s = new Student { StudentId = id };
            db.Entry(s).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}