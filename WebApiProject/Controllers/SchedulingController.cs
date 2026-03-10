using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiProject.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/scheduling")]
    public class SchedulingController : ControllerBase
    {
        // GET /api/v1/scheduling/availability?date=2026-03-10
        [HttpGet("availability")]
        public IActionResult GetAvailableSlots([FromQuery] string? date)
        {
            // Sample mock available slots
            var allSlots = new[]
            {
                new { SlotId = 1, Time = "09:00 AM", IsAvailable = true },
                new { SlotId = 2, Time = "10:00 AM", IsAvailable = false },
                new { SlotId = 3, Time = "11:00 AM", IsAvailable = true },
                new { SlotId = 4, Time = "01:00 PM", IsAvailable = true },
                new { SlotId = 5, Time = "02:00 PM", IsAvailable = false },
            };

            // Filter only available slots
            var availableSlots = allSlots.Where(s => s.IsAvailable);

            if (!availableSlots.Any())
            {
                return NotFound("No available slots for the selected date");
            }

            return Ok(new
            {
                Date = date ?? DateTime.Today.ToString("yyyy-MM-dd"),
                AvailableSlots = availableSlots
            });
        }
    }
}
