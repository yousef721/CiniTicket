using CineTicket.Core.Interfaces.ReposInterfaces;

namespace CineTicket.Core.Interfaces;

public interface IUnitOfWork : IDisposable
{
    public IActorRepository ActorRepository { get; }
    public ICategoryRepository CategoryRepository { get; }
    public ICinemaRepository CinemaRepository { get; }
    public IMovieRepository MovieRepository { get; }

    public int Commit();
}
