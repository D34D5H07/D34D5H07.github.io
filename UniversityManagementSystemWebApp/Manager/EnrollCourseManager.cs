using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemWebApp.Gateway;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Manager
{
    public class EnrollCourseManager
    {

        public EnrollCourseGateway EnrollCourseGateway { get; set; }

        public StudentGateway StudentGateway { get; set; }

        public EnrollCourseManager()
        {
            EnrollCourseGateway=new EnrollCourseGateway();
            StudentGateway=new StudentGateway();
        }
        public string Save(EnrollCourse enrollCourse)
        {
            if (EnrollCourseGateway.IsCourseEnrolled(enrollCourse))
            {
                return "Course Is Already Enrolled.";
            }
            else
            {
                int rowAffect = EnrollCourseGateway.Save(enrollCourse);

                if (rowAffect > 0)
                {
                    return "Successfully Enroll";
                }
                else
                {
                    return "Enroll Failed";
                }
            }
        }

        public List<int> GetCourseIdsByStudentId(int studentId)
        {
            return EnrollCourseGateway.GetCourseIdsByStudentId(studentId);
        }

        public int GetEnrollId(StudentResult studentResult)
        {
            return EnrollCourseGateway.GetEnrollId(studentResult);
        }

        //public Student GetStudentById(int id)
        //{
        //    return StudentGateway.GetStudentById(id);
        //}
    }
}