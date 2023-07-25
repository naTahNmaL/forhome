using AutoMapper;
using PersistentLayer.Domains;
using ServiceLayer.DTO;
using ServiceLayer.ProfileMapper.Resolver;

namespace ServiceLayer.ProfileMapper
{
    public class ServiceMapper : Profile
    {
        public ServiceMapper()
        {

            CreateMap<BaseProjectDto, Project>()
              .ForMember(dest => dest.Group, opt => opt.MapFrom<GroupResolver>())
                .ForMember(dest => dest.Employees, opt => opt.MapFrom<EmployeeResolver>());

            CreateMap<Project, UpdateProjectDto>()
             .ForMember(dest => dest.GroupID, opt => opt.MapFrom(src => src.Group.Id))
               .ForMember(dest => dest.Employees, opt => opt.MapFrom(src => src.Employees.Select(d => d.Visa)));

            CreateMap<Project, ProjectDto>()
                .ForMember(d => d.EmployeeDtos, opt => opt.Ignore())
                .ForMember(d => d.GroupId, opt => opt.MapFrom(d => d.Group.Id));
            CreateMap<Employee, EmployeeDto>();
            CreateMap<Group, GroupDto>();
        }

    }


}
