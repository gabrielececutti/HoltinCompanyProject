using HoltinModels.Entities;
using HoltinModels.Requests.ReservationRequest;
using HoltinModels.Responses;
using HoltinServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoltinBusinessLogic
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationService _reservationService;

        public ReservationService (IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        public DefaultResponse<Reservation> GetReservationById(ReservationByIdRequest request)
        {
            throw new NotImplementedException();
        }

        public DefaultResponse<List<Reservation>> GetReservationByFilter(ReservationByFilterRequest request)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Reservation reservation)
        {
            throw new NotImplementedException();
        }

        public bool Delete(ReservationByIdRequest id)
        {
            throw new NotImplementedException();
        }
    }
}
