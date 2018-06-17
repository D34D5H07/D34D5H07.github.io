using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemWebApp.Gateway;
using UniversityManagementSystemWebApp.Models.ViewModels;

namespace UniversityManagementSystemWebApp.Manager
{
    public class AssignedCoursesViewManager
    {
        public AssignedCoursesViewGateway AssignedCoursesViewGateway { get; set; }

        public AssignedCoursesViewManager()
        {
            AssignedCoursesViewGateway = new AssignedCoursesViewGateway();
        }

        public List<AssignedCoursesView> GetAllAssignedCourses(int departmentId)
        {
            List<AssignedCoursesView> assignedCourses = AssignedCoursesViewGateway.GetAllAssignedCourses(departmentId);
            foreach (AssignedCoursesView assignedCoursesView in assignedCourses)
            {
                if (assignedCoursesView.AssignedTeacherName == "")
                {
                    assignedCoursesView.AssignedTeacherName = "Not Assigned Yet";
                }
                
            }
            return assignedCourses;
        }
    }
}