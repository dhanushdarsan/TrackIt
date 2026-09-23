namespace TrackIt.Application.DTOs
{
    public class RegisterResponse
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}
