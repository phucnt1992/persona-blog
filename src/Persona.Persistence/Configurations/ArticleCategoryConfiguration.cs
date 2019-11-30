namespace Persona.Persistence.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Persona.Domain.Entities;

    public class ArticleCategoryConfiguration : IEntityTypeConfiguration<ArticleCategory>
    {
        public void Configure(EntityTypeBuilder<ArticleCategory> builder)
        {
            builder.HasKey(ac => new { ac.ArticleId, ac.CategoryId });

            builder
            .HasOne<Article>(ac => ac.Article)
            .WithMany(a => a.ArticleCategories)
            .HasForeignKey(ac => ac.ArticleId);

            builder
            .HasOne<Category>(ac => ac.Category)
            .WithMany(c => c.ArticleCategories)
            .HasForeignKey(ac => ac.CategoryId);
        }
    }
}
