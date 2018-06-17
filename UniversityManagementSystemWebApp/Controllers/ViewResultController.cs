using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemWebApp.Manager;
using UniversityManagementSystemWebApp.Models;
using UniversityManagementSystemWebApp.Models.ViewModels;
using Rotativa;

namespace UniversityManagementSystemWebApp.Controllers
{
    public class ViewResultController : Controller
    {
        public StudentManager StudentManager { get; set; }
        public ResultViewManager ResultViewManager { get; set; }
        public DepartmentManager DepartmentManager { get; set; }

        public ViewResultController()
        {
            StudentManager = new StudentManager();
            ResultViewManager = new ResultViewManager();
            DepartmentManager = new DepartmentManager();
        }

        [HttpGet]
        public ActionResult Show()
        {
            ViewBag.StudentList = GetAllStudentForDropdown();
            return View();
        }

        [HttpPost]
        public ActionResult Show(List<ResultView> resultViews)
        {
            ViewBag.StudentList = GetAllStudentForDropdown();
            return View();
        }

        public JsonResult GetStudentInfo(int studentId)
        {
            Student student = StudentManager.GetStudentById(studentId);
            var studentInfo = new
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email,
                DepartmentName = DepartmentManager.GetDepartment(student.DepartmentId).Name
            }; 
            return Json(studentInfo);
        }

        public JsonResult GetAllResult(int studentId)
        {
            List<ResultView> resultViews = ResultViewManager.GetAllResultByStudentId(studentId);
            return Json(resultViews);
        }

        public List<SelectListItem> GetAllStudentForDropdown()
        {
            List<Student> students = StudentManager.GetAllStudents();
            List<SelectListItem> studentSelectListItems =
                students.ConvertAll(x => new SelectListItem() {Text = x.RegistrationNo, Value = x.Id.ToString()});

            return studentSelectListItems;
        }


        public ActionResult DataForPdf(ResultView resultView)
        {
            Student student = StudentManager.GetStudentById(Convert.ToInt32(resultView.Id));

            resultView.Id = student.Id;
            resultView.RegNo = student.RegistrationNo;
            resultView.StudentName = student.Name;
            resultView.StudentEmail = student.Email;
            resultView.DepartmentName = DepartmentManager.GetDepartment(student.DepartmentId).Name;

            List<ResultView> resultViews = ResultViewManager.GetAllResultByStudentId(Convert.ToInt32(resultView.Id));
            foreach (ResultView result in resultViews)
            {
                if (result.Grade == "")
                    result.Grade = "Not Graded Yet";
            }
            ViewBag.StudentInfo = resultView;
            ViewBag.ResultList = resultViews;

            return View();
        }


        public ActionResult ExportPdf(int id)
        {
            //string header = Server.MapPath("~/bin/PrintHeader.html"); //Path of PrintHeader.html File
            //string footer = Server.MapPath("~/bin/PrintFooter.html"); //Path of PrintFooter.html File

            //string customSwitches = string.Format("--header-html  \"{0}\" " +
            //                                      "--header-spacing \"0\" " +
            //                                      "--footer-html \"{1}\" " +
            //                                      "--footer-spacing \"10\" " +
            //                                      "--footer-font-size \"10\" " +
            //                                      "--header-font-size \"10\" ", header, footer);

            ResultView resultView = new ResultView();
            resultView.Id = id;

            return new ActionAsPdf("DataForPdf", resultView)
            {
                FileName = Server.MapPath("~/content/StudentResult.pdf"),
                PageSize = Rotativa.Options.Size.A4
            };
        }
    }
}