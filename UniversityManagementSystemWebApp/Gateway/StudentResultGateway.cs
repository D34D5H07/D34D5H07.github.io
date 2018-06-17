using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Gateway
{
    public class StudentResultGateway : CommonGateway
    {
        public int Save(StudentResult studentResult)
        {
            string query = "INSERT INTO Result VALUES('" + studentResult.CourseEnrollId + "','" + studentResult.GradeId + "')";

            Command = new SqlCommand(query, Connection);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }

        public bool IsResultExists(int courseEnrollId)
        {
            string query = "SELECT * FROM Result WHERE CourseEnrollId = '" + courseEnrollId + "'";

            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool isExists = Reader.HasRows;
            Connection.Close();
            return isExists;
        }

        public List<Grade> GetAllGrades()
        {
            string query = "SELECT * FROM Grade";

            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Grade> grades = new List<Grade>();
            while (Reader.Read())
            {
                Grade grade = new Grade();
                grade.Id = Convert.ToInt32(Reader["Id"]);
                grade.LetterGrade = Reader["LetterGrade"].ToString();
               


                grades.Add(grade);
            }
            Connection.Close();
            return grades;
        }
    }
}