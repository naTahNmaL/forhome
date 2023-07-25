using Common;
using Microsoft.Extensions.DependencyInjection;

namespace ServiceLayer.ServiceLifeCycleExtension
{
    public static class GlobalResourceExtension
    {
        public static void AddGlobalResourceFile(this IServiceCollection services)
        {
            services.AddTransient<ISharedViewLocalizer, SharedViewLocalizer>();
        }

    }
}
