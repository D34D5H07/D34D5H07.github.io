using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Gateway
{
    public class CourseGateway : CommonGateway
    {
        public int Save(Course course)
        {
            string query = "INSERT INTO Course VALUES('" + course.Code + "','" + course.Name + "','" + course.Credit + "','" + course.Description + "','" + course.DepartmentId + "','" + course.SemesterId + "')";

            Command = new SqlCommand(query, Connection);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }

        public bool IsCourseExist(string code)
        {
            string query = "SELECT * FROM Course WHERE Code = '" + code + "'";

            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool isExists = Reader.HasRows;
            Connection.Close();
            return isExists;
        }

        public List<Course> GetCoursesByDepartmentId(int deptId)
        {
            string query = "SELECT * FROM Course WHERE DepartmentId = " + deptId;

            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Course> courses = new List<Course>();
            while (Reader.Read())
            {
                Course course = new Course();
                course.Id = Convert.ToInt32(Reader["Id"]);
                course.Code = Reader["Code"].ToString();
                course.Name = Reader["Name"].ToString();
                course.Credit = Convert.ToDecimal(Reader["Credit"]);
                course.Description = Reader["Description"].ToString();
                course.DepartmentId = Convert.ToInt32(Reader["DepartmentId"]);
                course.SemesterId = Convert.ToInt32(Reader["SemesterId"]);

                courses.Add(course);
            }
            Connection.Close();
            return courses;
        }

        public Course GetCourseById(int id)
        {
            string query = "SELECT * FROM Course WHERE Id = " + id;

            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            Reader.Read();
            Course course = new Course();
            if (Reader.HasRows)
            {
                course.Id = Convert.ToInt32(Reader["Id"]);
                course.Name = Reader["Name"].ToString();
                course.Credit = Convert.ToDecimal(Reader["Credit"]);

            }
            Connection.Close();
            return course;
        }
    }
}