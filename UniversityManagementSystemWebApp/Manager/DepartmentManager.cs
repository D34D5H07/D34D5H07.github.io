using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemWebApp.Gateway;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Manager
{
    public class DepartmentManager
    {
        public DepartmentGateway DepartmentGateway { get; set; }

        public DepartmentManager()
        {
            DepartmentGateway = new DepartmentGateway();
        }

        public string Save(Department department)
        {
            if (DepartmentGateway.IsDepartmentExist(department))
            {
                return "Department Is Already Exists.";
            }
            else
            {
                int rowAffect = DepartmentGateway.Save(department);

                if (rowAffect > 0)
                {
                    return "Department Save Successful";
                }
                else
                {
                    return "Save Failed";
                }
            }
            
        }

        public List<Department> GetAllDepartments()
        {
            return DepartmentGateway.GetAllDepartments();
        }

        public Department GetDepartment(int departmentId)
        {
            return DepartmentGateway.GetDepartment(departmentId);
        }

    }
}