namespace Persona.Persistence.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Persona.Domain.Entities;

    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(m => m.Id);

            builder
            .HasMany(a => a.Comments)
            .WithOne(c => c.Article)
            .HasForeignKey(c => c.ArticleId);

            builder
            .HasMany(a => a.ArticleCategories)
            .WithOne(ac => ac.Article)
            .HasForeignKey(ac => ac.ArticleId);

            builder
            .HasOne(a => a.CreatedBy)
            .WithMany(u => u.CreatedArticles)
            .HasForeignKey(a => a.CreatedById);

            builder
            .HasOne(a => a.ModifiedBy)
            .WithMany(u => u.ModifiedArticles)
            .HasForeignKey(a => a.ModifiedById);
        }
    }
}
