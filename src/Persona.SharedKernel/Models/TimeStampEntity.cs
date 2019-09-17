namespace Persona.SharedKernel.Models
{
    using System;

    public abstract class TimeStampEntity : IEntity
    {
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
