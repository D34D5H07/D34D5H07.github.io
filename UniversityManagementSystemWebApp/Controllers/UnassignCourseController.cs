using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemWebApp.Manager;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Controllers
{
    public class UnassignCourseController : Controller
    {
        public CourseAssignManager CourseAssignManager { get; set; }

        public UnassignCourseController()
        {
            CourseAssignManager = new CourseAssignManager();
        }

        // GET: UnassignCourse
        [HttpGet]
        public ActionResult Unassign()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Unassign(int id=1)
        {
            ViewBag.Message = CourseAssignManager.Update();
            return View();
        }
    }
}