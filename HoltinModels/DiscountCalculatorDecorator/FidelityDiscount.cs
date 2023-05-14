
using HoltinModels.Entities;
using HoltinModels.Requests;
using HoltinWebApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoltinModels.DiscountCalculatorDecoarator
{
    public class FidelityDiscount : DiscountDecorator
    {
        private readonly DiscountCalculator _discountCalculator;

        public FidelityDiscount(DiscountCalculator discountCalculator, DiscountPolicies discuntPolicies) : base(discuntPolicies)
        {
            _discountCalculator = discountCalculator;
        }

        public override decimal GetDiscount(UserReservationRequest request)
        {
            var fidelityDiscount = request.Client.Fidelity == _discountPolicies.FidelityPoliticy.Fidelity ? _discountPolicies.FidelityPoliticy.DiscountPercentage : 0;
            return _discountCalculator.GetDiscount(request) + fidelityDiscount;
        }
    }
}
