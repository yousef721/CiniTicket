using CineTicket.Core.Entities;
using CineTicket.Core.Interfaces.Repositories.SpecificRepositories;
using CineTicket.Data.Data;

namespace CineTicket.Data.Repositories.Implementations;

public class MovieRepository : Repository<Movie>, IMovieRepository
{
    public MovieRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
