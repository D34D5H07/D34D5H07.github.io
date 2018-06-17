using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemWebApp.Gateway;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Manager
{
    public class SemesterManager
    {
        public SemesterGateway SemesterGateway { get; set; }

        public SemesterManager()
        {
            SemesterGateway = new SemesterGateway();
        }

        public List<Semester> GetAllSemesters()
        {
            return SemesterGateway.GetAllSemesters();
        }
    }
}