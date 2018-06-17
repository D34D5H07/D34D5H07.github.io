using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemWebApp.Gateway;
using UniversityManagementSystemWebApp.Manager;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Controllers
{
    public class DepartmentController : Controller
    {
        public DepartmentManager DepartmentManager { get; set; }
        
        public DepartmentController()
        {
            DepartmentManager = new DepartmentManager();
            
        }

        [HttpGet]
        public ActionResult Save()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save(Department course)
        {
            if (ModelState.IsValid)
            {
                string message = DepartmentManager.Save(course);
                ViewBag.Message = message;
                if (message == "Department Save Successful")
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

        [HttpGet]
        public ActionResult ShowAllDepartment()
        {
            List<Department> departments = DepartmentManager.GetAllDepartments();
            
            return View(departments);
        }
    }
}