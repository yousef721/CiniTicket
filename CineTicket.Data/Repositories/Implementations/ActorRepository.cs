using CineTicket.Core.Entities;
using CineTicket.Core.Interfaces.Repositories.SpecificRepositories;
using CineTicket.Data.Data;

namespace CineTicket.Data.Repositories.Implementations;

public class ActorRepository : Repository<Actor>, IActorRepository
{
    public ActorRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
