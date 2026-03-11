using AutoMapper;
using WebApiProject.DTOs;
using WebApiProject.Repositories.Interface;
using WebApiProject.Services.Interface;

namespace WebApiProject.Services
{
    public class SchedulingService : ISchedulingService
    {
        private readonly ISchedulingRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<SchedulingService> _logger;

        public SchedulingService(ISchedulingRepository repository, IMapper mapper, ILogger<SchedulingService> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<SlotDTO>> GetAvailableSlotsAsync(int facilityId, string modality, string examType, DateTime dateFrom, DateTime dateTo, int? insurancePlanId)
        {
            try
            {
                _logger.LogInformation("Fetching available slots from repository");

                var slots = await _repository.GetAvailableSlotsAsync(facilityId, modality, examType, dateFrom, dateTo, insurancePlanId);

                if (slots == null || !slots.Any())
                {
                    _logger.LogWarning("No available slots found.");
                    return Enumerable.Empty<SlotDTO>();
                }

                var slotDTOs = _mapper.Map<IEnumerable<SlotDTO>>(slots);
                return slotDTOs;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching available slots.");
                throw;
            }
        }
    }
}
