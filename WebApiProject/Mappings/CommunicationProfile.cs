using AutoMapper;
using WebApiProject.DTOs;
using WebApiProject.Models;

namespace WebApiProject.Mappings
{
    public class CommunicationProfile : Profile
    {
        public CommunicationProfile()
        {
            CreateMap<Communication, CommunicationDto>();
        }
    }
}