using HoltinModels.Entities;
using HoltinModels.Requests.ClientRequest;
using HoltinModels.Requests.HotelRequest;
using HoltinModels.Requests.ReservationRequest;
using HoltinModels.Requests.RoomRequest;
using HoltinModels.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoltinData.PersistenceService
{
    public interface IClientPersistenceService
    {
        public DefaultResponse<Client> GetClientById(ClientByIdRequest id);
        public DefaultResponse<List<Client>> GetClientsByFilter(ClientByFilterRequest request);
        public DefaultResponse<bool> Insert(Client client);
        public DefaultResponse<bool> Update(Client client);
        public DefaultResponse<bool> Delete(ClientByIdRequest id);
    }

    public interface IHotelPersistenceService
    {
        public DefaultResponse<Hotel> GetHotelById(HotelByIdRequest request);
        public DefaultResponse<List<Hotel>> GetHotelsByFilter(HotelByFilterRequest request);
        public DefaultResponse<List<HotelRoomNumber>> GetAllHotelsWithNumOfFreeRooms();
        public DefaultResponse<bool> Insert(Hotel hotel);
        public DefaultResponse<bool> Update(Hotel hotel);
        public DefaultResponse<bool> Delete(HotelByIdRequest id);
    }

    public interface IReservationPersistenceService
    {
        public DefaultResponse<Reservation> GetReservationById(ReservationByIdRequest request);
        public DefaultResponse<List<Reservation>> GetReservationsByFilter(ReservationByFilterRequest request);
        public DefaultResponse<bool> Insert(Reservation reservation);
        public DefaultResponse<bool> Delete(ReservationByIdRequest id);
    }

    public interface IRoomPersistenceService
    {
        public DefaultResponse<Room> GetRoomById(RoomByIdRequest id);
        public DefaultResponse<List<Room>> GetRoomsByFilter(RoomByFilterRequest request);
        public DefaultResponse<List<Room>> GetAllRooms();
        public DefaultResponse<bool> Insert(Room room);
        public DefaultResponse<bool> Update(Room room);
        public DefaultResponse<bool> Delete(RoomByIdRequest id);
    }
}
