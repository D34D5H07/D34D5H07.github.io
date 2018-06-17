using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemWebApp.Gateway;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Manager
{
    public class StudentResultManager
    {
        public StudentResultGateway StudentResultGateway { get; set; }
        public CourseManager CourseManager { get; set; }
        public EnrollCourseManager EnrollCourseManager { get; set; }

        public StudentResultManager()
        {
            StudentResultGateway = new StudentResultGateway();
            CourseManager = new CourseManager();
            EnrollCourseManager = new EnrollCourseManager();
        }

        public string Save(StudentResult studentResult)
        {
            if (StudentResultGateway.IsResultExists(studentResult.CourseEnrollId))
            {
                return "Result Is Already Exist.";
            }
            else
            {
                //int enrollId = EnrollCourseManager.GetEnrollId(studentResult);
                int rowAffect = StudentResultGateway.Save(studentResult);

                if (rowAffect > 0)
                {
                    return "Result Saved";
                }
                else
                {
                    return "Save Failed";
                }
            }
        }

        public List<Course> GetCoursesByStudentId(int studentId)
        {
            List<int> ids = EnrollCourseManager.GetCourseIdsByStudentId(studentId);
            List<Course> courses = new List<Course>();
            foreach (int id in ids)
            {
                Course course = CourseManager.GetCourseById(id);
                courses.Add(course);
            }
            return courses;
        } 
        public List<Grade> GetAllGrades()
        {
            return StudentResultGateway.GetAllGrades();
        }
    }
}