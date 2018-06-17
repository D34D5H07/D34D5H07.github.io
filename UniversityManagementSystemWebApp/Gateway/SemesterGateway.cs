using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Gateway
{
    public class SemesterGateway : CommonGateway
    {
        public List<Semester> GetAllSemesters()
        {
            string query = "SELECT * FROM Semester";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Semester> semisters = new List<Semester>();
            while (Reader.Read())
            {
                Semester semister = new Semester();
                semister.Id = Convert.ToInt32(Reader["Id"]);
                semister.Name = Reader["Name"].ToString();
                
                semisters.Add(semister);
            }

            Connection.Close();

            return semisters;
        }

        //public Semester GetSemisterById(int id)
        //{
        //    string query = "SELECT * FROM Semister WHERE Id=" + id;
        //    Command = new SqlCommand(query, Connection);
        //    Connection.Open();
        //    Reader = Command.ExecuteReader();
        //    Reader.Read();

        //    Semester semister = new Semester();
        //    if (Reader.HasRows)
        //    {
        //        semister.Id = Convert.ToInt32(Reader["Id"]);
        //        semister.Name = Reader["Name"].ToString();
        //    }

        //    Connection.Close();

        //    return semister;
        //}
    }
}