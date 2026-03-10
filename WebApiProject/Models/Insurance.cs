namespace WebApiProject.Models
{
    public class Insurance
    {
        public int PatientId { get; set; }

        public string InsurancePlanId { get; set; }

        public string ExamType { get; set; }

        public int FacilityId { get; set; }

        public bool Eligible { get; set; }

        public decimal Copay { get; set; }

        public decimal Coinsurance { get; set; }

        public decimal DeductibleRemaining { get; set; }

        public bool AuthRequired { get; set; }

        public string AuthStatus { get; set; }

        public DateTime EffectiveDate { get; set; }

        public string PlanDetails { get; set; }

        public string Provider { get; set; } = null!;
        public string PolicyNumber { get; set; } = null!;
        public bool IsValid { get; set; }
        public DateTime VerifiedDate { get; set; }
    }
}
