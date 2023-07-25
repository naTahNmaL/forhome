using AutoMapper;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using NHibernate;
using Ninject;
using Ninject.Modules;
using Ninject.Web.AspNetCore;
using Ninject.Web.AspNetCore.Hosting;
using Ninject.Web.Common;
using Ninject.Web.Common.SelfHost;
using PTP.BusinessService.Binding;
using PTP.BusinessService.DIConfig;
using PTP.BusinessService.Interfaces;
using PTP.BusinessService.MappingProfiler;
using PTP.BusinessService.Services;
using PTP.DAL.Config;
using PTP.DAL.Interfaces;
using PTP.DAL.Repositories;
using PTP.DAL.UnitOfWork;


var builder = WebApplication.CreateBuilder(args);
var kernel = new StandardKernel(new ServicesBinding());

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
});

builder.Services.AddSingleton(mapperConfig.CreateMapper());

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUserInfoRepository, UserInfoRepository>();
builder.Services.AddScoped<IUserInfoServices, UserInfoService>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<ICountryServices, CountryServices>();
builder.Services.AddScoped<ICurrencyRepository, CurrencyRepository>();
builder.Services.AddScoped<ICurrencyServices, CurrencyServices>();
builder.Services.AddScoped<IDefaultDataService, DefaultDataService>();
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

