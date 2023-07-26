using AutoMapper;
using PTP.BusinessService.DTO;

using PTP.DAL.Domains;

namespace PTP.BusinessService.MappingProfiler;

public class UserLoginRequestDtoProfiler: Profile
{
    public UserLoginRequestDtoProfiler()
    {
        CreateMap<UserInfo, UserLoginRequestDTO >().ReverseMap();
    }
}