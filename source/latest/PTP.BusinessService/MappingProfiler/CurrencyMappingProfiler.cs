using AutoMapper;
using PTP.BusinessService.Models;

using PTP.DAL.Domains;

namespace PTP.BusinessService.MappingProfiler;
public class CurrencyMappingProfiler : Profile
{
    public CurrencyMappingProfiler()
    {
        CreateMap<Currency, CurrencyModel>().ReverseMap();
    }
}