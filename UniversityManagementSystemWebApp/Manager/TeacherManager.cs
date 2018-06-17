using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemWebApp.Gateway;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Manager
{
    public class TeacherManager
    {
        public TeacherGateway TeacherGateway { get; set; }

        public TeacherManager()
        {
            TeacherGateway = new TeacherGateway();
        }

        public string Save(Teacher teacher)
        {
            if (TeacherGateway.IsTeacherExist(teacher.Name, teacher.Email))
            {
                return "Teacher Is Already Exists.";
            }
            else
            {
                int rowAffect = TeacherGateway.Save(teacher);

                if (rowAffect > 0)
                {
                    return "Teacher Save Successful";
                }
                else
                {
                    return "Save Failed";
                }
            }

        }

        public List<Teacher> GetTeachersByDepartmentId(int departmentId)
        {
            return TeacherGateway.GetTeachersByDepartmentId(departmentId);
        }

        public Teacher GetTeacherById(int id)
        {
            return TeacherGateway.GetTeacherById(id);
        }
    }
}