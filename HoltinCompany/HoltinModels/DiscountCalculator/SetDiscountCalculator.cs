using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoltinModels.DiscountCalculator
{
    public class SetDiscountCalculator
    {
        private readonly DiscountPolicies _discountPolicies;

        public SetDiscountCalculator(DiscountPolicies discountPolicies)
        {
            _discountPolicies = discountPolicies;
        }

        public DiscountCalculator GetCalculator()
        {
            var discountBase = new BaseDiscount(_discountPolicies);
            var discountWithFidelity = new FidelityDiscount(discountBase, _discountPolicies);
            var discountDuration = new ReservationDurationDiscount(discountWithFidelity, _discountPolicies);
            var discountPeriod = new PeriodOfTheYearDiscount(discountDuration, _discountPolicies);
            return discountPeriod;
        }
    }
}
