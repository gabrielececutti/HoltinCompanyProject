﻿using HoltinModels.Requests;
using HoltinWebApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoltinModels.DiscountCalculatorDecoarator
{
    public abstract class DiscountCalculator
    {
        protected readonly DiscountPolicies _discountPolicies;
        public DiscountCalculator (DiscountPolicies discuntPolicies)
        {
            _discountPolicies = discuntPolicies;

        }
        public abstract decimal GetDiscount(UserReservationRequest request);
    }
}
