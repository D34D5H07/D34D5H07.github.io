using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Web;
using UniversityManagementSystemWebApp.Gateway;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Manager
{
    public class CourseManager
    {
        public CourseGateway CourseGateway { get; set; }

        public CourseManager()
        {
            CourseGateway = new CourseGateway();
        }

        public string Save(Course course)
        {
            if (CourseGateway.IsCourseExist(course.Code))
            {
                return "Course Is Already Exists.";
            }
            else
            {
                int rowAffect = CourseGateway.Save(course);

                if (rowAffect > 0)
                {
                    return "Course Save Successful";
                }
                else
                {
                    return "Save Failed";
                }
            }
        }

        public List<Course> GetCoursesByDepartmentId(int deptId)
        {
            return CourseGateway.GetCoursesByDepartmentId(deptId);
        }

        public Course GetCourseById(int id)
        {
            return CourseGateway.GetCourseById(id);
        }
    }
}