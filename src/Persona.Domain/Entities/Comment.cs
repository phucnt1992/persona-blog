namespace Persona.Domain.Entities
{
    public class Comment : BaseEntity<long>
    {
        public string Content { get; set; }
        public long ReplyToId { get; set; }
        public string CommenterId { get; set; }
        public uint Level { get; set; }
        public long ArticleId { get; set; }
        public virtual User Commenter { get; set; }
        public virtual Article Article { get; set; }
        public virtual Comment ReplyTo { get; set; }

    }
}
