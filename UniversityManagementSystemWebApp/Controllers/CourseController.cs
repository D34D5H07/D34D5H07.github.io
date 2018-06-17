using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemWebApp.Manager;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Controllers
{
    public class CourseController : Controller
    {
        public CourseManager CourseManager { get; set; }
        public DepartmentManager DepartmentManager { get; set; }
        public SemesterManager SemesterManager { get; set; }

        public CourseController()
        {
            CourseManager = new CourseManager();
            DepartmentManager = new DepartmentManager();
            SemesterManager = new SemesterManager();
        }

        [HttpGet]
        public ActionResult Save()
        {
            ViewBag.DepartmentList = GetAllDepartmentForDropdown();
            ViewBag.SemesterList = GetAllSemesterForDropdown();
            return View();
        }

        [HttpPost]
        public ActionResult Save(Course course)
        {
            ViewBag.DepartmentList = GetAllDepartmentForDropdown();
            ViewBag.SemesterList = GetAllSemesterForDropdown();

            if (ModelState.IsValid)
            {
                string message = CourseManager.Save(course);
                ViewBag.Message = message;
                if (message == "Course Save Successful")
                {
                    ModelState.Clear();
                    return View();
                }
                else
                {
                    return View(course);
                }
            }
            else
            {
                ViewBag.Message = "Please Fill All Field With Correct Format";
                return View(course);
            }
        }

        public List<SelectListItem> GetAllDepartmentForDropdown()
        {
            List<Department> departments = DepartmentManager.GetAllDepartments();
            List<SelectListItem> departmentSelectListItems =
                departments.ConvertAll(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() });
            
            return departmentSelectListItems;
        }

        public List<SelectListItem> GetAllSemesterForDropdown()
        {
            List<Semester> semesters = SemesterManager.GetAllSemesters();
            List<SelectListItem> semesterSelectListItems =
                semesters.ConvertAll(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() });
            
            return semesterSelectListItems;
        }
    }
}