using AutoMapper;
using PersistentLayer.Domains;
using PIMTool.Models;
using ServiceLayer.DTO;

namespace PIMTool.Mapper
{
    public class ViewMapper : Profile
    {
        public ViewMapper()
        {
            CreateMap<ProjectDto, ProjectViewModel>();
        }

    }
}
