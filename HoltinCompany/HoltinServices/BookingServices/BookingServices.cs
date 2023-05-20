using CredentialMangementModels.Response;
using HoltinData.PersistenceService;
using HoltinModels.Entities;
using HoltinModels.Requests.ReservationRequest;
using HoltinModels.Requests.RoomRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoltinServices.ClientService
{
    public class BookingServices : IBookingService
    {
        private readonly IRoomPersistenceService _roomPersistenceService; // per settare la stanza ad occupata
        private readonly IReservationPersistenceService _reservationPersistenceService; // per salvare la nuova reservation

        public BookingServices(IRoomPersistenceService roomPersistenceService, IReservationPersistenceService reservationPersistenceService)
        {
            _roomPersistenceService = roomPersistenceService;
            _reservationPersistenceService = reservationPersistenceService;
        }

        public bool BookNewReservation(Reservation reservation)
        {
            try
            {
                var room = reservation.Room;
                if (room.Booked) return false;
                _reservationPersistenceService.Insert(reservation);
                room.Booked = true;
                _roomPersistenceService.Update(room); // o trigger?
            } catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
} 
