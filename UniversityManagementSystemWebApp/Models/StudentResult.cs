using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemWebApp.Models
{
    public class StudentResult
    {
        public int Id { get; set; }
        public int CourseEnrollId { get; set; }
        [Required]
        [Display(Name = "Student Reg. No.")]
        public int StudentId { get; set; }
        [Required]
        [Display(Name = "Select Course")]
        public int CourseId { get; set; }
        [Required]
        [Display(Name = "Select Grade Letter")]
        public int GradeId { get; set; }

    }
}