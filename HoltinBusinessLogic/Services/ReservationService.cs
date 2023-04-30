using HoltinModels.Entities;
using HoltinModels.Requests.ReservationRequest;
using HoltinModels.Responses;
using HoltinRepositories;
using HoltinServices;

namespace HoltinBusinessLogic
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationService (IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public DefaultResponse<Reservation> GetReservationById(ReservationByIdRequest request)
        {
            return _reservationRepository.GetReservationById(request);
        }

        public DefaultResponse<List<Reservation>> GetReservationByFilter(ReservationByFilterRequest request)
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
