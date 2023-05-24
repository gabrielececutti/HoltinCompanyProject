using HoltinModels.Entities;
using HoltinModels.Requests.ClientRequest;
using HoltinModels.Requests.HotelRequest;
using HoltinModels.Requests.ReservationRequest;
using HoltinModels.Requests.RoomRequest;
using HoltinModels.Responses;

namespace HoltinRepositories
{
    public interface IHotelRepository
    {
        public DefaultResponse<Hotel> GetHotelById (HotelByIdRequest id);
        public DefaultResponse<List<Hotel>> GetHotelsByFilter (HotelByFilterRequest filter);
        public DefaultResponse<List<HotelRoomNumber>> GetAllHotelsWithNumOfFreeRooms();
        public DefaultResponse<bool> Insert (Hotel hotel);
        public DefaultResponse<bool> Update (Hotel hotel);
        public DefaultResponse<bool> Delete (HotelByIdRequest id);

    }

    public interface IRoomRepository
    {
        public DefaultResponse<Room> GetRoomById(RoomByIdRequest id);
        public DefaultResponse<List<Room>> GetRoomsByFilter(RoomByFilterRequest filter);
        public DefaultResponse<List<Room>> GetAllRooms();
        public DefaultResponse<bool> Insert (Room room);
        public DefaultResponse<bool> Update (Room room);
        public DefaultResponse<bool> Delete (RoomByIdRequest id);
    }

    public interface IClientRepository
    {
        public DefaultResponse<Client> GetClientById(ClientByIdRequest id);
        public DefaultResponse<List<Client>> GetClientsByFilter(ClientByFilterRequest filter);
        public DefaultResponse<bool> Insert(Client client);
        public DefaultResponse<bool> Update(Client client);
        public DefaultResponse<bool> Delete(ClientByIdRequest id);
    }

    public interface IReservationRepository
    {
        public DefaultResponse<Reservation> GetReservationById(ReservationByIdRequest id);
        public DefaultResponse<List<Reservation>> GetReservationsByFilter(ReservationByFilterRequest filter);
        public DefaultResponse<bool> Insert(Reservation reservation);
        public DefaultResponse<bool> Delete(ReservationByIdRequest id);
    }
}
