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
    public class RoomAllocationViewController : Controller
    {
        public DepartmentManager DepartmentManager { get; set; }
        public RoomAllocationViewManager RoomAllocationViewManager { get; set; }

        public RoomAllocationViewController()
        {
            DepartmentManager = new DepartmentManager();
            RoomAllocationViewManager = new RoomAllocationViewManager();
        }

        [HttpGet]
        public ActionResult Show()
        {
            ViewBag.DepartmentList = GetAllDepartmentForDropdown();       
            return View();
        }

        [HttpPost]
        public JsonResult Show(int id)
        {
            ViewBag.DepartmentList = GetAllDepartmentForDropdown();
            List<RoomAllocationView> roomAllocationViews = RoomAllocationViewManager.GetAllocationInfoByDeptId(id);

            return Json(roomAllocationViews);
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