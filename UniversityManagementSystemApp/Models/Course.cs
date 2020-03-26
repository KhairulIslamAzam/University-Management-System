﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemApp.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public double Credit { get; set; }
        public string Description { get; set; }
        public int DeptId { get; set; }
        public int SemesterId { get; set; }
    }
}