using api.AppUserIdentity;

namespace api.AppUserIdentity.Service
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
