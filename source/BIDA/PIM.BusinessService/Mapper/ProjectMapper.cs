using AutoMapper;
using PIM.BusinessService.Models;
using PIM.DataAccess.Entity;

namespace PIM.BusinessService.Mapper
{
    public class ProjectMapper
    {
        public static void CreateMap(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Project, ProjectModel>().ReverseMap();
            cfg.CreateMap<ProjectModel, ProjectViewModel>().ReverseMap();
        }
    }
}
