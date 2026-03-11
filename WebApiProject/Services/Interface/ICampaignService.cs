using WebApiProject.DTOs;

namespace WebApiProject.Services.Interface
{
    public interface ICampaignService
    {
        Task<CampaignEligibilityResponseDto?> GetEligibilityAsync(int campaignId, int patientId);
    }
}
