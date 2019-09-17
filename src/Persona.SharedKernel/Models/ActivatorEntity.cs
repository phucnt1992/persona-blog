namespace Persona.SharedKernel.Models
{
    using System;

    public enum ActivateStatus
    {
        Inactive = 0,
        Active = 1
    }
    public class ActivatorEntity : IEntity
    {
        public ActivateStatus Status { get; set; }
        public DateTime ActivateDate { get; set; }
        public DateTime DeactivateDate { get; set; }

    }
}
