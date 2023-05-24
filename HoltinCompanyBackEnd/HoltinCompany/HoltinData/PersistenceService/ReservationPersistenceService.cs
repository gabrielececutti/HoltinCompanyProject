using HoltinModels.Entities;
using HoltinModels.Requests.ReservationRequest;
using HoltinModels.Responses;
using HoltinRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoltinData.PersistenceService
{
    public class ReservationPersistenceService : IReservationPersistenceService
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationPersistenceService(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public DefaultResponse<Reservation> GetReservationById(ReservationByIdRequest request)
        {
            return _reservationRepository.GetReservationById(request);
        }

        public DefaultResponse<List<Reservation>> GetReservationsByFilter(ReservationByFilterRequest request)
        {
            return _reservationRepository.GetReservationsByFilter(request);
        }

        public DefaultResponse<bool> Insert(Reservation reservation)
        {
            return _reservationRepository.Insert(reservation);
        }

        public DefaultResponse<bool> Delete(ReservationByIdRequest id)
        {
            return _reservationRepository.Delete(id);
        }
    }
}
