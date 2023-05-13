using HoltinModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoltinModels.DiscuntPoliticies
{
    public class PeriodOfTheYearDiscunt : DiscountDecorator
    {
        private readonly Reservation _reservation;
        private readonly IDiscunt _discountPolicies;

        public PeriodOfTheYearDiscunt(Reservation reservation, IDiscunt discountPolicies)
        {
            _reservation = reservation;
            _discountPolicies = discountPolicies;
        }

        public override decimal GetDiscount()
        {
            throw new NotImplementedException();
        }
    }
}
