using AutoMapper;
using PIM.BusinessService.Models;
using PIM.DataAccess.Entity;

namespace PIM.BusinessService.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeModel>().ReverseMap();
            CreateMap<Group, GroupModel>().ReverseMap();
            CreateMap<Project, ProjectModel>().ReverseMap();
            CreateMap<ProjectModel, ProjectViewModel>().ReverseMap();
        }
    }
}
