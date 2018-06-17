using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemWebApp.Gateway;
using UniversityManagementSystemWebApp.Models.ViewModels;

namespace UniversityManagementSystemWebApp.Manager
{
    public class RoomAllocationViewManager
    {
        public RoomAllocationViewGateway RoomAllocationViewGateway { get; set; }

        public RoomAllocationViewManager()
        {
            RoomAllocationViewGateway = new RoomAllocationViewGateway();
        }

        public List<RoomAllocationView> GetAllocationInfoByDeptId(int departmentId)
        {
            List<RoomAllocationView> roomAllocationViews = RoomAllocationViewGateway.GetAllocationInfoByDeptId(departmentId);
            foreach (RoomAllocationView roomAllocationView in roomAllocationViews)
            {
                if (roomAllocationView.FromTime != "")
                {
                    roomAllocationView.FromTime = Convert.ToDateTime(roomAllocationView.FromTime).ToShortTimeString();
                    roomAllocationView.ToTime = Convert.ToDateTime(roomAllocationView.ToTime).ToShortTimeString();
                }
            }
            return roomAllocationViews;
        }
    }
}