namespace Persona.Persistence.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Persona.Domain.Entities;

    public class CommentConfiguration : BaseConfiguration<Comment>
    {
        public new void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(m => m.Id);

            builder
            .HasOne<Article>(c => c.Article)
            .WithMany(c => c.Comments)
            .HasForeignKey(c => c.ArticleId);

            builder
            .HasOne<User>(c => c.Commenter)
            .WithMany(u => u.Comments)
            .HasForeignKey(c => c.CommenterId);

            base.Configure(builder);
        }
    }
}
