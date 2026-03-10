using AutoMapper;
using WebApiProject.DTOs;
using WebApiProject.Models;
namespace WebApiProject.Mappings
{
    public class InsuranceProfile : Profile
    {
        public InsuranceProfile()
        {
            CreateMap<Insurance, InsuranceVerificationDto>();
        }
    }
}