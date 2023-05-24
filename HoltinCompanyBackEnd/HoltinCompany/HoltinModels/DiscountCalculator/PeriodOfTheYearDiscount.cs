using HoltinModels.Entities;
using HoltinModels.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoltinModels.DiscountCalculator
{
    public class PeriodOfTheYearDiscount : DiscountDecorator
    {
        private readonly DiscountCalculator _discountCalculator;

        public PeriodOfTheYearDiscount(DiscountCalculator discountCalculator, DiscountPolicies discuntPolicies) : base(discuntPolicies)
        {
            _discountCalculator = discountCalculator;
        }

        public override decimal GetDiscount(UserReservationRequest request)
        {
            if (request.CheckIn >= _discountPolicies.PeriodOfTheYearPoliticy.Start
                && request.CheckOut <= _discountPolicies.PeriodOfTheYearPoliticy.End)
            {
                return _discountCalculator.GetDiscount(request) + _discountPolicies.PeriodOfTheYearPoliticy.DiscountPercentage;
            }
            return _discountCalculator.GetDiscount(request);
        }
    }
}
