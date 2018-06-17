using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Gateway
{
    public class DepartmentGateway : CommonGateway
    {
        public int Save(Department department)
        {
            string query = "INSERT INTO Department VALUES('" + department.Code + "','" + department.Name + "')";

            Command = new SqlCommand(query, Connection);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }

        public bool IsDepartmentExist(Department department)
        {
            string query = "SELECT * FROM Department WHERE Code = '" + department.Code + "' OR Name = '" +
                           department.Name + "'";

            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool isExists = Reader.HasRows;
            Connection.Close();
            return isExists;
        }

        public List<Department> GetAllDepartments()
        {
            string query = "SELECT * FROM Department";

            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Department> departments = new List<Department>();
            while (Reader.Read())
            {
                Department department = new Department();
                department.Id = Convert.ToInt32(Reader["Id"]);
                department.Code = Reader["Code"].ToString();             
                department.Name = Reader["Name"].ToString();

                departments.Add(department);
            }
            Connection.Close();
            return departments;
        }

        public Department GetDepartment(int departmentId)
        {
            string query = "SELECT * FROM Department WHERE Id=" + departmentId;

            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            Reader.Read();
            Department department = new Department();
            if (Reader.HasRows)
            {
                department.Id = Convert.ToInt32(Reader["Id"]);
                department.Code = Reader["Code"].ToString();
                department.Name = Reader["Name"].ToString();
            }
            Connection.Close();

            return department;
        }
    }
}