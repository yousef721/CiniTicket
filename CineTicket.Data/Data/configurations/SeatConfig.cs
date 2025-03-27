using CineTicket.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CineTicket.Data.Data.Configurations;

public class SeatConfig : IEntityTypeConfiguration<Seat>
{
    public void Configure(EntityTypeBuilder<Seat> builder)
    {
        builder.ToTable("Seats");
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Row).HasColumnType("SMALLINT").IsRequired();
        builder.Property(s => s.SeatNumber).HasColumnType("SMALLINT").IsRequired();
        builder.Property(s => s.IsBooked).HasDefaultValue(false);

        // Unique constraints
        builder.HasIndex(s => new {s.Row, s.SeatNumber, s.HallId}).IsUnique();

        // Valid count
        builder.ToTable(tb => tb.HasCheckConstraint("CK_Seat_Row", "[Row] BETWEEN 1 AND 100"));
        builder.ToTable(tb => tb.HasCheckConstraint("CK_Seat_SeatNumber", "[SeatNumber] BETWEEN 1 AND 500"));

        // Relationships
        builder.HasOne(s => s.Hall).WithMany(h => h.Seats).HasForeignKey(s => s.HallId).HasConstraintName("FK_Seat_HallId").OnDelete(DeleteBehavior.Cascade);

        // Ignore computed properties
        builder.Ignore(s => s.Location);
    }
}
