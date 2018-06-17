using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystemWebApp.Models.ViewModels;

namespace UniversityManagementSystemWebApp.Gateway
{
    public class ResultViewGateway : CommonGateway
    {
        public List<ResultView> GetAllResultByStudentId(int studentId)
        {
            string query = "SELECT * FROM ResultView WHERE StudentId = '" + studentId + "'";

            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<ResultView> resultViews = new List<ResultView>();
            while (Reader.Read())
            {
                ResultView resultView = new ResultView();
                resultView.Id = Convert.ToInt32(Reader["StudentId"]);
                resultView.CourseCode = Reader["CourseCode"].ToString();
                resultView.CourseName = Reader["CourseName"].ToString();
                resultView.Grade = Reader["Grade"].ToString();

                resultViews.Add(resultView);
            }
            Connection.Close();
            return resultViews;
        }
    }
}