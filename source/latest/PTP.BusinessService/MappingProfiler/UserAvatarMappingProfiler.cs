using AutoMapper;
using PTP.BusinessService.Models;
using PTP.DAL.Domains;

namespace PTP.BusinessService.MappingProfiler;
public class UserAvatarMappingProfiler : Profile
{
    public UserAvatarMappingProfiler()
    {
        CreateMap<UserAvatar, UserAvatarModel>().ReverseMap();
    }
}