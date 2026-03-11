using WebApiProject.DTOs;

namespace WebApiProject.Services
{
    public interface ICampaignService
    {
        Task<CampaignEligibilityResponseDto?> GetEligibilityAsync(int campaignId, int patientId);
    }
}
