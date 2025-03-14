using CineTicket.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CineTicket.Data.Data.configurations;

public class ScheduleCinemaConfig : IEntityTypeConfiguration<ScheduleCinema>
{
    public void Configure(EntityTypeBuilder<ScheduleCinema> builder)
    {
        builder.ToTable("ScheduleCinemas");
        builder.HasKey(sc => sc.Id);
        builder.Property(sc => sc.StartTime).IsRequired();
        builder.Property(sc => sc.Duration).HasColumnType("time").IsRequired();
        builder.Property(sc => sc.EndTime).IsRequired();
        builder.Property(sc => sc.HallId).IsRequired();
        builder.Property(sc => sc.MovieId).IsRequired();
        builder.Property(sc => sc.CinemaId).IsRequired();

        // Computed column: EndTime = StartTime + Duration
        builder.Property(sc => sc.EndTime)
            .HasComputedColumnSql("DATEADD(SECOND, DATEDIFF(SECOND, '00:00:00', [Duration]), [StartTime])", stored: true);

        // Unique constraints {Prevent Schedule Conflicts}
        builder.HasIndex(sc => new { sc.StartTime, sc.HallId }).IsUnique();

        // Check constraints 
        builder.ToTable(tb => tb.HasCheckConstraint("CK_ScheduleCinema_Duration", "[Duration] > 0"));

        // Relationships
        builder.HasOne(sc => sc.Movie).WithMany(c => c.ScheduleCinemas).HasForeignKey(sc => sc.MovieId).HasConstraintName("FK_ScheduleCinema_MovieId").OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(sc => sc.Cinema).WithMany(c => c.ScheduleCinemas).HasForeignKey(sc => sc.CinemaId).HasConstraintName("FK_ScheduleCinema_CinemaId").OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(sc => sc.Hall).WithMany(c => c.ScheduleCinemas).HasForeignKey(sc => sc.HallId).HasConstraintName("FK_ScheduleCinema_HallId").OnDelete(DeleteBehavior.Cascade);
    }
}
