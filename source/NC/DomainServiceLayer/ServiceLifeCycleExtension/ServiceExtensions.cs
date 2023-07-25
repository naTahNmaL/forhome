using Microsoft.Extensions.DependencyInjection;
using ServiceLayer.Services;

namespace ServiceLayer.ServiceLifeCycleExtension
{
    public static class ServiceExtensions 
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IProjectService, ProjectService>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IGroupService, GroupService>();
        }
    }
}
