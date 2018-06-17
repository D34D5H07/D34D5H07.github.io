using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemWebApp.Models.ViewModels
{
    [Serializable]
    public class ResultView
    {
        [Required(ErrorMessage = "Registration No. Is Requierd")]
        [Display(Name = "Student Reg. No.")]
        public int Id { get; set; }
        public string RegNo { get; set; }
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public string DepartmentName { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public string Grade { get; set; }
    }
}