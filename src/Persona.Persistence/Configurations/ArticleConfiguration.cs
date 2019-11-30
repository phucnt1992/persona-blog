namespace Persona.Persistence.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Persona.Domain.Entities;

    public class ArticleConfiguration : BaseConfiguration<Article>
    {
        public new void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(m => m.Id);

            builder
            .HasMany<Comment>(a => a.Comments)
            .WithOne(c => c.Article)
            .HasForeignKey(c => c.ArticleId);

            builder
            .HasMany<ArticleCategory>(a => a.ArticleCategories)
            .WithOne(ac => ac.Article)
            .HasForeignKey(ac => ac.ArticleId);

            base.Configure(builder);
        }
    }
}
