znamespace Persona.Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public class User : BaseEntity<Guid>
    {
        public bool IsAdmin { get; set; }
        public bool IsStaff { get; set; }
        public DateTime LastLogined { get; set; }
        public virtual ICollection<Article> CreatedArticles { get; set; }
        public virtual ICollection<Article> ModifiedArticles { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
