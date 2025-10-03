using System.Security.Claims;

namespace api.Claims
{
    public static class ClaimsExtensions
    {
        public static string GetUsername(this ClaimsPrincipal user)
        {
            var claim = user.Claims.SingleOrDefault(x => x.Type == ClaimTypes.Name);
            return claim?.Value;
        }
    }
}
