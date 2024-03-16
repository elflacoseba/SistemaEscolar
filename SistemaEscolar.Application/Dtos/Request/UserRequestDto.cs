namespace SistemaEscolar.Application.Dtos.Request
{
    public class UserRequestDto
    {
        public string? UserName { get; set; }

        public string? PasswordHash { get; set; }

        public string? Email { get; set; }

        public string? Image { get; set; }
    }
}
