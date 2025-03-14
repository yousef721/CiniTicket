using CineTicket.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CineTicket.Data.Data.configurations;

public class TicketConfig : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.ToTable("Tickets");
        builder.HasKey(t => t.Id);
        
        builder.Property(t => t.AmountPaid).HasColumnType("money").IsRequired();
        builder.Property(t => t.PurchaseDate).HasDefaultValueSql("GETDATE()");

        // Unique constraint {To prevent duplicate seats for the same screening}
        builder.HasIndex(t => new { t.ScheduleCinemaId, t.SeatNumber }).IsUnique();

        // Relationships
        builder.HasOne(t => t.ScheduleCinema).WithMany().HasForeignKey(t => t.ScheduleCinemaId).HasConstraintName("FK_Ticket_ScheduleCinemaId").OnDelete(DeleteBehavior.Cascade);
    }
}
