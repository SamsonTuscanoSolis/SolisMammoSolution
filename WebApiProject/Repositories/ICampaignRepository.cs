using WebApiProject.Models;

namespace WebApiProject.Repositories
{
    public interface ICampaignRepository
    {
        Task<CampaignEligibility?> GetEligibilityAsync(int campaignId, int patientId);
    }
}
