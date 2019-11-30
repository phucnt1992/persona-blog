namespace Persona.Domain.Entities
{
    public class Role : BaseEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsActivate { get; set; }
    }
}
