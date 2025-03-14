using CineTicket.Core.Entities;
using CineTicket.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CineTicket.Data.Data.configurations;

public class RequestCinemaConfig : IEntityTypeConfiguration<RequestCinema> 
{
    public void Configure(EntityTypeBuilder<RequestCinema> builder)
    {
        builder.ToTable("RequestsCinemas");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
        builder.Property(c => c.Description).HasColumnType("nvarchar(max)").IsRequired();
        builder.Property(c => c.ExplainAccept).HasColumnType("nvarchar(max)").IsRequired(false);
        builder.Property(c => c.Email).HasMaxLength(255).IsRequired();
        builder.Property(c => c.PhoneNumber).HasMaxLength(15).IsRequired();
        builder.Property(c => c.Country).HasMaxLength(100).IsRequired();
        builder.Property(c => c.State).HasMaxLength(100).IsRequired();
        builder.Property(c => c.City).HasMaxLength(100).IsRequired();
        builder.Property(c => c.Street).HasMaxLength(100).IsRequired();
        builder.Property(c => c.Website).HasMaxLength(1024).IsRequired(false);
        builder.Property(c => c.Status).HasConversion<int>().HasDefaultValue(ApprovalStatus.Pending);
        builder.Property(c => c.RequestDate).HasDefaultValueSql("GETDATE()");

        // Ignore computed property
        builder.Ignore(c => c.FullAddress);

        // Unique constraints
        builder.HasIndex(c => c.Email).IsUnique();
        builder.HasIndex(c => c.PhoneNumber).IsUnique();
        builder.HasIndex(c => c.Name).IsUnique();
    }
}
