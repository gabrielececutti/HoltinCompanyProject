﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoltinModels.Entities
{
    public class Room
    {
        public int Id { get; init; }
        public int HotelId { get; init; }
        public int Number { get; set; }
        public bool Booked { get; set; }
        public int SingleBeds { get; set; }
        public int DoubleBeds { get; set; }
        public bool WiFi { get; set; }
        public bool RoomService { get; set; }
        public bool AirConditioning { get; set; }
        public bool Tv { get; set; }
        public decimal NightPrice { get; set; }
    }
}
