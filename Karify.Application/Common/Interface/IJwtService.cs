using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Karify.Application.Common.Interface
{
    public interface IJwtService
    {
        string Generate(Claim[] claims, bool recordar, DateTime? experisUtc = null, string audience = null);
    }
}
