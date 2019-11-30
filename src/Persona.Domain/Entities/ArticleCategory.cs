namespace Persona.Domain.Entities
{
    public class ArticleCategory
    {
        public long ArticleId { get; set; }
        public virtual Article Article { get; set; }
        public long CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
