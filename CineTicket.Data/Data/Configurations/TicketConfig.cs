using CineTicket.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CineTicket.Data.Data.Configurations;

public class TicketConfig : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.ToTable("Tickets");
        builder.HasKey(t => t.Id);
        
        builder.Property(t => t.AmountPaid).HasColumnType("money").IsRequired();
        builder.Property(t => t.PurchaseDate).HasDefaultValueSql("GETDATE()");
        builder.Property(t => t.SeatNumber).HasMaxLength(20).IsRequired();

        // Unique constraint {To prevent duplicate seats for the same screening}
        builder.HasIndex(t => new { t.ScheduleCinemaId, t.SeatNumber }).IsUnique();

        // Relationships
        builder.HasOne(t => t.ScheduleCinema).WithMany(sc => sc.Tickets).HasForeignKey(t => t.ScheduleCinemaId).HasConstraintName("FK_Ticket_ScheduleCinemaId").OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(t => t.ApplicationUser).WithMany(a => a.Tickets).HasForeignKey(t => t.ApplicationUserId).HasConstraintName("FK_Ticket_ApplicationUserId").OnDelete(DeleteBehavior.Cascade);
    }
}
