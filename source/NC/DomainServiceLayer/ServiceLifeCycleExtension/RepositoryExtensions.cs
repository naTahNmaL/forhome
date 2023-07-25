using Microsoft.Extensions.DependencyInjection;
using PersistentLayer.Repositories;

namespace ServiceLayer.ServiceLifeCycleExtension
{
    public static class RepositoryExtensions
    {
        public static void AddDataAccessServices(this IServiceCollection services)
        {
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IProjectRepository, ProjectRepository>();
            services.AddTransient<IGroupRepository, GroupRepository>();

        }
    }
}
