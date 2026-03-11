using WebApiProject.Models;
using WebApiProject.Repositories.Interface;

namespace WebApiProject.Repositories
{
    public class CampaignRepository : ICampaignRepository
    {
        public async Task<CampaignEligibility?> GetEligibilityAsync(int campaignId, int patientId)
        {
            // Mock data (replace with DB call)

            var result = new CampaignEligibility
            {
                CampaignId = campaignId,
                PatientId = patientId,
                Eligible = true,
                Reasons = new List<string>
                {
                    "Age criteria met",
                    "No exam in last 12 months"
                },
                LastExamDate = DateTime.UtcNow.AddMonths(-14),
                NextDueDate = DateTime.UtcNow.AddMonths(1),
                OptOutStatus = false,
                InsuranceEligible = true,
                SuppressionRulesApplied = new List<string>
                {
                    "No active suppression rules"
                }
            };

            return await Task.FromResult(result);
        }
    }
}
