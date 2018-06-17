using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Gateway
{
    public class CourseAssignGateway : CommonGateway
    {
        public int Save(CourseAssign courseAssign)
        {
            string query = "INSERT INTO CourseAssign VALUES('" + courseAssign.DepartmentId + "','" + courseAssign.TeacherId + "','" + courseAssign.CourseId + "','" + 1 + "')";

            Command = new SqlCommand(query, Connection);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }

        public bool IsCourseAssigned(CourseAssign courseAssign)
        {
            string query = "SELECT * FROM CourseAssign WHERE Active = '" + 1 + "' AND DepartmentId = '" +
                           courseAssign.DepartmentId + "' AND TeacherId = '" + courseAssign.TeacherId +
                           "' AND CourseId = '" + courseAssign.CourseId + "' ";

            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool isExists = Reader.HasRows;
            Connection.Close();
            return isExists;
        }

        public int Update()
        {
            string query = "UPDATE CourseAssign SET Active = '" + 0 + "'";

            Command = new SqlCommand(query, Connection);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }

        //public List<CourseAssign> GetAllAssignedCourses()
        //{
        //    string query = "SELECT * FROM CourseAssign WHERE Active = '" + 1 + "'";

        //    Command = new SqlCommand(query, Connection);
        //    Connection.Open();
        //    Reader = Command.ExecuteReader();
        //    List<CourseAssign> assignedCourses = new List<CourseAssign>();
        //    while (Reader.Read())
        //    {
        //        CourseAssign courseAssign = new CourseAssign();
        //        courseAssign.Id = Convert.ToInt32(Reader["Id"]);
        //        courseAssign.DepartmentId = Convert.ToInt32(Reader["DepartmentId"]);
        //        courseAssign.TeacherId = Convert.ToInt32(Reader["TeacherId"]);
        //        courseAssign.CourseId = Convert.ToInt32(Reader["CourseId"]);

        //        assignedCourses.Add(courseAssign);
        //    }
        //    Connection.Close();
        //    return assignedCourses;
        //}

        public List<CourseAssign> GetCoursesByTeacherId(int teacherId)
        {
            string query = "SELECT * FROM CourseAssign WHERE Active = '" + 1 + "' AND TeacherId = '" + teacherId + "'";

            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<CourseAssign> courses = new List<CourseAssign>();
            while (Reader.Read())
            {
                CourseAssign courseAssign = new CourseAssign();
                courseAssign.Id = Convert.ToInt32(Reader["Id"]);
                courseAssign.TeacherId = Convert.ToInt32(Reader["TeacherId"]);
                courseAssign.CourseId = Convert.ToInt32(Reader["CourseId"]);

                courses.Add(courseAssign);
            }
            Connection.Close();
            return courses;
        }
    }
}