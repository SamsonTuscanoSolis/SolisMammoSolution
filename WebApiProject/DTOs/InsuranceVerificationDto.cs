namespace WebApiProject.DTOs
{
    public class InsuranceVerificationDto
    {
        public bool Eligible { get; set; }

        public decimal Copay { get; set; }

        public decimal Coinsurance { get; set; }

        public decimal DeductibleRemaining { get; set; }

        public bool AuthRequired { get; set; }

        public string AuthStatus { get; set; }

        public DateTime EffectiveDate { get; set; }

        public string PlanDetails { get; set; }
    }
}
