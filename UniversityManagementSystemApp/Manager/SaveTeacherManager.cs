using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemApp.Gateway;
using UniversityManagementSystemApp.Models;

namespace UniversityManagementSystemApp.Manager
{
    public class SaveTeacherManager
    {
        public SaveTeacherGateway SaveTeacherGateway { get; set; }

        public SaveTeacherManager()
        {
            SaveTeacherGateway = new SaveTeacherGateway();
        }

        public string Save(SaveTeacher saveTeacher)
        {
            if (SaveTeacherGateway.IsExitTeacher(saveTeacher.Email))
            {
                return "The teacher is already Exit";
            }
            else
            {
                int rowAffect = SaveTeacherGateway.Save(saveTeacher);
                if (rowAffect > 0)
                {
                    return "Save Successfull";
                }
                else
                {
                    return "Tray again";
                }
            }
        }

        public List<Designation> GetDesignations()
        {
            return SaveTeacherGateway.GetDesignations();
        }

        public List<SaveTeacher> GetTeachers()
        {
            return SaveTeacherGateway.GetTeachers();
        }

        public string Save(CourseAssignTeacher courseAssignTeacher)
        {
            if (SaveTeacherGateway.IsExitCourseTeacher(courseAssignTeacher.CourseId))
            {
                return "Already assign this course to the teacher";
            }
            else
            {
                int rowAffect = SaveTeacherGateway.Save(courseAssignTeacher);

                if (rowAffect > 0)
                {
                    return "Assign Course to Teacher successfully done";
                }
                else
                {
                    return "Try Again!!!";
                }
            }
        }

        public List<SaveTeacher> GetTeachersById(CourseAssignTeacher courseAssignTeacher)
        {
            return SaveTeacherGateway.GetTeachersById(courseAssignTeacher.DeptId);
        }

        public SaveTeacher GetTeacherCreditById(SaveTeacher saveTeacher)
        {
            return SaveTeacherGateway.GetTeacherCreditById(saveTeacher.TeacherId);
        }

        public List<Course> GetCourseCodeByDeptId(Course course)
        {
            return SaveTeacherGateway.GetCourseCodeByDeptId(course.DeptId);
        }

        public Course GetCourseNameByCourseId(Course course)
        {
            return SaveTeacherGateway.GetCourseNameByCourseId(course.CourseId);
        }

        //public double GetSumOfCreditTakenByTeacherId(CourseAssignTeacher courseAssignTeacher)
        //{
        //   // return SaveTeacherGateway.GetSumOfCreditTakenByTeacherId(courseAssignTeacher.TeacherId);
        //}
    }
}