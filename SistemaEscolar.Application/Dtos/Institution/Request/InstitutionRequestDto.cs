namespace SistemaEscolar.Application.Dtos.Institution.Request
{
    public class InstitutionRequestDto
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Website { get; set; }
        public int UserId { get; set; }
    }
}
