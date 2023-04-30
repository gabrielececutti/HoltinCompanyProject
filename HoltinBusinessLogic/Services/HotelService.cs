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

namespace HoltinBusinessLogic
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelService(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public DefaultResponse<Hotel> GetHotelById(HotelByIdRequest request)
        {
            return _hotelRepository.GetHotelById(request);
        }

        public DefaultResponse<List<Hotel>> GetHotelByFilter(HotelByFilterRequest request)
        {
            return _hotelRepository.GetHotelsByFilter(request);
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
