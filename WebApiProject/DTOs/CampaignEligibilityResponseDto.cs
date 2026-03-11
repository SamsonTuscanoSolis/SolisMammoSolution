namespace WebApiProject.DTOs
{
    public class CampaignEligibilityResponseDto
    {
        public bool Eligible { get; set; }

        public List<string> Reasons { get; set; } = new();

        public DateTime? LastExamDate { get; set; }

        public DateTime? NextDueDate { get; set; }

        public bool OptOutStatus { get; set; }

        public bool InsuranceEligible { get; set; }

        public List<string> SuppressionRulesApplied { get; set; } = new();
    }
}
