using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiProject.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/campaigns")]
    public class CampaignsController : ControllerBase
    {
        // GET /api/v1/campaigns/{campaignId}/eligibility/{patientId}
        [HttpGet("{campaignId}/eligibility/{patientId}")]
        public IActionResult GetCampaignEligibility(int campaignId, int patientId)
        {
            // Sample mock data for eligibility
            var eligibility = new
            {
                CampaignId = campaignId,
                PatientId = patientId,
                IsEligible = true,
                Reason = "Patient meets age and medical criteria",
                CheckedDate = DateTime.UtcNow.ToString("yyyy-MM-dd")
            };

            // Return 404 if not eligible (optional)
            // if (!eligibility.IsEligible) return NotFound("Patient not eligible for this campaign");

            return Ok(eligibility);
        }
    }
}
