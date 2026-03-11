using AutoMapper;
using WebApiProject.DTOs;
using WebApiProject.Repositories.Interface;
using WebApiProject.Services.Interface;

namespace WebApiProject.Services
{
    public class FacilityService : IFacilityService
    {
        private readonly IFacilityRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<FacilityService> _logger;

        public FacilityService(
            IFacilityRepository repository,
            IMapper mapper,
            ILogger<FacilityService> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public IEnumerable<FacilityResponseDto> GetFacilities()
        {
            _logger.LogInformation("Fetching facilities");

            var facilities = _repository.GetFacilities();

            return _mapper.Map<IEnumerable<FacilityResponseDto>>(facilities);
        }
    }
}
