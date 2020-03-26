using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemApp.Gateway;
using UniversityManagementSystemApp.Manager;
using UniversityManagementSystemApp.Models;

namespace UniversityManagementSystemApp.Controllers
{
    public class CourseController : Controller
    {
        public CourseManager CourseManager { get; set; }
        public DepartmentManager DepartmentManager { get; set; }

        public CourseController()
        {
            CourseManager = new CourseManager();
            DepartmentManager = new DepartmentManager();
        }
        // GET: Course
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]

        public ActionResult SaveCourse()
        { 
            ViewBag.Department = DepartmentManager.GetDepartments();
            ViewBag.Semester = CourseManager.GetSemesters();
            return View();
        }

        [HttpPost]
        public ActionResult SaveCourse(Course course)
        {
            ViewBag.Department = DepartmentManager.GetDepartments();
            ViewBag.Semester = CourseManager.GetSemesters();
            string message = CourseManager.Save(course);
            ViewBag.Message = message;
            return View();
        }
    }
}