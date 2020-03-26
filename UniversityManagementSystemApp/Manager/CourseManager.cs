using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemApp.Gateway;
using UniversityManagementSystemApp.Models;

namespace UniversityManagementSystemApp.Manager
{
    public class CourseManager
    {
        public CourseGateway CourseGateway { get; set; }
        public CourseManager()
        {
            CourseGateway = new CourseGateway();
        }

        public string Save(Course course)
        {
            if (CourseGateway.IsExitCourse(course.CourseCode, course.DeptId))
            {
                return "Course Already Exited";
            }
            else
            {
                int rowAffect = CourseGateway.Save(course);
                if (rowAffect > 0)
                {
                    return "Save course Successfully";
                }
                else
                {
                    return "Try again!!!";
                }
            }
        }

        public List<Semester> GetSemesters()
        {
            return CourseGateway.GetSemesters();
        }

        public List<Course> GetCourses()
        {
            return CourseGateway.GetCourses();
        }
    }
}