using api.AppUserIdentity;

namespace api.Service
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
