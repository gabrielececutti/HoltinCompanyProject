
using HoltinModels.Entities;
using HoltinModels.Requests.HotelRequest;
using HoltinModels.Requests.RoomRequest;
using HoltinModels.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoltinRepositories
{
    public interface IHotelRepository
    {
        public DefaultResponse<Hotel> GetHotelById (HotelByIdRequest id);
        public DefaultResponse<List<Hotel>> GetHotelsByFilter (HotelByFilterRequest filter);
    }

    public interface IRoomRepository
    {
        public DefaultResponse<Room> GetRoomById(RoomByIdRequest id);
        public DefaultResponse<List<Room>> GetRoomsByFilter(RoomByFilterRequest filter);
    }

    public interface IRestaurantRepository
    {

    }

    public interface IClientRepository
    {

    }
}
