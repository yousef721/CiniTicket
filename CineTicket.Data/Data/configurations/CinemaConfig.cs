using CineTicket.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CineTicket.Data.Data.Configurations;

public class CinemaConfig : IEntityTypeConfiguration<Cinema>
{
    public void Configure(EntityTypeBuilder<Cinema> builder)
    {
        builder.ToTable("Cinemas");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
        builder.Property(c => c.Description).HasColumnType("nvarchar(max)").IsRequired();
        builder.Property(c => c.Email).HasMaxLength(150).IsRequired();
        builder.Property(c => c.PhoneNumber).HasMaxLength(20).IsRequired();
        builder.Property(c => c.Country).HasMaxLength(50).IsRequired();
        builder.Property(c => c.State).HasMaxLength(50).IsRequired();
        builder.Property(c => c.City).HasMaxLength(50).IsRequired();
        builder.Property(c => c.Street).HasMaxLength(100).IsRequired();
        builder.Property(c => c.CinemaLogo).HasMaxLength(255).HasDefaultValue("default-logo-cinema.jpg").IsRequired(false);
        builder.Property(c => c.Website).HasMaxLength(255).IsRequired(false);

        // Unique constraints
        builder.HasIndex(c => c.Email).IsUnique();
        builder.HasIndex(c => c.PhoneNumber).IsUnique();
        builder.HasIndex(c => c.Name).IsUnique();

        // Ignore computed properties
        builder.Ignore(c => c.FullAddress);
    }
}
