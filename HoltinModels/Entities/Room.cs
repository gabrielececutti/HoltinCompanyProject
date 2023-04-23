using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoltinModels.Entities
{
    public class Room
    {
        public int ID { get; init; }
        public int HotelId { get; init; }
        public int Number { get; init; }
        public bool Booked { get; init; }
        public int SingleBeds { get; init; }
        public int DoubleBeds { get; init; }
        public bool WiFi { get; init; }
        public bool RoomService { get; init; }
        public bool AirConditioning { get; init; }
        public bool Tv { get; init; }
        public decimal NightPrice { get; init; }
    }
}
