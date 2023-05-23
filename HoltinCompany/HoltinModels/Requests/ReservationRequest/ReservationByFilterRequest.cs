using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoltinModels.Requests.ReservationRequest
{
    public class ReservationByFilterRequest
    {
        public int HotelId { get; set; }
        public int RoomId { get; set; }
        public int ClientId { get; set; }
        public int Guests { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
