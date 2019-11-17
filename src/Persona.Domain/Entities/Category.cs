namespace Persona.Domain.Entities
{
    using System.Collections.Generic;

    public class Category : BaseEntity
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Note { get; set; }
        public virtual ICollection<ArticleCategory> ArticleCategories { get; set; }
    }
}
