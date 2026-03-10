using AutoMapper;
using WebApiProject.DTOs;
using WebApiProject.Models;

namespace WebApiProject.Mappings
{
    public class AppointmentProfile : Profile
    {
        public AppointmentProfile()
        {
            CreateMap<Appointment, AppointmentDto>()
                .ForMember(dest => dest.AppointmentDateTime,
                           opt => opt.MapFrom(src => src.AppointmentDateTime));
        }
    }
}