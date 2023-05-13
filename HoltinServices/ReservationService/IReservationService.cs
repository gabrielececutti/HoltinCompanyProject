using HoltinModels.Entities;
using HoltinModels.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoltinServices.ReservationService
{
    public interface IReservationService
    {
        public Reservation CreateNewReservation(UserReservationRequest userReservationRequest);
    }
}
