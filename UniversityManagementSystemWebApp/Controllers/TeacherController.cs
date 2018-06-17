using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemWebApp.Manager;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Controllers
{
    public class TeacherController : Controller
    {
        public TeacherManager TeacherManager { get; set; }
        public DepartmentManager DepartmentManager { get; set; }
        public DesignationManager DesignationManager { get; set; }

        public TeacherController()
        {
            TeacherManager = new TeacherManager();
            DepartmentManager = new DepartmentManager();
            DesignationManager = new DesignationManager();
        }

        [HttpGet]
        public ActionResult Save()
        {
            ViewBag.DepartmentList = GetAllDepartmentForDropdown();
            ViewBag.DesignationList = GetAllDesignationForDropdown();
            return View();
        }

        [HttpPost]
        public ActionResult Save(Teacher teacher)
        {
            ViewBag.DepartmentList = GetAllDepartmentForDropdown();
            ViewBag.DesignationList = GetAllDesignationForDropdown();
            if (ModelState.IsValid)
            {
                string message = TeacherManager.Save(teacher);
                ViewBag.Message = message;
                if (message == "Teacher Save Successful")
                {
                    ModelState.Clear();
                    return View();
                }
                else
                {
                    return View(teacher);
                }
            }
            else
            {
                ViewBag.Message = "Please Fill All Field With Correct Format";
                return View(teacher);
            }
        }

        public List<SelectListItem> GetAllDepartmentForDropdown()
        {
            List<Department> departments = DepartmentManager.GetAllDepartments();
            List<SelectListItem> departmentSelectListItems =
                departments.ConvertAll(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() });

            return departmentSelectListItems;
        }

        public List<SelectListItem> GetAllDesignationForDropdown()
        {
            List<Designation> designations = DesignationManager.GetAllDesignations();
            List<SelectListItem> designationSelectListItems =
                designations.ConvertAll(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() });

            return designationSelectListItems;
        }
    }
}