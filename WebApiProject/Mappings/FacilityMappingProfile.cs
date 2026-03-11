using AutoMapper;
using WebApiProject.DTOs;
using WebApiProject.Models;

namespace WebApiProject.Mappings
{
    public class FacilityMappingProfile : Profile
    {
        public FacilityMappingProfile()
        {
            CreateMap<Facility, FacilityResponseDto>()
                .ForMember(dest => dest.GeoCoordinates,
                    opt => opt.MapFrom(src => new GeoCoordinatesDto
                    {
                        Latitude = src.Latitude,
                        Longitude = src.Longitude
                    }));
        }
    }
}
