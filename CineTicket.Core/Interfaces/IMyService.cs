
using CineTicket.Core.Entities;

namespace CineTicket.Core.Interfaces;

public interface IMyService
{
    public void MoviesStatus(List<Movie> movies = null!, Movie movie = null!);
}
