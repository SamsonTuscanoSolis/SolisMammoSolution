using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiProject.Services.Interface;

namespace WebApiProject.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/scheduling")]
    public class SchedulingController : ControllerBase
    {
        private readonly ISchedulingService _service;
        private readonly ILogger<SchedulingController> _logger;

        public SchedulingController(ISchedulingService service, ILogger<SchedulingController> logger)
        {
            _service = service;
            _logger = logger;
        }

        // GET /api/v1/scheduling/availability?facilityId=1&modality=CT&examType=Chest&dateFrom=2026-03-01&dateTo=2026-03-10
        [HttpGet("availability")]
        public async Task<IActionResult> GetAvailableSlots([FromQuery] int facilityId, [FromQuery] string modality, [FromQuery] string examType, [FromQuery] DateTime dateFrom, [FromQuery] DateTime dateTo, [FromQuery] int? insurancePlanId)
        {
            _logger.LogInformation("Fetching available slots for facilityId {FacilityId}, modality {Modality}, examType {ExamType}, from {DateFrom} to {DateTo}", facilityId, modality, examType, dateFrom, dateTo);

            var availableSlots = await _service.GetAvailableSlotsAsync(facilityId, modality, examType, dateFrom, dateTo, insurancePlanId);

            if (!availableSlots.Any())
            {
                return NotFound("No available slots found for the selected criteria.");
            }

            return Ok(new { AvailableSlots = availableSlots });
        }
    }
}
