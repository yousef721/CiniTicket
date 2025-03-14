namespace CineTicket.Core.Entities;
public class Cinema
{
    public int Id { get; set;}
    public string Name { get; set;} = null!;
    public string Description { get; set;} = null!;
    public string Email { get; set;} = null!;
    public string PhoneNumber { get; set;} = null!;
    public string Country { get; set;} = null!;
    public string State { get; set;} = null!;
    public string City { get; set;} = null!;
    public string Street { get; set;} = null!;
    public DateTime ApprovedTime { get; set; } = DateTime.Now;
    public string CinemaLogo { get; set;} = "default-logo-cinema.jpg";
    public string Website { get; set;} = null!;
    public virtual List<ScheduleCinema> ScheduleCinemas { get; set; } = [];
    public virtual List<Hall> Halls { get; set; } = [];
    public virtual List<Movie> Movies { get; set;} = [];
    public virtual List<Ticket> Tickets { get; set; } = [];

    // Ignore computed properties
    public string FullAddress => $"{Country} {City} {State} {Street}";
}
