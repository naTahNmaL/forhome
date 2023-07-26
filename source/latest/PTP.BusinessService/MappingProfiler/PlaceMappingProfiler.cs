using AutoMapper;
using PTP.BusinessService.Models;
using PTP.DAL.Domains;

namespace PTP.BusinessService.MappingProfiler;
public class PlaceMappingProfiler : Profile
{
    public PlaceMappingProfiler()
    {
        CreateMap<Place, PlaceModel>().ReverseMap();
    }
}