using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemWebApp.Gateway;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Manager
{
    public class DesignationManager
    {
        public DesignationGateway DesignationGateway { get; set; }

        public DesignationManager()
        {
            DesignationGateway = new DesignationGateway();
        }

        public List<Designation> GetAllDesignations()
        {
            return DesignationGateway.GetAllDesignations();
        } 
    }
}