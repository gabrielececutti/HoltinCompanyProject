using HoltinModels.Requests;
using HoltinWebApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace HoltinServices.Helpers
{
    public class ReservationPriceCalculator
    {
        private readonly DiscountPolicies _discountPolitices;
        private const decimal PercentageRoomPriceGuest = 0.10M; 

        public ReservationPriceCalculator(DiscountPolicies discountPolitices)
        {
            _discountPolitices = discountPolitices;
        }

        public decimal Calculate (UserReservationRequest userReservationRequest)
        {
            var totalPrice = 0;

            var guest = userReservationRequest.Guest;
            var client = userReservationRequest.Client;
            var room = userReservationRequest.Room;
            var duration = userReservationRequest.CheckOut - userReservationRequest.CheckIn;

            var roomPrice = room.NightPrice + (guest * (room.NightPrice * PercentageRoomPriceGuest));
            var durationScount = 0;
            if (duration.Days >= _discountPolitices.ReservationDuration.Item2)
            {
                durationScount += _discountPolitices.ReservationDuration.Item2 * room.NightPrice;
            }
            return totalPrice;
        }
    }
}
