using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemWebApp.Gateway;
using UniversityManagementSystemWebApp.Manager;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Controllers
{
    public class CourseAssignController : Controller
    {
        public CourseAssignManager CourseAssignManager { get; set; }
        public DepartmentManager DepartmentManager { get; set; }
        public TeacherManager TeacherManager { get; set; }
        public CourseManager CourseManager { get; set; }
        

        public CourseAssignController()
        {
            CourseAssignManager = new CourseAssignManager();
            DepartmentManager = new DepartmentManager();
            TeacherManager = new TeacherManager();
            CourseManager = new CourseManager();
            //Courses = new List<Course>();
            //Teachers = new List<Teacher>();
        }

        [HttpGet]
        public ActionResult Save()
        {
            ViewBag.DepartmentList = GetAllDepartmentForDropdown();
            return View();
        }

        [HttpPost]
        public ActionResult Save(CourseAssign courseAssign)
        {
            ViewBag.DepartmentList = GetAllDepartmentForDropdown();
            if (ModelState.IsValid)
            {
                string message = CourseAssignManager.Save(courseAssign);
                ViewBag.Message = message;
                if (message == "Course Is Successfully Assigned")
                {
                    ModelState.Clear();
                    return View();
                }
                else
                {
                    return View(courseAssign);
                }
            }
            else
            {
                ViewBag.Message = "Please Fill All Field With Correct Format";
                return View(courseAssign);
            }
            
        }

        public JsonResult GetTeacherList(int departmentId)
        {
            List<Teacher> teachers = TeacherManager.GetTeachersByDepartmentId(departmentId);
            return Json(teachers);
        }

        public JsonResult GetCourseList(int departmentId)
        {
            List<Course> courses = CourseManager.GetCoursesByDepartmentId(departmentId);
            return Json(courses);
        }

        public JsonResult GetCourseInfo(int courseId)
        {
            Course course = CourseManager.GetCourseById(courseId);
            return Json(course);
        }

        public JsonResult GetTeacherInfo(int teacherId)
        {
            List<CourseAssign> coursesIdList = CourseAssignManager.GetCoursesByTeacherId(teacherId);
            decimal credit = 0;
            foreach (CourseAssign course in coursesIdList)
            {
                credit += CourseManager.GetCourseById(course.CourseId).Credit;
            }
            decimal takenCredit = TeacherManager.GetTeacherById(teacherId).Credit;
            decimal remainingCredit = takenCredit - credit;
            
            var teacher = new Teacher();
            teacher.Credit = takenCredit;
            teacher.RemainingCredit = remainingCredit;
            
            return Json(teacher);
        }

        public List<SelectListItem> GetAllDepartmentForDropdown()
        {
            List<Department> departments = DepartmentManager.GetAllDepartments();
            List<SelectListItem> departmentSelectListItems =
                departments.ConvertAll(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() });

            return departmentSelectListItems;
        }
    }
}