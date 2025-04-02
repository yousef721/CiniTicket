namespace CineTicket.Core.Entities;
public class ScheduleCinema
{
    public int Id { get; set; }
    public DateTime StartTime { get; set; }
    public int Duration { get; set; }

    // Relationships
    public int MovieId { get; set; }
    public virtual Movie Movie { get; set; } = null!;
    public int CinemaId { get; set; }
    public virtual Cinema Cinema { get; set; } = null!;
    public int HallId { get; set; }
    public virtual Hall Hall { get; set; } = null!;
    public virtual ICollection<Ticket> Tickets { get; set; } = [];

    // Ignore computed property
    public DateTime EndTime => StartTime.AddMinutes(Duration);
}
