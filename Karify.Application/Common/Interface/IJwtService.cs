using System.Security.Claims;

namespace Karify.Application.Common.Interface
{
    public interface IJwtService
    {
        string Generate(Claim[] claims, bool recordar, DateTime? experisUtc = null, string audience = null);
    }
}
