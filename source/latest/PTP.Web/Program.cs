using AutoMapper;
using Ninject;
using PTP.BusinessService.DIConfig;

using PTP.BusinessService.Interfaces;
using PTP.BusinessService.MappingProfiler;
using PTP.BusinessService.Services;
using PTP.DAL.Config;
using PTP.DAL.Interfaces;
using PTP.DAL.Repositories;
using PTP.DAL.UnitOfWork;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<INHibernateConfig, NHibernateConfig>();
var mapperConfig = new MapperConfiguration(cfg =>
{
    cfg.AddProfile<CountryMappingProfiler>();
    cfg.AddProfile<CurrencyMappingProfiler>();
    cfg.AddProfile<JourneyMappingProfiler>();
    cfg.AddProfile<PlaceMappingProfiler>();
    cfg.AddProfile<UserAvatarMappingProfiler>();
    cfg.AddProfile<UserInfoMappingProfiler>();
    cfg.AddProfile<UsersRoleMappingProfiler>();
    cfg.AddProfile<UserLoginRequestDtoProfiler>();
});

builder.Services.AddSingleton(mapperConfig.CreateMapper());

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUserInfoRepository, UserInfoRepository>();
builder.Services.AddScoped<ICurrencyRepository, CurrencyRepository>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();

builder.Services.AddScoped<IUserInfoServices, UserInfoService>();
builder.Services.AddScoped<ICountryServices, CountryServices>();
builder.Services.AddScoped<ICurrencyServices, CurrencyServices>();
builder.Services.AddScoped<IDefaultDataService, DefaultDataService>();
builder.Services.AddScoped<IAuthServices, AuthServices>();
builder.Services.AddControllers();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();

