using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using UniversityManagementSystemApp.Models;

namespace UniversityManagementSystemApp.Gateway
{
    public class SaveTeacherGateway:BaseGateway
    {
        public SaveTeacherGateway()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["UniversityDB"].ConnectionString;
            connection = new SqlConnection(connectionString);
        }

        public int Save(SaveTeacher saveTeacher)
        {
            string query = "Insert into SaveTeacher Values(@teacherName,@address,@email,@contact,@designationId,@deptId,@credit)";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@teacherName", saveTeacher.TeacherName);
            command.Parameters.AddWithValue("@address", saveTeacher.Address);
            command.Parameters.AddWithValue("@email", saveTeacher.Email);
            command.Parameters.AddWithValue("@contact", saveTeacher.Contact);
            command.Parameters.AddWithValue("@designationId", saveTeacher.DesignationId);
            command.Parameters.AddWithValue("@deptId", saveTeacher.DeptId);
            command.Parameters.AddWithValue("@credit", saveTeacher.Credit);

            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }

        public bool IsExitTeacher(string email)
        {
            string query = "Select * from SaveTeacher where Email = @email";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@email", email);

            connection.Open();
            reader = command.ExecuteReader();
            bool isExit = reader.HasRows;
            connection.Close();
            reader.Close();
            return isExit;
        }

        //Get all semester from database
        public List<Designation> GetDesignations()
        {
            string query = "select * from Designation";
            command = new SqlCommand(query, connection);
            List<Designation> designationList = new List<Designation>();
            Designation designation = null;
            connection.Open();
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                designation = new Designation();
                designation.DesignationId = Convert.ToInt32(reader["DesignationId"]);
                designation.Name = reader["Name"].ToString();
                designationList.Add(designation);
            }
            reader.Close();
            connection.Close();
            return designationList;
        }

        //Get all teacher 
        public List<SaveTeacher> GetTeachers()
        {
            string query = "select * from SaveTeacher";
            command = new SqlCommand(query, connection);
            List<SaveTeacher> teacherList  = new List<SaveTeacher>();
            SaveTeacher teacher = null;
            connection.Open();
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                teacher = new SaveTeacher();
                teacher.TeacherId = Convert.ToInt32(reader["TeacherId"]);
                teacher.TeacherName = reader["TeacherName"].ToString();
                teacher.DeptId = Convert.ToInt32(reader["DeptId"]);
                teacher.Credit = Convert.ToDouble(reader["Credit"]);
                teacherList.Add(teacher);
            }
            reader.Close();
            connection.Close();
            return teacherList;
        }

        public int Save(CourseAssignTeacher assingTeacher)
        {
            string query = "Insert into CourseAssignTeacher" +
                "Values(@teacherId,@courseId,@action,@deptId)";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@teacherId", assingTeacher.TeacherId);
            command.Parameters.AddWithValue("@courseId", assingTeacher.CourseId);
            command.Parameters.AddWithValue("@action", assingTeacher.Action);
            command.Parameters.AddWithValue("@deptId", assingTeacher.DeptId);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }

        public bool IsExitCourseTeacher(int id)
        {
            string query = "Select * from Course where CourseId = @id";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);

            connection.Open();
            reader = command.ExecuteReader();
            bool isExit = reader.HasRows;
            connection.Close();
            reader.Close();
            return isExit;
        }

        public List<SaveTeacher> GetTeachersById(int deptId)
        {
            string query = "select TeacherId,TeacherName SaveTeacher where DeptId = @deptId";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@deptId", deptId);
            connection.Open();
            reader = command.ExecuteReader();

            List<SaveTeacher> saveTeachersList = new List<SaveTeacher>();
            while (reader.Read())
            {
                SaveTeacher saveTeacher = new SaveTeacher();
                saveTeacher.DeptId = Convert.ToInt32(reader["TeacherId"]);
                saveTeacher.TeacherName = reader["TeacherName"].ToString();
                saveTeachersList.Add(saveTeacher);
            }

            reader.Close();
            connection.Close();
            return saveTeachersList;
        }

        public SaveTeacher GetTeacherCreditById(int teacherId)
        {
            string query = "Select Credit from SaveTeacher where TeacherId = @teacherId";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@teacherId", teacherId);

            connection.Open();
            reader = command.ExecuteReader();

            SaveTeacher saveTeacher = null;
            if (reader.HasRows)
            {
                saveTeacher = new SaveTeacher();
                saveTeacher.Credit = Convert.ToDouble(reader["Credit"]);
                

            }
            reader.Close();
            connection.Close();
            return saveTeacher;
        }

        public List<Course> GetCourseCodeByDeptId(int deptId)
        {
            string query = "select CourseId, CourseCode from Course where DeptId = @deptId";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@deptId", deptId);

            connection.Open();
            reader = command.ExecuteReader();

            List<Course> courseList = new List<Course>();
            while(reader.Read())
            {
                Course course = new Course();
                course.CourseId = Convert.ToInt32(reader["CourseId"]);
                course.CourseCode = reader["CourseCode"].ToString();
                courseList.Add(course);
            }
            reader.Close();
            connection.Close();
            return courseList;
        }

        public Course GetCourseNameByCourseId(int courseId)
        {
            string query = "Select CourseName,Credit from Course where CourseId = @courseId";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@courseId", courseId);

            connection.Open();
            reader = command.ExecuteReader();
            Course course = null;
            if (reader.HasRows)
            {
                reader.Read();
                course.CourseName = reader["CourseName"].ToString();
                course.Credit = Convert.ToDouble(reader["Credit"]);
            }
            reader.Close();
            connection.Close();
            return course;
        }

        //public double GetSumOfCreditTakenByTeacherId(int teacherId)
        //{
        //    string query = "Select Credit from SaveTeacher where TeacherId = @teacherId";
        //    command = new SqlCommand(query, connection);
        //    command.Parameters.AddWithValue("@teacherId", teacherId);

        //    connection.Open();
        //    reader = command.ExecuteReader();
        //    if (reader.HasRows)
        //    {
        //        reader.Close();
        //        string query1 = "";
        //        command = new SqlCommand(query1, connection);
        //        command.Parameters.AddWithValue("@teacherId", teacherId);
        //        command.Parameters.AddWithValue("@insert", "insert");

        //        object sum = command.ExecuteScalar();
        //        connection.Close();

        //        SaveTeacher saveTeacher = new SaveTeacher();
        //        saveTeacher = GetTeacherCreditById(teacherId);
        //        double totalCredit = Convert.ToDouble(saveTeacher.Credit);
        //        double sumOfCreditTaken = Convert.ToDouble(sum);
        //        return totalCredit - sumOfCreditTaken;
        //    }
        //    else
        //    {
        //        reader.Close();
        //        connection.Close();
        //        SaveTeacher saveTeacher = new SaveTeacher();
        //        saveTeacher = GetTeacherCreditById(teacherId);
        //        double sumOfCredit = Convert.ToDouble(saveTeacher.Credit);
        //        return sumOfCredit;
        //    }
        //}
    }
}