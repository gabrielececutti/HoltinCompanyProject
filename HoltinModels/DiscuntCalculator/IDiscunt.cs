using HoltinWebApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoltinModels.DiscuntPoliticies
{
    public abstract class Discunt
    {
        protected readonly DiscountPolicies _discountPolicies;
        protected Discunt(DiscountPolicies discuntPolicies)
        {
            _discountPolicies = discuntPolicies;
        }
        public abstract decimal GetDiscount();
    }
}
