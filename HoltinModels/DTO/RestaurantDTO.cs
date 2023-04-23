using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoltinModels.DTO
{
    public class RestaurantDTO
    {
        public HotelDTO Hotel { get; }
        public List<TableDTO> Tables { get; }

    }

    public class TableDTO
    {
        int Number { get; }
        bool IsReserved { get; }
        DateTime DateTimeReservation { get; }

    }
}
