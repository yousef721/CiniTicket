using CineTicket.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CineTicket.Data.Data.configurations;

public class HallConfig : IEntityTypeConfiguration<Hall>
{
    public void Configure(EntityTypeBuilder<Hall> builder)
    {
        builder.ToTable("Halls");
        builder.HasKey(h => h.Id);
        builder.Property(h => h.Name).HasMaxLength(50).IsRequired();
        builder.Property(h => h.TotalRows).HasColumnType("SMALLINT").IsRequired();
        builder.Property(h => h.TotalSeatsPerRow).HasColumnType("SMALLINT").IsRequired();

        // Unique constraints
        builder.HasIndex(h => new { h.Name, h.CinemaId }).IsUnique();

        // Valid count
        builder.ToTable(tb => tb.HasCheckConstraint("CK_Hall_TotalRows", "[TotalRows] BETWEEN 1 AND 50"));
        builder.ToTable(tb => tb.HasCheckConstraint("CK_Hall_TotalSeatsPerRow", "[TotalSeatsPerRow] BETWEEN 1 AND 500"));

        // Relationships
        builder.HasOne(h => h.Cinema).WithMany(c => c.Halls).HasForeignKey(h => h.CinemaId).HasConstraintName("FK_Hall_CinemaId").OnDelete(DeleteBehavior.Cascade);

        // Ignore computed properties
        builder.Ignore(h => h.TotalSeats); 
    }
}
