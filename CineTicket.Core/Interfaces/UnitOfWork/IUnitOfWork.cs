using CineTicket.Core.Interfaces.Repositories.SpecificRepositories;

namespace CineTicket.Core.Interfaces.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    public IActorRepository ActorRepository { get; }
    public ICategoryRepository CategoryRepository { get; }
    public ICinemaRepository CinemaRepository { get; }
    public IMovieRepository MovieRepository { get; }

    public int Commit();
}
