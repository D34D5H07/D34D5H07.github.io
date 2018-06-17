using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using UniversityManagementSystemWebApp.Manager;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Controllers
{
    public class StudentController : Controller
    {
        public StudentManager StudentManager { get; set; }
        public DepartmentManager DepartmentManager { get; set; }
        public List<Department> Departments { get; set; }
        
        public StudentController()
        {
            StudentManager = new StudentManager();
            DepartmentManager = new DepartmentManager();
            Departments = new List<Department>();
            
        }

        [HttpGet]
        public ActionResult Save()
        {
            ViewBag.DepartmentList = GetAllDepartmentForDropdown();
            return View();
        }

        [HttpPost]
        public ActionResult Save(Student student)
        {
            ViewBag.DepartmentList = GetAllDepartmentForDropdown();
            student.RegistrationNo = CreateRegNo(student);
            if (ModelState.IsValid)
            {
                string message = StudentManager.Save(student);
                ViewBag.Message = message;
                if (message == "Student Registration Is Successfull")
                {
                    ModelState.Clear();
                    ViewBag.StudentInfo = student;
                    ViewBag.DepartmentName = Departments.Find(x => x.Id == student.DepartmentId).Name;
                    return View();
                }
                else
                {
                    return View(student);
                }
            }
            else
            {
                ViewBag.Message = "Please Fill All Field With Correct Format";
                return View(student);
            }
            
        }

        public List<SelectListItem> GetAllDepartmentForDropdown()
        {
            Departments = DepartmentManager.GetAllDepartments();
            List<SelectListItem> departmentSelectListItems =
                Departments.ConvertAll(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() });

            return departmentSelectListItems;
        }

        public string CreateRegNo(Student student)
        {
            string deptCode = Departments.Find(x => x.Id == student.DepartmentId).Code;
            string year = student.Date.Year.ToString();
            int slNo = StudentManager.SerialNo(deptCode, year) + 1;
            if (slNo <= 9)
            {
                return deptCode + "-" + year + "-00" + slNo;
            }
            else if (slNo > 9 && slNo <= 99)
            {
                return deptCode + "-" + year + "-0" + slNo;               
            }
            else 
            {
                return deptCode + "-" + year + "-" + slNo;                
            }
           
        }
    }
}