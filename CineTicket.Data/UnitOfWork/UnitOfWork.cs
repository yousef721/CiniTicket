using CineTicket.Core.Interfaces;
using CineTicket.Core.Interfaces.ReposInterfaces;
using CineTicket.Data.Data;
using CineTicket.Data.Repositories.Implementations;

namespace CineTicket.Data.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public IActorRepository ActorRepository { get; private set; }

    public ICategoryRepository CategoryRepository { get; private set; }

    public ICinemaRepository CinemaRepository { get; private set; }

    public IMovieRepository MovieRepository { get; private set; }

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        ActorRepository = new ActorRepository(_context);
        CategoryRepository = new CategoryRepository(_context);
        MovieRepository = new MovieRepository(_context);
        CinemaRepository = new CinemaRepository(_context);
    }

    public int Commit()
    {
       return _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
