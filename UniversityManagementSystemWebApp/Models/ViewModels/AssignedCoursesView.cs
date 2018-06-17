using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace UniversityManagementSystemWebApp.Models.ViewModels
{
    public class AssignedCoursesView
    {
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public string SemesterName { get; set; }
        public string AssignedTeacherName { get; set; }
    }
}