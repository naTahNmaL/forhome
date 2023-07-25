using AutoMapper;
using PTP.BusinessService.MappingProfiler;

namespace PTP.BusinessService.Binding;
public class MapperBinding 
{
    public IMapper Configure()
    {
        var mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<CountryMappingProfiler>();
            cfg.AddProfile<CurrencyMappingProfiler>();
            cfg.AddProfile<JourneyMappingProfiler>();
            cfg.AddProfile<PlaceMappingProfiler>();
            cfg.AddProfile<UserAvatarMappingProfiler>();
            cfg.AddProfile<UserInfoMappingProfiler>();
            cfg.AddProfile<UsersRoleMappingProfiler>();
        });
     
        return mapperConfig.CreateMapper();
    }

}