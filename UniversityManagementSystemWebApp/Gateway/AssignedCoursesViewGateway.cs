using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystemWebApp.Models;
using UniversityManagementSystemWebApp.Models.ViewModels;

namespace UniversityManagementSystemWebApp.Gateway
{
    public class AssignedCoursesViewGateway : CommonGateway
    {
        public List<AssignedCoursesView> GetAllAssignedCourses(int departmentId)
        {
            string query = "SELECT * FROM AssignedCoursesView WHERE DepartmentId = '" + departmentId + "'";

            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<AssignedCoursesView> assignedCourses = new List<AssignedCoursesView>();
            while (Reader.Read())
            {
                AssignedCoursesView assignedCoursesView = new AssignedCoursesView();
                assignedCoursesView.CourseCode = Reader["CourseCode"].ToString();
                assignedCoursesView.CourseName = Reader["CourseName"].ToString();
                assignedCoursesView.SemesterName = Reader["SemesterName"].ToString();
                assignedCoursesView.AssignedTeacherName = Reader["TeacherName"].ToString();

                assignedCourses.Add(assignedCoursesView);
            }
            Connection.Close();
            return assignedCourses;
        }
    }
}