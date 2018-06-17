using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemWebApp.Manager;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Controllers
{
    public class EnrollCourseController : Controller
    {
        public CourseManager CourseManager { get; set; }
        public StudentManager StudentManager { get; set; }
        public EnrollCourseManager EnrollCourseManager { get; set; }
        public DepartmentManager DepartmentManager { get; set; }

        public EnrollCourseController()
        {
            CourseManager = new CourseManager();
            StudentManager = new StudentManager();
            EnrollCourseManager = new EnrollCourseManager();
            DepartmentManager = new DepartmentManager();
        }

        [HttpGet]
        public ActionResult Save()
        {
            ViewBag.StudentList = GetAllStudentsForDropdown();
            return View();
        }

        [HttpPost]
        public ActionResult Save(EnrollCourse enrollCourse)
        {
            ViewBag.StudentList = GetAllStudentsForDropdown();
            var errors = ModelState.Where(x => x.Value.Errors.Count > 0)
                .Select(x => new {x.Key, x.Value.Errors})
                .ToArray();
            if (ModelState.IsValid)
            {
            string message = EnrollCourseManager.Save(enrollCourse);
            ViewBag.Message = message;
            if (message == "Successfully Enroll")
            {
                ModelState.Clear();
                return View();
            }
            else
            {
                return View(enrollCourse);
            }
            }
            else
            {
                ViewBag.Message = "Please Fill All Field With Correct Format";
                return View(enrollCourse);
            }
        }

        public JsonResult GetStudentById(EnrollCourse enrollCourse)
        {
            Student student = StudentManager.GetStudentById(enrollCourse.StudentId);
            string departmentName = DepartmentManager.GetDepartment(student.DepartmentId).Name;
            var studentInfo = new
            {
                Name = student.Name,
                Email = student.Email,
                DepartmentId = student.DepartmentId,
                DepartmentName = departmentName
            };

            return Json(studentInfo);
        }

        public JsonResult GetCoursesById(int departmentId)
        {
            List<Course> Courses = CourseManager.GetCoursesByDepartmentId(departmentId);
            return Json(Courses);
        }

        public List<SelectListItem> GetAllStudentsForDropdown()
        {
            List<Student> students = StudentManager.GetAllStudents();
            List<SelectListItem> studentSelectListItems =
                students.ConvertAll(x => new SelectListItem() {Text = x.RegistrationNo, Value = x.Id.ToString()});

            return studentSelectListItems;
        }
    }
}