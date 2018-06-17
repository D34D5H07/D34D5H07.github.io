using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Gateway
{
    public class DesignationGateway :CommonGateway
    {
        public List<Designation> GetAllDesignations()
        {
            string query = "SELECT * FROM Designation";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Designation> designations = new List<Designation>();
            while (Reader.Read())
            {
                Designation designation = new Designation();
                designation.Id = Convert.ToInt32(Reader["Id"]);
                designation.Name = Reader["Name"].ToString();

                designations.Add(designation);
            }

            Connection.Close();

            return designations;
        }
    }
}