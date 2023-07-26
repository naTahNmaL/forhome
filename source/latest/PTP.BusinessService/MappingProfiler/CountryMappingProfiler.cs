using AutoMapper;
using PTP.BusinessService.Models;
using PTP.DAL.Domains;

namespace PTP.BusinessService.MappingProfiler;

public class CountryMappingProfiler : Profile
{
    public CountryMappingProfiler()
    {
        CreateMap<Country, CountryModel>().ReverseMap();
    }
}