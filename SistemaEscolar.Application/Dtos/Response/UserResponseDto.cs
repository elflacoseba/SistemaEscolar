namespace SistemaEscolar.Application.Dtos.Response
{
    public class UserResponseDto
    {
        public int  Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Image { get; set; }
        public string? AuditCreateUser { get; set; }
        public DateTime AuditCreateDate { get; set; }
        public int State { get; set; }
        public string? StateUser { get; set; }
    }
}
