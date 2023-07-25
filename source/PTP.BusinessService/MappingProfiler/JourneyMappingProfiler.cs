using AutoMapper;
using PTP.BusinessService.Models;
using PTP.DAL.Domains;

namespace PTP.BusinessService.MappingProfiler;

public class JourneyMappingProfiler : Profile
{
    public JourneyMappingProfiler()
    {
        CreateMap<Journey, JourneyModel>().ReverseMap();
    }
}