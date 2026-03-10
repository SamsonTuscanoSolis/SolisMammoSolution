using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiProject.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/facilities")]

    public class FacilitiesController : ControllerBase
    {
        // GET /api/v1/facilities
        [HttpGet]
        public IActionResult GetFacilities()
        {
            // Sample mock data for facilities
            var facilities = new[]
            {
                new { FacilityId = 1, Name = "City Hospital", Location = "Downtown" },
                new { FacilityId = 2, Name = "Green Valley Clinic", Location = "Uptown" },
                new { FacilityId = 3, Name = "Sunrise Medical Center", Location = "Suburbs" }
            };

            if (!facilities.Any())
            {
                return NotFound("No facilities found");
            }

            return Ok(facilities);
        }
    }
}
