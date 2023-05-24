using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoltinModels.DTO
{
    public class UserReservationRequestDTO
    {
        public ClientDTO Client { get; set; }
        public RoomDTO Room { get; set; }
        public HotelDTO Hotel { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int Guest { get; set; }
    }
}
