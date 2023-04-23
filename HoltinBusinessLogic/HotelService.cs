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
    // pesco i risultati delle query dalle repository
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
            throw new NotImplementedException();
        }
    }
}
