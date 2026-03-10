namespace WebApiProject.Models
{
    public class InsuranceStatus
    {
        public int PatientId { get; set; }
        public string Provider { get; set; } = null!;
        public string PolicyNumber { get; set; } = null!;
        public bool IsValid { get; set; }
        public DateTime VerifiedDate { get; set; }
    }
}
