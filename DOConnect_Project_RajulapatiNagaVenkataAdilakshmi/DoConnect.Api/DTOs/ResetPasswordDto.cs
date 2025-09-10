namespace DoConnect.Api.DTOs
{
    public class ResetPasswordDto
    {
        public required string UsernameOrEmail { get; set; }
        public  required string NewPassword { get; set; }
    }
}
