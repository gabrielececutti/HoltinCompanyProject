
using HoltinModels.Entities;
using HoltinModels.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoltinModels.DiscountCalculator
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
            if (request.Client.Fidelity == _discountPolicies.FidelityPoliticy.Fidelity) 
                return _discountCalculator.GetDiscount(request) + _discountPolicies.FidelityPoliticy.DiscountPercentage;
            return _discountCalculator.GetDiscount(request);
        }
    }
}
