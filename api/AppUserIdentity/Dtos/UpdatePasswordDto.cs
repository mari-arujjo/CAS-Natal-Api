namespace api.AppUserIdentity.Dtos
{
    public class UpdatePasswordDto
    {
        public string? currentPassword { get; set; }
        public string? newPassword { get; set; }
    }
}
