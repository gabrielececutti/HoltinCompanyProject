using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoltinModels.Requests.RoomRequest
{
    public class RoomByFilterRequest
    {
        public int HotelId { get; set; }
        public int Guests { get; set; }
        public bool Booked { get; set; }
        public int SingleBeds { get; set; }
        public int DoubleBeds { get; set; }
        public bool WiFi { get; set; }
        public bool RoomService { get; set; }
        public bool AirConditioning { get; set; }
        public bool Tv { get; set; }
        public decimal NigthPriceMax { get; set; }
        public decimal NigthPriceMin { get;set; }
    }
}
