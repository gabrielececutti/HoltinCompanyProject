using HoltinModels.Entities;
using HoltinModels.Requests.ClientRequest;
using HoltinModels.Requests.HotelRequest;
using HoltinModels.Requests.RoomRequest;
using HoltinModels.Responses;

namespace HoltinRepositories
{
    public interface IHotelRepository
    {
        public DefaultResponse<Hotel> GetHotelById (HotelByIdRequest id);
        public DefaultResponse<List<Hotel>> GetHotelsByFilter (HotelByFilterRequest filter);
        public bool Insert (Hotel hotel);
        public bool Update (Hotel hotel);
        public bool Delete (HotelByIdRequest id);

    }

    public interface IRoomRepository
    {
        public DefaultResponse<Room> GetRoomById(RoomByIdRequest id);
        public DefaultResponse<List<Room>> GetRoomsByFilter(RoomByFilterRequest filter);
        public bool Insert (Room room);
        public bool Update (Room room);
        public bool Delete (RoomByIdRequest id);
    }

    public interface IClientRepository
    {
        public DefaultResponse<Client> GetClientById(ClientByIdRequest id);
        public DefaultResponse<List<Client>> GetClientsByFilter(ClientByFilterRequest filter);
        public bool Insert(Client client);
        public bool Update(Client client);
        public bool Delete(ClientByIdRequest id);
    }

    public interface IRestaurantRepository
    {

    }
}
