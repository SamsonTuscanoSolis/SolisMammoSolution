using WebApiProject.Data;
using WebApiProject.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApiProject.Repositories
{
    public class SchedulingRepository : ISchedulingRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<SchedulingRepository> _logger;

        public SchedulingRepository(AppDbContext context, ILogger<SchedulingRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<Slot>> GetAvailableSlotsAsync(int facilityId, string modality, string examType, DateTime dateFrom, DateTime dateTo, int? insurancePlanId)
        {
            _logger.LogInformation("Fetching available slots for FacilityId: {FacilityId}, Modality: {Modality}, ExamType: {ExamType}, DateFrom: {DateFrom}, DateTo: {DateTo}",
                                   facilityId, modality, examType, dateFrom, dateTo);

            var query = _context.Slots.AsQueryable();

            // Filter by facility, modality, exam type, date range, and insurance plan
            query = query.Where(s => s.FacilityId == facilityId &&
                                     s.Modality == modality &&
                                     s.ExamType == examType &&
                                     s.DateTime >= dateFrom &&
                                     s.DateTime <= dateTo);

            if (insurancePlanId.HasValue)
            {
                query = query.Where(s => s.InsurancePlanId == insurancePlanId);
            }

            // Filter for available slots
            query = query.Where(s => s.IsAvailable);

            try
            {
                var availableSlots = await query.ToListAsync();

                if (!availableSlots.Any())
                {
                    _logger.LogWarning("No available slots found for the provided filters.");
                }

                _logger.LogInformation("Successfully fetched {SlotCount} available slot(s).", availableSlots.Count);
                return availableSlots;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching available slots.");
                throw; // Rethrow the exception after logging it
            }
        }
    }
}
