namespace SistemaEscolar.Domain.Entities
{
    public class InstitutionEducationalLevel
    {
        public int InstitutionId { get; set; }

        public virtual Institution? Institution { get; set; }

        public int EducationalLevelId { get; set; }

        public virtual EducationalLevel? EducationalLevel { get; set; }
    }
}
