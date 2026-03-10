using AutoMapper;
using WebApiProject.DTOs;
using WebApiProject.Models;

namespace WebApiProject.Mappings
{
    public class ExamResultProfile : Profile
    {
        public ExamResultProfile()
        {
            CreateMap<ExamResult, ExamResultDto>()
                .ForMember(dest => dest.ExamId,
                           opt => opt.MapFrom(src => src.Id));
        }
    }
}
