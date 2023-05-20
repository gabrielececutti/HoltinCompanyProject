using HoltinData.PersistenceService;
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
    public class HotelService : IHotelService
    {
        private readonly IHotelPersistenceService _hotelPersistenceService;

        public HotelService(IHotelPersistenceService hotelPersistenceService)
        {
            _hotelPersistenceService = hotelPersistenceService;
        }

        public DefaultResponse<List<Hotel>> GetHotelsWithFilter(HotelByFilterRequest request)
        {
            return _hotelPersistenceService.GetHotelsByFilter(request);
        }

        public DefaultResponse<Hotel> GetHotelById(HotelByIdRequest request)
        {
            return _hotelPersistenceService.GetHotelById(request);
        }

        public DefaultResponse<List<HotelRoomNumber>> GetHotelsWithRoomsDisponibility()
        {
            return _hotelPersistenceService.GetAllHotelsWithNumOfFreeRooms();
        }
    }
}
