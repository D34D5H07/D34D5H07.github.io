using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystemWebApp.Models.ViewModels;

namespace UniversityManagementSystemWebApp.Gateway
{
    public class RoomAllocationViewGateway : CommonGateway
    {
        public List<RoomAllocationView> GetAllocationInfoByDeptId(int departmentId)
        {
            string query = "SELECT * FROM RoomAllocationView WHERE DepartmentId = '" + departmentId + "'";

            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<RoomAllocationView> roomAllocationViews = new List<RoomAllocationView>();
            while (Reader.Read())
            {
                RoomAllocationView roomAllocationView = new RoomAllocationView();
                roomAllocationView.CourseId = Convert.ToInt32(Reader["CourseId"]);
                roomAllocationView.CourseCode = Reader["CourseCode"].ToString();
                roomAllocationView.CourseName = Reader["CourseName"].ToString();
                roomAllocationView.RoomNo = Reader["RoomNo"].ToString();
                roomAllocationView.Day = Reader["Day"].ToString();
                roomAllocationView.FromTime = Convert.ToString(Reader["FromTime"]);
                roomAllocationView.ToTime = Reader["ToTime"].ToString();

                roomAllocationViews.Add(roomAllocationView);
            }
            Connection.Close();
            return roomAllocationViews;
        }
    }
}