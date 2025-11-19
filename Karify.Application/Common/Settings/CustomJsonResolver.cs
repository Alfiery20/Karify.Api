using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
