using WebApiProject.DTOs;

namespace WebApiProject.Services
{
    public interface ISchedulingService
    {
        Task<IEnumerable<SlotDTO>> GetAvailableSlotsAsync(int facilityId, string modality, string examType, DateTime dateFrom, DateTime dateTo, int? insurancePlanId);
    }
}
