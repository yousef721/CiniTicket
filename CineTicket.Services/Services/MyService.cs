using CineTicket.Core.Entities;
using CineTicket.Core.Enums;
using CineTicket.Core.Interfaces;

namespace CineTicket.Services.Services;

public class MyService : IMyService
{
    public void MoviesStatus(List<Movie> movies = null!, Movie movie = null!)
    {
        if (movies == null)
        {
            if (movie.StartDate > DateTime.Now)
            {
                movie.MovieStatus = MovieStatus.Upcoming;
            } else if (movie.EndDate < DateTime.Now)
            {
                movie.MovieStatus = MovieStatus.Expired;
            } else
            {
                movie.MovieStatus = MovieStatus.Available;
            }
        } else {
            foreach (var item in movies)
            {
                if (item.StartDate > DateTime.Now)
                {
                    item.MovieStatus = MovieStatus.Upcoming;
                } else if (item.EndDate < DateTime.Now)
                {
                    item.MovieStatus = MovieStatus.Expired;
                } else
                {
                    item.MovieStatus = MovieStatus.Available;
                }
            }
        }
    }
}
