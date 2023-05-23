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
            var room = reservation.Room;
            // fare controllo disponibilità per quelle date altirmenti lanciare eccezzione
            // selezionare tutte le reservation che hanno quella stanza prenotata e verifcare se la data per cui si vuole prenotre non è disponibile
            _reservationPersistenceService.Insert(reservation);
        }
    }
} 
