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
        private readonly IRoomPersistenceService _roomPersistenceService;
        private readonly IReservationPersistenceService _reservationPersistenceService;

        public BookingServices(IRoomPersistenceService roomPersistenceService, IReservationPersistenceService reservationPersistenceService)
        {
            _roomPersistenceService = roomPersistenceService;
            _reservationPersistenceService = reservationPersistenceService;
        }

        public void BookNewReservation(Reservation reservation)
        {
            var reservations = _reservationPersistenceService.GetReservationsByFilter(new ReservationByFilterRequest { RoomId = reservation.RoomId }).Data;

            var checkIn = reservation.CheckIn;
            var checkOut = reservation.CheckOut;

            bool isAvailable = !reservations.Any(existingReservation =>
                (checkIn >= existingReservation.CheckIn && checkIn <= existingReservation.CheckOut) ||
                (checkOut >= existingReservation.CheckIn && checkOut <= existingReservation.CheckOut) ||
                (checkIn <= existingReservation.CheckIn && checkOut >= existingReservation.CheckOut)
            );

            if (!isAvailable) throw new Exception("Le date selezionate non sono disponibili per la prenotazione.");
            _reservationPersistenceService.Insert(reservation);
        }
    }
} 
