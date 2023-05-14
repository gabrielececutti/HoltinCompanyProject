using HoltinModels.DiscountCalculatorDecoarator;
using HoltinModels.Entities;
using HoltinModels.Requests;
using HoltinWebApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoltinModels.DiscuntPoliticies
{
    public class ReservationDurationDiscount : DiscountDecorator
    {
        private readonly DiscountCalculator _discountCalculator;

        public ReservationDurationDiscount(DiscountCalculator discountCalculator, DiscountPolicies discuntPolicies) : base(discuntPolicies)
        {
            _discountCalculator = discountCalculator;
        }

        public override decimal GetDiscount(UserReservationRequest request)
        {
            var duration = request.CheckOut - request.CheckIn;
            if (duration >= _discountPolicies.ReservationDurationPoliticy.Duration)
                return _discountCalculator.GetDiscount(request) + _discountPolicies.ReservationDurationPoliticy.DiscountPercentage;
            return _discountCalculator.GetDiscount(request)
        }
    }
}
