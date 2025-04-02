using CineTicket.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CineTicket.Data.Data.Configurations;

public class MovieActorConfig : IEntityTypeConfiguration<MovieActor>
{
    public void Configure(EntityTypeBuilder<MovieActor> builder)
    {
            builder.ToTable("MovieActors");
            builder.HasKey(ma => new { ma.MovieId, ma.ActorId });
            builder.HasOne(ma => ma.Movie).WithMany(m => m.MovieActors).HasForeignKey(ma => ma.MovieId).HasConstraintName("FK_MovieActor_MovieId").OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(ma => ma.Actor).WithMany(a => a.MovieActors).HasForeignKey(ma => ma.ActorId).HasConstraintName("FK_MovieActor_ActorId").OnDelete(DeleteBehavior.Cascade);
    }
}
