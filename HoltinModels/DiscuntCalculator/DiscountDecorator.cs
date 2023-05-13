using HoltinModels.DiscuntPoliticies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoltinModels.DiscountPolicies
{
    public abstract class DiscountDecorator : Discunt
    {
        protected DiscountDecorator(DiscountPolicies discuntPolicies) : base(discuntPolicies)
        {
        }

        public override decimal GetDiscount()
        {
            throw new NotImplementedException();
        }
    }
}
