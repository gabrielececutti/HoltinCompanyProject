
using HoltinModels.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoltinModels.DiscountCalculator
{
    public abstract class DiscountDecorator : DiscountCalculator
    {
        protected DiscountPolicies _discuntPolicies;

        protected DiscountDecorator(DiscountPolicies discuntPolicies) : base(discuntPolicies)
        {
            _discuntPolicies = discuntPolicies;
        }

        public override abstract decimal GetDiscount(UserReservationRequest request);
    }
}
