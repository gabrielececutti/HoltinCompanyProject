
using HoltinModels.Requests;
using HoltinWebApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoltinModels.DiscountCalculatorDecoarator
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
