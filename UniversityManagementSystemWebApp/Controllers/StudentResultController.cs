using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemWebApp.Manager;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Controllers
{
    public class StudentResultController : Controller
    {
        public CourseManager CourseManager { get; set; }
        public StudentManager StudentManager { get; set; }
        public StudentResultManager StudentResultManager { get; set; }
        public EnrollCourseManager EnrollCourseManager { get; set; }
        public DepartmentManager DepartmentManager { get; set; }

        public StudentResultController()
        {
            CourseManager = new CourseManager();
            StudentManager = new StudentManager();
            StudentResultManager = new StudentResultManager();
            EnrollCourseManager = new EnrollCourseManager();
            DepartmentManager = new DepartmentManager();
        }

        [HttpGet]
        public ActionResult Save()
        {
            ViewBag.StudentList = GetAllStudentsForDropdown();
            ViewBag.GradeList = GetAllGradesForDropdown();
            return View();
        }

        [HttpPost]
        public ActionResult Save(StudentResult studentResult)
        {
            ViewBag.StudentList = GetAllStudentsForDropdown();
            ViewBag.GradeList = GetAllGradesForDropdown();
            studentResult.CourseEnrollId = StudentResultManager.EnrollCourseManager.GetEnrollId(studentResult);
            if (ModelState.IsValid)
            {
                string message = StudentResultManager.Save(studentResult);
                ViewBag.Message = message;
                if (message == "Result Saved")
                {
                    ModelState.Clear();
                    return View();
                }
                else
                {
                    return View(studentResult);
                }
            }
            else
            {
                ViewBag.Message = "Please Fill All Field With Correct Format";
                return View(studentResult);
            }
        }


        public JsonResult GetStudentById(StudentResult studentResult)
        {
            Student student = StudentManager.GetStudentById(studentResult.StudentId);
            //ViewBag.Student = student;
            string departmentName = DepartmentManager.GetDepartment(student.DepartmentId).Name;
            var studentInfo = new
            {
                Name = student.Name,
                Email = student.Email,
                DepartmentName = departmentName
            };

            return Json(studentInfo);
        }

        public JsonResult GetCoursesById(StudentResult studentResult)
        {
            List<Course> Courses = StudentResultManager.GetCoursesByStudentId(studentResult.StudentId).ToList();

            return Json(Courses);
        }

        public List<SelectListItem> GetAllStudentsForDropdown()
        {
            List<Student> students = StudentManager.GetAllStudents();
            List<SelectListItem> studentSelectListItems =
                students.ConvertAll(x => new SelectListItem() {Text = x.RegistrationNo, Value = x.Id.ToString()});

            return studentSelectListItems;
        }

        public List<SelectListItem> GetAllGradesForDropdown()
        {
            List<Grade> grades = StudentResultManager.GetAllGrades();
            List<SelectListItem> gradeSelectListItems =
                grades.ConvertAll(x => new SelectListItem() {Text = x.LetterGrade, Value = x.Id.ToString()});

            return gradeSelectListItems;
        }
    }
}