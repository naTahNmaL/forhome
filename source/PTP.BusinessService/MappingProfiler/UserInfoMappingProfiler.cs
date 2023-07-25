using AutoMapper;
using PTP.BusinessService.Models;
using PTP.DAL.Domains;

namespace PTP.BusinessService.MappingProfiler;
public class UserInfoMappingProfiler : Profile
{
    public UserInfoMappingProfiler()
    {
        CreateMap<UserInfo, UserInfoModel >().ReverseMap();
    }
}