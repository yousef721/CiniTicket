using CineTicket.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CineTicket.Data.Data.Configurations;

public class ApplicationUserConfig : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.ToTable("ApplicationUsers");
        builder.Property(a => a.FirstName).HasMaxLength(50).IsRequired();
        builder.Property(a => a.LastName).HasMaxLength(50).IsRequired();
        builder.Property(a => a.DateOfBirth).HasColumnType("date");
        builder.Property(a => a.ProfilePicture).HasMaxLength(255).HasDefaultValue("default-profile-picture.jpg").IsRequired(false);
        builder.Property(a => a.Country).HasMaxLength(50).IsRequired(false);
        builder.Property(a => a.State).HasMaxLength(50).IsRequired(false);
        builder.Property(a => a.City).HasMaxLength(50).IsRequired(false);
        builder.Property(a => a.Street).HasMaxLength(100).IsRequired(false);
        builder.Property(a => a.IsActive).HasDefaultValue(true);
        builder.Property(a => a.LastLoginDate).HasDefaultValueSql("GETDATE()");
        builder.Property(a => a.CreatedAt).HasDefaultValueSql("GETDATE()");
        
        // Ignore computed properties
        builder.Ignore(a => a.FullName);
    }

}
