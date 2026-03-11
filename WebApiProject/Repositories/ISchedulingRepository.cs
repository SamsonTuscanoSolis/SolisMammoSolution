using WebApiProject.Models;

namespace WebApiProject.Repositories
{
    public interface ISchedulingRepository
    {
        Task<IEnumerable<Slot>> GetAvailableSlotsAsync(int facilityId, string modality, string examType, DateTime dateFrom, DateTime dateTo, int? insurancePlanId);
    }
}
