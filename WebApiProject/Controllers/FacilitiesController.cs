using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiProject.Services.Interface;

namespace WebApiProject.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/facilities")]
    public class FacilitiesController : ControllerBase
    {
        private readonly IFacilityService _service;
        private readonly ILogger<FacilitiesController> _logger;

        public FacilitiesController(IFacilityService service, ILogger<FacilitiesController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetFacilities()
        {
            _logger.LogInformation("Fetching list of facilities.");

            try
            {
                var facilities = _service.GetFacilities();

                if (!facilities.Any())
                {
                    _logger.LogWarning("No facilities found.");
                    return NotFound();
                }

                _logger.LogInformation("Successfully retrieved {FacilityCount} facility(ies).", facilities.Count());
                return Ok(facilities);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving facilities.");
                return StatusCode(500, "An unexpected error occurred.");
            }
        }
    }
}
