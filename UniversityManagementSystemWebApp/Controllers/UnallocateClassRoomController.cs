using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemWebApp.Manager;

namespace UniversityManagementSystemWebApp.Controllers
{
    public class UnallocateClassRoomController : Controller
    {
        public AllocateClassroomManager AllocateClassroomManager { get; set; }

        public UnallocateClassRoomController()
        {
            AllocateClassroomManager = new AllocateClassroomManager();
        }

        [HttpGet]
        public ActionResult Unallocate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Unallocate(int id = 1)
        {
            ViewBag.Message = AllocateClassroomManager.Update();
            return View();
        }
    }
}