namespace Persona.Domain.Entities
{
    using System;
    public class User
    {
        public bool IsAdmin { get; set; }
        public bool IsStaff { get; set; }
        public DateTime LastLogined { get; set; }
    }
}
