using CineTicket.Core.Entities;
using CineTicket.Data.Data.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CineTicket.Data.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options){}
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ActorConfig).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationUserConfig).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CategoryConfig).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CinemaConfig).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(HallConfig).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MovieActorConfig).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MovieConfig).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RequestCinemaConfig).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ScheduleCinemaConfig).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SeatConfig).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TicketConfig).Assembly);
    }
}
