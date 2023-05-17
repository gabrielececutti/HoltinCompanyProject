using HoltinData.PersistenceService;
using HoltinModels.Entities;
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
                _reservationPersistenceService.Insert(reservation);
                var room = reservation.Room;
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
