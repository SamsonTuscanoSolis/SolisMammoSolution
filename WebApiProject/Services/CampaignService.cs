using AutoMapper;
using WebApiProject.DTOs;
using WebApiProject.Repositories.Interface;
using WebApiProject.Services.Interface;

namespace WebApiProject.Services
{
    public class CampaignService : ICampaignService
    {
        private readonly ICampaignRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<CampaignService> _logger;

        public CampaignService(
            ICampaignRepository repository,
            IMapper mapper,
            ILogger<CampaignService> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<CampaignEligibilityResponseDto?> GetEligibilityAsync(int campaignId, int patientId)
        {
            _logger.LogInformation("Checking eligibility for CampaignId {CampaignId} and PatientId {PatientId}",
                campaignId, patientId);

            var eligibility = await _repository.GetEligibilityAsync(campaignId, patientId);

            if (eligibility == null)
            {
                _logger.LogWarning("Eligibility not found for CampaignId {CampaignId}, PatientId {PatientId}",
                    campaignId, patientId);
                return null;
            }

            return _mapper.Map<CampaignEligibilityResponseDto>(eligibility);
        }
    }
}
