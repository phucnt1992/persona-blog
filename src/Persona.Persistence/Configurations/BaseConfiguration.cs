namespace Persona.Persistence.Configurations
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Persona.Domain.Entities.Base;

    public abstract class BaseCategoryConfiguration : IEntityTypeConfiguration<IEntity>
    {
        public void Configure(EntityTypeBuilder<IEntity> builder)
        {
            builder.Property(r => r.Created)
                .IsRequired();

            builder.Property(r => r.Modified)
                .IsRequired(false);
        }
    }
}
