using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Gateway
{
    public class StudentGateway : CommonGateway
    {
        public int Save(Student student)
        {
            string query = "INSERT INTO Student VALUES('" + student.RegistrationNo + "','" + student.Name + "','" +
                           student.Email + "','" + student.ContactNo + "','" + student.Date + "','" + student.Address +
                           "','" + student.DepartmentId + "')";

            Command = new SqlCommand(query, Connection);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }

        public bool IsEmailExist(string email)
        {
            string query = "SELECT * FROM Student WHERE Email = '" + email + "'";

            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool isExists = Reader.HasRows;
            Connection.Close();
            return isExists;
        }

        public int SerialNo(string deptCode, string year)
        {
            string query = "SELECT COUNT(RegistrationNo) AS SLNo FROM Student WHERE RegistrationNo LIKE '" + deptCode +
                           "-" + year + "%' ";

            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            int slNo = 0;
            while (Reader.Read())
            {
                slNo = Convert.ToInt32(Reader["SLNo"]);
            }
            Connection.Close();
            return slNo;
        }

        public List<Student> GetAllStudents()
        {
            string query = "SELECT * FROM Student";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Student> students = new List<Student>();
            while (Reader.Read())
            {
                Student student = new Student();
                student.Id = Convert.ToInt32(Reader["Id"]);
                student.RegistrationNo = Reader["RegistrationNo"].ToString();

                students.Add(student);
            }

            Connection.Close();

            return students;
        }

        public Student GetStudentById(int id)
        {
            string query = "SELECT * FROM Student WHERE Id =" + id;

            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            Reader.Read();
            Student student = new Student();
            if (Reader.HasRows)
            {
                student.Id = Convert.ToInt32(Reader["Id"]);
                student.RegistrationNo = Reader["RegistrationNo"].ToString();
                student.Name = Reader["Name"].ToString();
                student.Email = Reader["Email"].ToString();
                student.ContactNo = Reader["ContactNo"].ToString();
                student.Date = Convert.ToDateTime(Reader["Date"]);
                student.Address = Reader["Address"].ToString();
                student.DepartmentId = Convert.ToInt32(Reader["DepartmentId"]);

            }
            Connection.Close();

            return student;
        }
    }
}