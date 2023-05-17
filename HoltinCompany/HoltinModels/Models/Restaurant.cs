using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoltinModels.Entities
{
    public class Restaurant
    {
        public Hotel Hotel { get; set; }
        public int HotelId { get; }
        public int TableSeats { get; }

    }
}
