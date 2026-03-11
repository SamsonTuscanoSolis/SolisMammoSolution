using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiProject.Services.Interface;

namespace WebApiProject.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/campaigns")]
    public class CampaignsController : ControllerBase
    {
        private readonly ICampaignService _service;
        private readonly ILogger<CampaignsController> _logger;

        public CampaignsController(ICampaignService service, ILogger<CampaignsController> logger)
        {
            _service = service;
            _logger = logger;
        }

        // GET /api/v1/campaigns/{campaignId}/eligibility/{patientId}
        [HttpGet("{campaignId}/eligibility/{patientId}")]
        public async Task<IActionResult> GetCampaignEligibility(int campaignId, int patientId)
        {
            _logger.LogInformation("API called for CampaignId {CampaignId}, PatientId {PatientId}",
                campaignId, patientId);

            var result = await _service.GetEligibilityAsync(campaignId, patientId);

            if (result == null)
                return NotFound("Eligibility data not found");

            return Ok(result);
        }
    }
}
