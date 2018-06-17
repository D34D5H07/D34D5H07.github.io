using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using UniversityManagementSystemWebApp.Manager;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Controllers
{
    public class AllocateClassroomController : Controller
    {
        public DepartmentManager DepartmentManager { get; set; }
        public AllocateClassroomManager AllocateClassroomManager { get; set; }
        public CourseManager CourseManager { get; set; }

        public AllocateClassroomController()
        {
            DepartmentManager = new DepartmentManager();
            AllocateClassroomManager = new AllocateClassroomManager();
            CourseManager = new CourseManager();
        }

        [HttpGet]
        public ActionResult Save()
        {
            ViewBag.DepartmentList = GetAllDepartmentForDropdown();
            ViewBag.RoomList = GetAllRoomForDropdown();
            ViewBag.DayList = GetAllDayForDropdown();
            return View();
        }

        [HttpPost]
        public ActionResult Save(AllocateClassroom allocateClassroom)
        {
            ViewBag.DepartmentList = GetAllDepartmentForDropdown();
            ViewBag.RoomList = GetAllRoomForDropdown();
            ViewBag.DayList = GetAllDayForDropdown();

            DateTime fromTime = Convert.ToDateTime(allocateClassroom.FromTime);
            allocateClassroom.FromTime = fromTime.ToString("HH:mm:ss");
            DateTime toTime = Convert.ToDateTime(allocateClassroom.ToTime);
            allocateClassroom.ToTime = toTime.ToString("HH:mm:ss");
            TimeSpan ts = toTime - fromTime;
            int ts1 = (int) ts.TotalMinutes;
            if (fromTime >= toTime || ts1 < 60)
            {
                ViewBag.Message = "From Time Can Not Be Grater Than Or Equal To Time & Time Duration Must Be Grater Than 60";
                return View(allocateClassroom);
            }
            else
            {
                if (ModelState.IsValid)
                {
                    string message = AllocateClassroomManager.Save(allocateClassroom);
                    ViewBag.Message = message;
                    if (message == "Room Allocate Successful")
                    {
                        ModelState.Clear();
                        return View();
                    }
                    else
                    {
                        return View(allocateClassroom);
                    }
                }
                else
                {
                    ViewBag.Message = "Please Fill All Field With Correct Format";
                    return View(allocateClassroom);
                }
            }
            
            
        }

        public List<SelectListItem> GetAllDepartmentForDropdown()
        {
            List<Department> departments = DepartmentManager.GetAllDepartments();
            List<SelectListItem> departmentSelectListItems =
                departments.ConvertAll(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() });

            return departmentSelectListItems;
        }

        public List<SelectListItem> GetAllRoomForDropdown()
        {
            List<Room> rooms = AllocateClassroomManager.GetAllRooms();
            List<SelectListItem> roomSelectListItems =
                rooms.ConvertAll(x => new SelectListItem() { Text = x.RoomNo, Value = x.Id.ToString() });

            return roomSelectListItems;
        }

        public List<SelectListItem> GetAllDayForDropdown()
        {
            List<Day> days = AllocateClassroomManager.GetAllDays();
            List<SelectListItem> daySelectListItems =
                days.ConvertAll(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() });

            return daySelectListItems;
        }

        public JsonResult GetCourseList(int departmentId)
        {
            var courses = CourseManager.GetCoursesByDepartmentId(departmentId);
            return Json(courses);
        }
    }
}