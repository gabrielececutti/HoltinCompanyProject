using HoltinModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoltinModels.DiscuntPoliticies
{
    public class FidelityDiscount : DiscountDecorator
    {
        private readonly Client _client;
        private readonly IDiscunt _discountPolicies;

        public FidelityDiscount(IDiscunt discountPolicies, Client client)
        {
            _client = client;
            _discountPolicies = discountPolicies;
        }

        public override decimal GetDiscount()
        {
            var fidelityDiscunt = _client.Fidelity is true ? _discountPolicies. : 0;
            return _discountPolicies.GetDiscount() + fidelityDiscunt;
        }     
    }
}
