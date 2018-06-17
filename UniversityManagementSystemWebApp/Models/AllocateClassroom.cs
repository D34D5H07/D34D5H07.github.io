using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemWebApp.Models
{
    public class AllocateClassroom
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        [Required]
        [Display(Name = "Course")]
        public int CourseId { get; set; }
        [Required]
        [Display(Name = "Room No.")]
        public int RoomId { get; set; }
        [Required]
        [Display(Name = "Day")]
        public int DayId { get; set; }
        [Required]
        //[StringLength(2)]
        [DataType(DataType.Time)]
        [Display(Name = "From")]
        public string FromTime { get; set; }
        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "To")]
        public string ToTime { get; set; }
    }
}