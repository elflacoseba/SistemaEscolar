namespace SistemaEscolar.Application.Dtos.Institution.Response
{
    public class InstitutionResponseDto
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Website { get; set; }
        public string? AuditCreateUser { get; set; }
        public DateTime AuditCreateDate { get; set; }
        public int State { get; set; }
        public string? StateUser { get; set; }
    }
}