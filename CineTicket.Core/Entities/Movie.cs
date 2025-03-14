using CineTicket.Core.Enums;

namespace CineTicket.Core.Entities;
public class Movie
{
    public int Id { get; set;}
    public string Title { get; set;} = null!;
    public string Description { get; set;} = null!;
    public decimal Price { get; set;}
    public string ImgUrl { get; set;} = null!;
    public string TrailerVideo { get; set;} = "Trailer-Video";
    public decimal Rating { get; set;} = 2.0m;
    public DateTime StartDate { get; set;}
    public DateTime EndDate { get; set;}
    public MovieStatus MovieStatus { get; set; }
    public string MovieVideo { get; set;} = "Movie-Video";
    public int CategoryId { get; set; }
    public virtual Category Category { get; set; } = null!;
    public int CinemaId { get; set; }
    public virtual Cinema Cinema { get; set; } = null!;
    public virtual List<ScheduleCinema> ScheduleCinemas { get; set; } = [];
    public virtual List<MovieActor> MovieActors { get; set; } = [];
}
