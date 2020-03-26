using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemApp.Models
{
    public class CourseAssignTeacher
    {
        public int Id { get; set; }
        public int DeptId { get; set; }
        public int TeacherId { get; set; }
        public int CourseId { get; set; }
        public string Action { get; set; }

    }
}