using api.AppUserIdentity;

namespace api.Services.Token
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
