using HoltinModels.DTO;
using HoltinModels.Entities;
using HoltinModels.Requests.HotelRequest;
using HoltinModels.Requests.RoomRequest;
using HoltinModels.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoltinServices.HotelService
{
    public interface IHotelService
    {
        public DefaultResponse<Hotel> GetHotelById(HotelByIdRequest request);
        public DefaultResponse<List<Hotel>> GetHotelsWithFilter (HotelByFilterRequest request);
        public DefaultResponse<List<HotelRoomNumber>> GetHotelsWithRoomsDisponibility();
    }
}
