
using HoltinModels.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoltinModels.DiscountCalculator
{
    public class BaseDiscount : DiscountDecorator
    {
        public BaseDiscount(DiscountPolicies discuntPolicies) : base(discuntPolicies)
        {
        }

        public override decimal GetDiscount(UserReservationRequest request)
        {
            return 0;
        }
    }
}
