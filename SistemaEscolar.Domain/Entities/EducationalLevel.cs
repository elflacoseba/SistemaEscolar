namespace SistemaEscolar.Domain.Entities
{
    public class EducationalLevel :BaseEntity
    {
        public EducationalLevel()
        {
            Institutions = new HashSet<Institution>();
        }        

        public string? Name { get; set; }

        public virtual ICollection<Institution> Institutions { get; set; }

    }
}