using Microsoft.Extensions.Localization;
using System.Reflection;

namespace MyFirstAzureWebApp.Controllers
{
    public class LanguageService
    {
        private readonly IStringLocalizer _localizer;

        public LanguageService(IStringLocalizerFactory factory)
        {
            var type = typeof(ShareResources);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            _localizer = factory.Create("Languages", assemblyName.Name);
        }

        public LocalizedString GetKey(string key)
        {
            return _localizer[key];
        }
    }
}
