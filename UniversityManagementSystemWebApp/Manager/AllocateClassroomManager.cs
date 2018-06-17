using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemWebApp.Gateway;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Manager
{
    public class AllocateClassroomManager
    {
        public AllocateClassroomGateway AllocateClassroomGateway { get; set; }

        public AllocateClassroomManager()
        {
            AllocateClassroomGateway = new AllocateClassroomGateway();
        }

        public string Save(AllocateClassroom allocateClassroom)
        {
            if (AllocateClassroomGateway.IsRoomAllocated(allocateClassroom))
            {
                return "This Room Is Not Available In This Time.";
            }
            else
            {
                int rowAffect = AllocateClassroomGateway.Save(allocateClassroom);

                if (rowAffect > 0)
                {
                    return "Room Allocate Successful";
                }
                else
                {
                    return "Allocate Failed";
                }
            }
        }

        public List<Room> GetAllRooms()
        {
            return AllocateClassroomGateway.GetAllRooms();
        }

        public List<Day> GetAllDays()
        {
            return AllocateClassroomGateway.GetAllDays();
        }

        public string Update()
        {
            int rowAffect = AllocateClassroomGateway.Update();

            if (rowAffect > 0)
            {
                return "Successfully Unallocate";
            }
            else
            {
                return "Unallocating Failed";
            }
        }
    }
}