namespace Persona.Persistence.Configurations
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Persona.Domain.Entities;

    public abstract class BaseConfiguration<TBaseEntity> : IEntityTypeConfiguration<TBaseEntity>
    where TBaseEntity : BaseEntity
    {
        public void Configure(EntityTypeBuilder<TBaseEntity> builder)
        {
            builder.Property(r => r.Created)
                .IsRequired();

            builder.Property(r => r.Modified)
                .IsRequired(false);
        }
    }
}
