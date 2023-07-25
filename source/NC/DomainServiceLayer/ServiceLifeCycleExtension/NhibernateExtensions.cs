using Common.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace ServiceLayer.ServiceLifeCycleExtension
{
    public static class NhibernateExtensions
    {
        public static void AddNhibernate(this IServiceCollection services)
        {
            var sessionFactory = NHibernateHelper.SessionFactory;
            services.AddSingleton(sessionFactory);
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
