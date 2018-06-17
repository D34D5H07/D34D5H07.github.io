using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemWebApp.Models
{
    public class EnrollCourse
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Student Reg. No.")]
        public int StudentId { get; set; }
        [Required]
        [Display(Name = "Select Course")]
        public int CourseId { get; set; }
        [Required]
        public DateTime Date { get; set; }
       
    }
}