using HoltinModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoltinModels.DiscuntPoliticies
{
    public class ReservationDurationDiscount : DiscountDecorator
    {
        private readonly Reservation _reservation;
        private readonly IDiscunt _discountPolicies;
        private const decimal DurationDiscuntPercentage = 0.06M; // >=5 // fare un oggetto

        public ReservationDurationDiscount(IDiscunt discountPolicies, Reservation reservation)
        {
            _reservation = reservation;
            _discountPolicies = discountPolicies;
        }

        public override decimal GetDiscount()
        {
            var durationDiscunt = _reservation.CheckOut - _reservation.CheckIn >= 5 ? DurationDiscuntPercentage : 0;
            var durationDiscunt = _reservation.CheckOut - _reservation.CheckIn;
        }
    }
}
