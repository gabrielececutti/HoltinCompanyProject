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

        public void AutoRoomsUpdating()
        {
            var now = DateTime.Now;
            var roomsBooked = _roomPersistenceService.GetRoomsByFilter(new RoomByFilterRequest { Booked = true }).Data;
            foreach (var room in roomsBooked)
            {
                var reservationsToCheck = _reservationPersistenceService.GetReservationsByFilter(new ReservationByFilterRequest { RoomId = room.Id });

                foreach (var reservation in reservationsToCheck.Data.Where(r => r.CheckOut < now)) // se ordinate basterebbe controllare solo l'ultima
                {
                    room.Booked = false;
                    _roomPersistenceService.Update(room);
                    if (room.Number == 50) Console.WriteLine("HELOOOOOOOOOOOOOOOO");
                }
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
