using CineTicket.Data.Data.configurations;
using Microsoft.EntityFrameworkCore;

namespace CineTicket.Data.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options){}
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RequestCinemaConfig).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CinemaConfig).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CategoryConfig).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MovieConfig).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ActorConfig).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MovieActorConfig).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(HallConfig).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SeatConfig).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ScheduleCinemaConfig).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TicketConfig).Assembly);
    }
}
