using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data.SqlClient;
using UniversityManagementSystemApp.Models;

namespace UniversityManagementSystemApp.Gateway
{
    public class DepartmentGateway:BaseGateway
    {
        public DepartmentGateway()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["UniversityDB"].ConnectionString;
            connection = new SqlConnection(connectionString);
        }

        public int Save(Department department)
        {
            string query = "Insert into Departments (Code,Name) values(@code,@name)";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@code", department.Code);
            command.Parameters.AddWithValue("@name", department.Name);

            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();

            return rowAffect;
        }

        public bool IsDeptExit(string code)
        {
            string query = "Select * from Departments where Code = @code";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@code", code);
            connection.Open();
            reader = command.ExecuteReader();
            bool isExits = reader.HasRows;
            reader.Close();
            connection.Close();
            return isExits;
        }

        public List<Department>  GetDepartments()
        {
            string query = "select * from Departments";
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();

            List<Department> departmentList = new List<Department>();

            while (reader.Read())
            {
                Department department = new Department();
                department.Id = Convert.ToInt32(reader["DeptId"]);
                department.Code = reader["Code"].ToString();
                department.Name = reader["Name"].ToString();
                departmentList.Add(department);
            }
            reader.Close();
            connection.Close();
            return departmentList;
        }
    }
}