using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Gateway
{
    public class AllocateClassroomGateway : CommonGateway
    {
        public int Save(AllocateClassroom allocateClassroom)
        {
            string query = "INSERT INTO AllocateClassRoom VALUES('" + allocateClassroom.DepartmentId + "','" +
                           allocateClassroom.CourseId + "','" + allocateClassroom.RoomId + "','" +
                           allocateClassroom.DayId + "','" + allocateClassroom.FromTime + "','" +
                           allocateClassroom.ToTime + "','" + 1 + "')";

            Command = new SqlCommand(query, Connection);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }

        public bool IsRoomAllocated(AllocateClassroom allocateClassroom)
        {
            string query = "SELECT * FROM AllocateClassRoom WHERE Active = '" + 1 + "' AND RoomId = '" +
                           allocateClassroom.RoomId + "' AND DayId = '" + allocateClassroom.DayId +
                           "' AND ToTime > '" + allocateClassroom.FromTime + "' AND FromTime < '" + allocateClassroom.ToTime + "' ";

            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool isExists = Reader.HasRows;
            Connection.Close();
            return isExists;
        }

        public List<Room> GetAllRooms()
        {
            string query = "SELECT * FROM Room";

            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Room> rooms = new List<Room>();
            while (Reader.Read())
            {
                Room room = new Room();
                room.Id = Convert.ToInt32(Reader["Id"]);
                room.RoomNo = Reader["RoomNo"].ToString();

                rooms.Add(room);
            }
            Connection.Close();
            return rooms;
        }

        public List<Day> GetAllDays()
        {
            string query = "SELECT * FROM Day";

            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Day> days = new List<Day>();
            while (Reader.Read())
            {
                Day day = new Day();
                day.Id = Convert.ToInt32(Reader["Id"]);
                day.Name = Reader["Name"].ToString();

                days.Add(day);
            }
            Connection.Close();
            return days;
        }

        public int Update()
        {
            string query = "UPDATE AllocateClassRoom SET Active = '" + 0 + "'";

            Command = new SqlCommand(query, Connection);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }
    }
}