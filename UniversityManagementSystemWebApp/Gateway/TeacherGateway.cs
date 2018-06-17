using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Gateway
{
    public class TeacherGateway :CommonGateway
    {
        public int Save(Teacher teacher)
        {
            string query = "INSERT INTO Teacher VALUES('" + teacher.Name + "','" + teacher.Address + "','" + teacher.Email + "','" + teacher.ContactNo + "','" + teacher.DesignationId + "','" + teacher.DepartmentId + "','" + teacher.Credit + "')";

            Command = new SqlCommand(query, Connection);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }

        public bool IsTeacherExist(string name, string email)
        {
            string query = "SELECT * FROM Teacher WHERE Name = '" + name + "' AND Email = '" + email + "'";

            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool isExists = Reader.HasRows;
            Connection.Close();
            return isExists;
        }

        public List<Teacher> GetTeachersByDepartmentId(int departmentId)
        {
            string query = "SELECT * FROM Teacher WHERE DepartmentId=" + departmentId;

            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Teacher> teachers = new List<Teacher>();
            while (Reader.Read())
            {
                Teacher teacher = new Teacher();
                teacher.Id = Convert.ToInt32(Reader["Id"]);
                teacher.Name = Reader["Name"].ToString();
                teacher.Credit = Convert.ToDecimal(Reader["Credit"]);

                teachers.Add(teacher);
            }
            Connection.Close();

            return teachers;
        }

        public Teacher GetTeacherById(int id)
        {
            string query = "SELECT * FROM Teacher WHERE Id = " + id;

            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            Reader.Read();
            Teacher teacher = new Teacher();
            if (Reader.HasRows)
            {
                teacher.Id = Convert.ToInt32(Reader["Id"]);
                teacher.Credit = Convert.ToDecimal(Reader["Credit"]);

            }
            Connection.Close();
            return teacher;
        }
    }
}