namespace Persona.Persistence.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Persona.Domain.Entities;

    public class CategoryConfiguration : BaseConfiguration<Category>
    {
        public new void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(m => m.Id);

            builder
            .HasMany<ArticleCategory>(a => a.ArticleCategories)
            .WithOne(c => c.Category)
            .HasForeignKey(ac => ac.CategoryId);

            base.Configure(builder);
        }
    }
}
