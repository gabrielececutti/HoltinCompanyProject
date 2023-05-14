using HoltinModels.DiscountCalculatorDecoarator;
using HoltinModels.Entities;
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
        private const decimal PercentageRoomPriceGuest = 0.010M;
        private readonly DiscountCalculator _discountCalculator;

        public ReservationPriceCalculator(DiscountCalculator discountCalculator)
        {
            _discountCalculator = discountCalculator;
        }

        public decimal Calculate (UserReservationRequest userReservationRequest)
        {
            var guest = userReservationRequest.Guest;
            var room = userReservationRequest.Room;
            var totalRoomPrice = room.NightPrice + (guest * (room.NightPrice * PercentageRoomPriceGuest));

            var discountPercentage = _discountCalculator.GetDiscount(userReservationRequest);

            return totalRoomPrice - (totalRoomPrice * discountPercentage);
        }
    }
}
