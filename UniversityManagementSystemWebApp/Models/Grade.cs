using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemWebApp.Gateway;

namespace UniversityManagementSystemWebApp.Models
{
    public class Grade : CommonGateway
    {
        public int Id { get; set; }

        public string LetterGrade { get; set; }
    }
}