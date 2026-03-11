using WebApiProject.Data;
using WebApiProject.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApiProject.Repositories
{
    public class SchedulingRepository : ISchedulingRepository
    {
        private readonly AppDbContext _context;

        public SchedulingRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Slot>> GetAvailableSlotsAsync(int facilityId, string modality, string examType, DateTime dateFrom, DateTime dateTo, int? insurancePlanId)
        {
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

            // Use the async method ToListAsync() to ensure the query is executed asynchronously
            return await query.ToListAsync();
        }
    }
}
