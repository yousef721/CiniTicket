namespace CineTicket.Core.Entities;
public class Hall
{
    public int Id { get; set; }
    public string Name { get; set; } = null!; // Example: "IMAX 1", "Hall A"
    public short TotalRows { get; set; }
    public short TotalSeatsPerRow { get; set; }
    public int CinemaId { get; set; }
    public virtual Cinema Cinema { get; set; } = null!;
    public virtual List<Seat> Seats { get; set; } = [];
    public virtual List<ScheduleCinema> ScheduleCinemas { get; set; } = [];

    // Ignore Computed property
    public int TotalSeats => TotalRows * TotalSeatsPerRow;
}
