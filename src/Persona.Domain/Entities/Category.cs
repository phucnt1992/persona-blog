namespace Persona.Domain.Entities
{
    using System.Collections.Generic;

    public class Category : BaseEntity<int>
    {
        public string Title { get; set; }
        public string Note { get; set; }
        public virtual ICollection<ArticleCategory> ArticleCategories { get; set; }
    }
}
