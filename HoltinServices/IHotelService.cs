using HoltinModels.Entities;
using HoltinModels.Requests.HotelRequest;
using HoltinModels.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoltinServices
{
    public interface IHotelService
    {
        public DefaultResponse<Hotel> GetHotelById (HotelByIdRequest request);
        public DefaultResponse<List<Hotel>> GetHotelByFilter(HotelByFilterRequest request);
    }
}
