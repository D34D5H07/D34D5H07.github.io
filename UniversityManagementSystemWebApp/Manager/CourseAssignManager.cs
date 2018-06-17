using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemWebApp.Gateway;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Manager
{
    public class CourseAssignManager
    {
        public CourseAssignGateway CourseAssignGateway { get; set; }

        public CourseAssignManager()
        {
            CourseAssignGateway = new CourseAssignGateway();
        }

        public string Save(CourseAssign courseAssign)
        {
            if (CourseAssignGateway.IsCourseAssigned(courseAssign))
            {
                return "Course Is Already Assigned.";
            }
            else
            {
                int rowAffect = CourseAssignGateway.Save(courseAssign);

                if (rowAffect > 0)
                {
                    return "Course Is Successfully Assigned";
                }
                else
                {
                    return "Assigning Failed";
                }
            }
        }

        public List<CourseAssign> GetCoursesByTeacherId(int teacherId)
        {
            return CourseAssignGateway.GetCoursesByTeacherId(teacherId);
        }

        public string Update()
        {
            int rowAffect = CourseAssignGateway.Update();

            if (rowAffect > 0)
            {
                return "Successfully Unassigned";
            }
            else
            {
                return "Unassigning Failed";
            }
        }
    }
}