namespace Persona.Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public class Article : BaseEntity<long>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Slug { get; set; }
        public virtual ICollection<ArticleCategory> ArticleCategories { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

    }
}
