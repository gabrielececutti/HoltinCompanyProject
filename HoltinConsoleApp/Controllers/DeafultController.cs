using Bogus;
using HoltinModels.DTO;
using HoltinModels.Entities;
using HoltinModels.Requests.HotelRequest;
using HoltinModels.Requests.RoomRequest;
using HoltinModels.Responses;
using HoltinServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace HoltinConsoleApp.Controllers
{
    public class DeafultController
    {
        private readonly IHotelService _hotelService;

        public DeafultController (IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        public DefaultResponse<HotelDTO> Get(HotelByIdRequest id)
        {
            DefaultResponse<Hotel> hotelEntity = _hotelService.GetHotelById(id);
            Hotel hotel = hotelEntity.Data;
            HotelDTO hotelDTO = new HotelDTO
            {
                Name = hotel.Name,
                City = hotel.City
            };
            DefaultResponse<HotelDTO> defaultResponse = new DefaultResponse<HotelDTO>
            {
                Data = hotelDTO,
            };
            return defaultResponse;
            // gestire tipo defaultResponse
        }

        public DefaultResponse<List<HotelDTO>> Filter (HotelByFilterRequest request)
        {
            DefaultResponse<List<Hotel>> hotelsEntiteis = _hotelService.GetHotelByFilter(request);
            List<HotelDTO> hotelsDTO = new List<HotelDTO>();
            foreach (var hotelEntity in hotelsEntiteis.Data)
            {
                HotelDTO hotelDTO = new HotelDTO
                {
                    Name = hotelEntity.Name,
                    City = hotelEntity.City,
                };
                hotelsDTO.Add(hotelDTO);
            }
            DefaultResponse<List<HotelDTO>> defaultResponse = new DefaultResponse<List<HotelDTO>>
            {
                Data = hotelsDTO,
            };
            return defaultResponse;
            // gestire tipo defaultResponse
        }
    }

    public class RoomController
    {
        private readonly IRoomService _roomService;

        public RoomController (IRoomService roomService)
        {
            _roomService = roomService;
        }

        public DefaultResponse<RoomDTO> Get (RoomByIdRequest id)
        {
            DefaultResponse<Room> roomEntity = _roomService.GetRoomById(id);
            throw new NotImplementedException();

        }

        public DefaultResponse<List<RoomDTO>> Filter (RoomByFilterRequest request)
        {
            DefaultResponse<List<Room>> roomEntities = _roomService.GetRoomByFilter(request);
            throw new NotImplementedException();
        }
    }

    public class RestaurantController
    {
        private readonly IRestaurantService _restaurantService;
    }
}
