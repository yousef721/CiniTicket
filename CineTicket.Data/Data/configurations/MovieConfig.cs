using CineTicket.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CineTicket.Data.Data.configurations;

public class MovieConfig : IEntityTypeConfiguration<Movie> 
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.ToTable("Movies");
        builder.HasKey(m => m.Id);
        builder.Property(m => m.Title).HasMaxLength(100).IsRequired();
        builder.Property(m => m.Description).HasColumnType("nvarchar(max)").IsRequired();
        builder.Property(m => m.Price).HasColumnType("money").IsRequired();
        builder.Property(m => m.ImgUrl).HasMaxLength(255).HasDefaultValue("default-movie.jpg").IsRequired(false);
        builder.Property(m => m.TrailerVideo).HasMaxLength(255).HasDefaultValue("Trailer-Video").IsRequired(false);
        builder.Property(m => m.Rating).HasColumnType("decimal(3,1)").HasDefaultValue(2.0m);
        builder.Property(m => m.MovieVideo).HasMaxLength(255).HasDefaultValue("Movie-Video").IsRequired(false);;
        builder.Property(m => m.StartDate).HasDefaultValueSql("GETDATE()");
        builder.Property(m => m.EndDate).HasDefaultValueSql("DATEADD(DAY, 90, GETDATE())");

        
        // Computed property
        builder.Property(m => m.MovieStatus).HasColumnType("TINYINT")
        .HasComputedColumnSql(@"
        CASE 
            WHEN GETDATE() < StartDate THEN 0  -- Upcoming
            WHEN GETDATE() BETWEEN StartDate AND EndDate THEN 1  -- Available
            ELSE 2  -- Expired
        END", stored: true)
        .HasConversion<int>();

        // Relationships
        builder.HasOne(m => m.Category).WithMany(c => c.Movies).HasForeignKey(m => m.CategoryId).HasConstraintName("FK_Movies_CategoryId").OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(m => m.Cinema).WithMany(c => c.Movies).HasForeignKey(m => m.CinemaId).HasConstraintName("FK_Movies_CinemaId").OnDelete(DeleteBehavior.Restrict);
    }
}
