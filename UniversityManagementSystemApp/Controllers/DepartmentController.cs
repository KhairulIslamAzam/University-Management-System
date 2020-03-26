using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemApp.Manager;
using UniversityManagementSystemApp.Models;

namespace UniversityManagementSystemApp.Controllers
{
    public class DepartmentController : Controller
    {
        public DepartmentManager DepartmentManager { get; set; }

        public DepartmentController()
        {
            DepartmentManager = new DepartmentManager();
        }
        // GET: Department

        [HttpGet]
        public ActionResult SaveDepartment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveDepartment(Department department)
        {
            string message = DepartmentManager.Save(department);
            ViewBag.Message = message;
            return View();
        }


        public ActionResult GetAllDepartments()
        {
            List<Department> departmentList = new List<Department>();
            departmentList = DepartmentManager.GetDepartments();
            return View(departmentList);
        }

    }
}