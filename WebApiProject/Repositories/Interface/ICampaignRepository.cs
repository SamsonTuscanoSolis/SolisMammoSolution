using WebApiProject.Models;

namespace WebApiProject.Repositories.Interface
{
    public interface ICampaignRepository
    {
        Task<CampaignEligibility?> GetEligibilityAsync(int campaignId, int patientId);
    }
}
