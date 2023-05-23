
using HoltinData.PersistenceService;
using HoltinModels.Entities;
using HoltinModels.Requests.ReservationRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoltinServices.ClientService
{
    public class ClientService : IClientService
    {
        private readonly IReservationPersistenceService _reservationPersistenceService;

        public ClientService(IReservationPersistenceService reservationPersistenceService)
        {
            _reservationPersistenceService = reservationPersistenceService;
        }

        public List<Reservation> GetReservationBooked(Client client)
        {
            var request = new ReservationByFilterRequest { ClientId = client.Id };
            return _reservationPersistenceService.GetReservationsByFilter(request).Data;
         }
    }
}
