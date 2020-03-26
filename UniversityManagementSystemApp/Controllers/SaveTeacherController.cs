using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemApp.Manager;
using UniversityManagementSystemApp.Models;

namespace UniversityManagementSystemApp.Controllers
{
    public class SaveTeacherController : Controller
    {
        public SaveTeacherManager SaveTeacherManager { get; set; }
        public DepartmentManager DepartmentManager { get; set; }

        public SaveTeacherController()
        {
            SaveTeacherManager = new SaveTeacherManager();
            DepartmentManager = new DepartmentManager();
        }
        // GET: SaveTeacher
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult SaveTeacher()
        {
            ViewBag.Designation = SaveTeacherManager.GetDesignations();
            ViewBag.Department = DepartmentManager.GetDepartments();
            return View();
        }

        [HttpPost]
        public ActionResult SaveTeacher(SaveTeacher saveTeacher)
        {
            ViewBag.Designation = SaveTeacherManager.GetDesignations();
            ViewBag.Department = DepartmentManager.GetDepartments();
            string message = SaveTeacherManager.Save(saveTeacher);
            ViewBag.Message = message;
            return View();
        }

        [HttpGet]
        public ActionResult CourseAssignTeacher()
        {
            return View();
        }
    }
}