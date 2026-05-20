using Newtonsoft.Json.Serialization;

namespace Karify.Application.Common.Settings
{
    public class CustomJsonResolver : DefaultContractResolver
    {
        public CustomJsonResolver() : base()
        {
            NamingStrategy = new CamelCaseNamingStrategy();
        }
    }
}
