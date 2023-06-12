namespace ErpaHolding.Business.DTOs.UserDto
{
    public class LoginResponseDto
    {
        public bool IsLogin { get; set; }
        public List<string>? Roles { get; set; }
        public Guid UserId { get; set; }
    }
}
