using api.AppUserIdentity.Dtos;
using System.Runtime.CompilerServices;

namespace api.AppUserIdentity
{
    public static class AppUserMapper
    {
        public static AppUserDto ConvertToUserDto(this AppUser u)
        {
            return new AppUserDto
            {
                id = u.Id,
                name = u.FullName,
                username = u.UserName,
                email = u.Email,
                privateRole = u.PrivateRole,
                avatar = u.Avatar,
                createdAt = u.CreatedAt,
            };
        }
    }
}
