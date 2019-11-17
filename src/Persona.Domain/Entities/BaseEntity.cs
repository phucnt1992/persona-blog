namespace Persona.Domain.Entities
{
    using System;

    public abstract class BaseEntity
    {
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
