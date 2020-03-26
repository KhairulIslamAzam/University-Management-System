using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemApp.Gateway;
using UniversityManagementSystemApp.Models;

namespace UniversityManagementSystemApp.Manager
{
    public class DepartmentManager
    {
        public DepartmentGateway DepartmentGateway { get; set; }

        public DepartmentManager()
        {
            DepartmentGateway = new DepartmentGateway();
        }

        public string Save(Department department)
        {

            if(DepartmentGateway.IsDeptExit(department.Code))
            {
                return "Department already Exit";
            }
            else
            {
                int rowAffect = DepartmentGateway.Save(department);

                if (rowAffect > 0)
                {
                    return "Save Successfull";
                }
                else
                {
                    return "Try Again!!!";
                }
            }
        }

        public List<Department> GetDepartments()
        {
            return DepartmentGateway.GetDepartments();
        }
    }
}