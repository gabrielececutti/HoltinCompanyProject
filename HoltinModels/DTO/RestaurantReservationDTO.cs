using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoltinModels.DTO
{
    public class RestaurantReservationDTO
    {
        public ClientDTO Client { get;}
        public int Seats { get; }
        public DateTime ReservationDateTime { get; }
    }
}
