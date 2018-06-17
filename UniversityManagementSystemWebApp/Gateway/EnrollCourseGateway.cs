using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Gateway
{
    public class EnrollCourseGateway : CommonGateway
    {
        public int Save(EnrollCourse enrollCourse)
        {
            string query = "INSERT INTO CourseEnroll VALUES('" + enrollCourse.StudentId + "','" + enrollCourse.CourseId +
                           "','" + enrollCourse.Date + "')";

            Command = new SqlCommand(query, Connection);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }

        public bool IsCourseEnrolled(EnrollCourse enrollCourse)
        {
            string query = "SELECT * FROM CourseEnroll WHERE StudentId = '" +
                           enrollCourse.StudentId + "' AND CourseId = '" + enrollCourse.CourseId + "' ";

            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool isExists = Reader.HasRows;
            Connection.Close();
            return isExists;
        }

        public List<int> GetCourseIdsByStudentId(int studentId)
        {
            string query = "SELECT * FROM CourseEnroll WHERE StudentId = " + studentId;

            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<int> idList = new List<int>();
            while (Reader.Read())
            {
                int id = Convert.ToInt32(Reader["CourseId"]);
                
                idList.Add(id);
            }
            Connection.Close();
            return idList;
        }

        public int GetEnrollId(StudentResult studentResult)
        {
            string query = "SELECT * FROM CourseEnroll WHERE StudentId = '" +
                           studentResult.StudentId + "' AND CourseId = '" + studentResult.CourseId + "' ";

            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            Reader.Read();
            int id = 0;
            if (Reader.HasRows)
            {
                id = Convert.ToInt32(Reader["Id"]);
            }
            
            Connection.Close();
            return id;
        }
    }
}