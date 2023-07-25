using AutoMapper;
using PTP.BusinessService.Models;
using PTP.DAL.Domains;

namespace PTP.BusinessService.MappingProfiler;
public class UsersRoleMappingProfiler : Profile
{
    public UsersRoleMappingProfiler()
    {
        CreateMap<UsersRole, UsersRoleModel>().ReverseMap();
    }
}