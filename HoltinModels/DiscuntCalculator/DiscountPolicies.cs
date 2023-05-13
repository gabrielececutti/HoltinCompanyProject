namespace HoltinWebApplication
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
        public decimal DiscountPeRcentage { get; set; }
    }

    public class ReservationDurationPoliticy
    {
        public TimeSpan Duration { get; set; }
        public decimal DiscountPeRcentage { get; set; }
    }

    public class PeriodOfTheYearPoliticy
    {
        public TimeSpan PeriodOfTheYear { get; set; }
        public decimal DiscountPercentage { get; set; }
    }
}
