using AutoMapper;
using PIM.BusinessService.Models;
using PIM.DataAccess.Entity;

namespace PIM.BusinessService.Mapper
{
    public class EmployeeMapper
    {
        public static void CreateMap(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Employee, EmployeeModel>().ReverseMap();
        }
    }
}
