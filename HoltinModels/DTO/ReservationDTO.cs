
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoltinModels.DTO
{
    // quella trasmessa e ricevuta
    public class ReservationDTO
    {
        public string IdentificationCode { get; }
        public ClientDTO Client { get; }
        public HotelDTO Hotel { get; }      
        public RoomDTO Room { get; }
        public int Guests { get; }
        public DateTime CheckIn { get; }
        public DateTime CheckOut { get; }
        public decimal TotalCost { get; }

    }
}
