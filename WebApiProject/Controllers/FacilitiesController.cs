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

        public FacilitiesController(IFacilityService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetFacilities()
        {
            var facilities = _service.GetFacilities();

            if (!facilities.Any())
                return NotFound();

            return Ok(facilities);
        }
    }
}
