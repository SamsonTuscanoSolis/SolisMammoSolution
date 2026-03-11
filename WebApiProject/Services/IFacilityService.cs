using WebApiProject.DTOs;

namespace WebApiProject.Services
{
    public interface IFacilityService
    {
        IEnumerable<FacilityResponseDto> GetFacilities();
    }
}
