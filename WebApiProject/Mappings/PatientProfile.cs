using AutoMapper;
using WebApiProject.DTOs;
using WebApiProject.Models;

namespace WebApiProject.Mappings
{
    public class PatientProfile : Profile
    {
        public PatientProfile()
        {
            CreateMap<Patient, PatientResponseDto>();
        }
    }
}
