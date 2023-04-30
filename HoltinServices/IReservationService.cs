using HoltinModels.Entities;
using HoltinModels.Requests.HotelRequest;
using HoltinModels.Requests.ReservationRequest;
using HoltinModels.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoltinServices
{
    public interface IReservationService
    {
        public DefaultResponse<Reservation> GetReservationById(ReservationByIdRequest request);
        public DefaultResponse<List<Reservation>> GetReservationByFilter(ReservationByFilterRequest request);
        public DefaultResponse<bool> Insert(Reservation reservation);
        public DefaultResponse<bool> Delete(ReservationByIdRequest id);
    }
}
