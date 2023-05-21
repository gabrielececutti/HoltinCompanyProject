using HoltinData.PersistenceService;
using HoltinModels.Entities;
using HoltinModels.Requests.ReservationRequest;
using HoltinModels.Requests.RoomRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoltinAdministratorsServices.AdministratorServicesOnRoom
{
    public class RoomUpdateService : IRoomUpdateService
    {
        private readonly IRoomPersistenceService _roomPersistenceService;
        private readonly IReservationPersistenceService _reservationPersistenceService;

        public RoomUpdateService(IRoomPersistenceService roomPersistenceService, IReservationPersistenceService reservationPersistenceService)
        {
            _roomPersistenceService = roomPersistenceService;
            _reservationPersistenceService = reservationPersistenceService;
        }

        public void UpdateRoomAvailability()
        {
            var now = DateTime.Now;
            var roomsBooked = _roomPersistenceService.GetAllRooms().Data;
            foreach (var room in roomsBooked)
            {
                var reservtionToCheck = _reservationPersistenceService.GetReservationsByFilter(new ReservationByFilterRequest { RoomId = room.Id }).Data;
                if (reservtionToCheck.Any ( r => now <= r.CheckOut && now >= r.CheckIn)) room.Booked = true;
                else room.Booked = false;
                _roomPersistenceService.Update(room);
            }
        }

        public void Delete(RoomByIdRequest id)
        {
            _roomPersistenceService.Delete(id);
        }

        public void Insert(Room room)
        {
            _roomPersistenceService.Insert(room);
        }

        public void Update(Room room)
        {
            _roomPersistenceService.Update(room);
        }
    }
}
