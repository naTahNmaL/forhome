using Microsoft.Extensions.Localization;
using System.Reflection;

namespace Common
{
    public class SharedViewLocalizer : ISharedViewLocalizer
    {
        private readonly IStringLocalizer localizer;

        public SharedViewLocalizer(IStringLocalizerFactory factory)
        {
            var type = typeof(SharedResource);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            localizer = factory.Create("SharedResource", assemblyName.Name);
        }

        public LocalizedString this[string key] => localizer[key];

        public LocalizedString GetLocalizedString(string key)
        {
            return localizer[key];
        }
    }



    public interface ISharedViewLocalizer
    {
        public LocalizedString this[string key]
        {
            get;
        }

        LocalizedString GetLocalizedString(string key);
    }


    public class SharedResource
    {

    }
}
