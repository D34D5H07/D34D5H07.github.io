using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemWebApp.Manager;
using UniversityManagementSystemWebApp.Models;
using UniversityManagementSystemWebApp.Models.ViewModels;

namespace UniversityManagementSystemWebApp.Controllers
{
    public class AssignedCoursesViewController : Controller
    {
        public DepartmentManager DepartmentManager { get; set; }
        public AssignedCoursesViewManager AssignedCoursesViewManager { get; set; }

        public AssignedCoursesViewController()
        {
            DepartmentManager = new DepartmentManager();
            AssignedCoursesViewManager = new AssignedCoursesViewManager();
        }

        [HttpGet]
        public ActionResult Show()
        {
            ViewBag.DepartmentList = GetAllDepartmentForDropdown();       
            return View();
        }

        [HttpPost]
        public JsonResult Show(int departmentId)
        {
            ViewBag.DepartmentList = GetAllDepartmentForDropdown();
            //ViewBag.CoursesDetails = AssignedCoursesViewManager.GetAllAssignedCourses(departmentId);
            List<AssignedCoursesView> courseList = AssignedCoursesViewManager.GetAllAssignedCourses(departmentId);
            return Json(courseList);
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