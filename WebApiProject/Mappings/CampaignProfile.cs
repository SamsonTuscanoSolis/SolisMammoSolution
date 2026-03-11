using AutoMapper;
using WebApiProject.DTOs;
using WebApiProject.Models;

namespace WebApiProject.Mappings
{
    public class CampaignProfile : Profile
    {
        public CampaignProfile()
        {
            CreateMap<CampaignEligibility, CampaignEligibilityResponseDto>();
        }
    }
}
