using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemWebApp.Gateway;
using UniversityManagementSystemWebApp.Models.ViewModels;

namespace UniversityManagementSystemWebApp.Manager
{
    public class ResultViewManager
    {
        public ResultViewGateway ResultViewGateway { get; set; }

        public ResultViewManager()
        {
            ResultViewGateway = new ResultViewGateway();
        }

        public List<ResultView> GetAllResultByStudentId(int studentId)
        {
            return ResultViewGateway.GetAllResultByStudentId(studentId);
        }
    }

}