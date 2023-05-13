using HoltinModels.Entities;
using HoltinModels.Requests.HotelRequest;
using HoltinModels.Responses;
using HoltinRepositories;
using HoltinServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoltinData.PersistenceService
{
    public class HotelPersistenceService : IHotelPersistenceService
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelPersistenceService(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public DefaultResponse<Hotel> GetHotelById(HotelByIdRequest request)
        {
            return _hotelRepository.GetHotelById(request);
        }

        public DefaultResponse<List<Hotel>> GetHotelsByFilter(HotelByFilterRequest request)
        {
            return _hotelRepository.GetHotelsByFilter(request);
        }

        public DefaultResponse<List<HotelRoomNumber>> GetAllHotelsWithNumOfFreeRooms()
        {
            return _hotelRepository.GetAllHotelsWithNumOfFreeRooms();
        }

        public DefaultResponse<bool> Insert(Hotel hotel)
        {
            return _hotelRepository.Insert(hotel);
        }

        public DefaultResponse<bool> Update(Hotel hotel)
        {
            return _hotelRepository.Update(hotel);
        }

        public DefaultResponse<bool> Delete(HotelByIdRequest id)
        {
            return _hotelRepository.Delete(id);
        }
    }
}
