using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemWebApp.Gateway;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Manager
{
    public class StudentManager
    {
         public StudentGateway StudentGateway { get; set; }
        public DepartmentManager DepartmentManager { get; set; }

         public StudentManager()
        {
            StudentGateway = new StudentGateway();
             DepartmentManager = new DepartmentManager();
        }

        public string Save(Student student)
        {
            if (StudentGateway.IsEmailExist(student.Email))
            {
                return "Email Is Already Exist.";
            }
            else
            {
                int rowAffect = StudentGateway.Save(student);

                if (rowAffect > 0)
                {
                    return "Student Registration Is Successfull";
                }
                else
                {
                    return "Register Failed";
                }
            }
        }

        public int SerialNo(string deptCode, string year)
        {
            return StudentGateway.SerialNo(deptCode, year);
        }

        public List<Student> GetAllStudents()
        {
            return StudentGateway.GetAllStudents();
        }

        public Student GetStudentById(int id)
        {
            Student student = StudentGateway.GetStudentById(id);
            return student;
        }
    }
}