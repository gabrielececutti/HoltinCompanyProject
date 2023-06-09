﻿using System.ComponentModel;
using System.Text.Json.Serialization;

namespace HoltinModels.DiscountCalculator
{
    public class DiscountPolicies
    {
        public FidelityPoliticy FidelityPoliticy { get; set; } 
        public ReservationDurationPoliticy ReservationDurationPoliticy { get; set; }
        public PeriodOfTheYearPoliticy PeriodOfTheYearPoliticy { get; set; } 
    }

    public class FidelityPoliticy
    {
        public bool Fidelity { get; set; }
        public decimal DiscountPercentage { get; set; }
    }

    public class ReservationDurationPoliticy
    {
        public int Duration { get; set; }
        public decimal DiscountPercentage { get; set; }
    }

    public class PeriodOfTheYearPoliticy
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public decimal DiscountPercentage { get; set; }
    }
}
