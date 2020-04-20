using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persona.IdentityServer.Models;

namespace Persona.IdentityServer.Persistence.Configurations
{
    internal class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(r => r.FirstName)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(r => r.LastName)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(r => r.AvatarUri)
                .HasMaxLength(255);
        }
    }
}
