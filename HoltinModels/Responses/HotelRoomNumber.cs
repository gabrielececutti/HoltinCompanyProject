using HoltinModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoltinModels.Responses
{
    public class HotelRoomNumber
    {
        public Hotel Hotel { get; set; }
        public int NumberOfRooms { get; set; }
        public int NumberOfFreeRooms { get; set; }
    }
}
