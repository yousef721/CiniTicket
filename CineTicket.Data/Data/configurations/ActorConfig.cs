using CineTicket.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CineTicket.Data.Data.configurations;

public class ActorConfig : IEntityTypeConfiguration<Actor> 
{
    public void Configure(EntityTypeBuilder<Actor> builder)
    {
        builder.ToTable("Actors");
        builder.HasKey(a => a.Id);
        builder.Property(a => a.FirstName).HasMaxLength(50).IsRequired();
        builder.Property(a => a.LastName).HasMaxLength(50).IsRequired();
        builder.Property(a => a.Bio).HasColumnType("nvarchar(max)").IsRequired();
        builder.Property(a => a.ProfilePicture).HasMaxLength(255).HasDefaultValue("default-actor.jpg").IsRequired(false);
        builder.Property(a => a.News).HasMaxLength(1000).HasDefaultValue("No news available").IsRequired(false);   

        // Ignore computed properties
        builder.Ignore(a => a.FullName);
    }
}