using CineTicket.Core.Entities;
using CineTicket.Core.Interfaces.ReposInterfaces;
using CineTicket.Data.Data;

namespace CineTicket.Data.Repositories.Implementations;

public class CinemaRepository : Repository<Cinema>, ICinemaRepository
{
    public CinemaRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
