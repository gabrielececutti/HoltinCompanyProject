using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoltinModels.Requests.RoomRequest
{
    public class RoomByFilterRequest
    {
        int Guests { get; set; }
        int SingleBeds { get; set; }
        int DoubleBeds { get; set; }
        bool WiFi { get; set; }
        bool RoomService { get; set; }
        bool AirConditioning { get; set; }
        bool Tv { get; set; }
        decimal NigthPriceMax { get; set; }
        decimal NigthPriceMin { get;set; }
    }
}
