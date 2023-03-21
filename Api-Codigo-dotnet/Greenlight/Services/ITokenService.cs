using Greenlight.Entitys;

namespace Greenlight.Services
{
    public interface ITokenService
    {
        string GetToken(string key, string issuer, string audience, Cliente user);
    }
}
