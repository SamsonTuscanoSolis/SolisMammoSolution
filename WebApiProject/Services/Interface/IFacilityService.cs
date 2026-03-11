using WebApiProject.DTOs;

namespace WebApiProject.Services.Interface
{
    public interface IFacilityService
    {
        IEnumerable<FacilityResponseDto> GetFacilities();
    }
}
