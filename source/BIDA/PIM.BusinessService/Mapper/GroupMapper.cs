using AutoMapper;
using PIM.BusinessService.Models;
using PIM.DataAccess.Entity;

namespace PIM.BusinessService.Mapper
{
    public class GroupMapper
    {
        public static void CreateMap(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Group, GroupModel>().ReverseMap();
        }
    }
}
