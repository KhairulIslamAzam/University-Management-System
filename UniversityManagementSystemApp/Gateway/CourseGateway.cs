using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using UniversityManagementSystemApp.Models;

namespace UniversityManagementSystemApp.Gateway
{
    public class CourseGateway : BaseGateway
    {
        public CourseGateway()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["UniversityDB"].ConnectionString;
            connection = new SqlConnection(connectionString);
        }

        //saving all courses
        public int Save(Course course)
        {
            string query = "Insert into Course (CourseCode, CourseName,Credit, Description, DeptId, SemesterId) " +
                "values(@courseCode,@courseName,@credit,@description, @deptId, @semesterId)";

            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@courseCode", course.CourseCode);
            command.Parameters.AddWithValue("@courseName", course.CourseName);
            command.Parameters.AddWithValue("@credit", course.Credit);
            command.Parameters.AddWithValue("@description", course.Description);
            command.Parameters.AddWithValue("@deptId", course.DeptId);
            command.Parameters.AddWithValue("@semesterId", course.SemesterId);

            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;


        }

        public bool IsExitCourse(string code, int deptId)
        {
            string query = "Select * from Course where CourseCode = @courseCode and DeptId = @deptId";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@courseCode", code);
            command.Parameters.AddWithValue("@deptId", deptId);

            connection.Open();
            reader = command.ExecuteReader();
            bool isExit = reader.HasRows;
            connection.Close();
            reader.Close();
            return isExit;
        }

        //Get all semester from database
        public List<Semester> GetSemesters()
        {
            string query = "select * from Semester";
            command = new SqlCommand(query, connection);
            List<Semester> semesterList = new List<Semester>();
            Semester semester = null;
            connection.Open();
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                semester = new Semester();
                semester.SemesterId = Convert.ToInt32(reader["SemesterId"]);
                semester.SemesterName = reader["SemesterName"].ToString();
                semesterList.Add(semester);
            }
            reader.Close();
            connection.Close();
            return semesterList;
        }

        //get all course
        public List<Course> GetCourses()
        {
            string query = "select * from Course";
            command = new SqlCommand(query, connection);
            List<Course> courseList = new List<Course>();
            Course course = null;
            connection.Open();
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                course = new Course();
                course.CourseId = Convert.ToInt32(reader["CourseId"]);
                course.CourseCode = reader["CourseCode"].ToString();
                course.CourseName = reader["CourseName"].ToString();
                course.Credit = Convert.ToDouble(reader["Credit"]);
                course.DeptId = Convert.ToInt32(reader["DeptId"]);
                course.SemesterId = Convert.ToInt32(reader["SemesterId"]);
                courseList.Add(course);


            }
            reader.Close();
            connection.Close();
            return courseList;
        }
    }
}