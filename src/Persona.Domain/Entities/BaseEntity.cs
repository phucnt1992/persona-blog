namespace Persona.Domain.Entities
{
    using System;
    public abstract class BaseEntity<T>
    {
        public T Id { get; set; }
    }
}
