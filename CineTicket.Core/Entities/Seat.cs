namespace CineTicket.Core.Entities;
public class Seat
{
    public int Id { get; set; }
    public short Row { get; set; } 
    public short SeatNumber { get; set; } 
    public bool IsBooked { get; set; } = false; // Default: available
    public int HallId { get; set; }
    public virtual Hall Hall { get; set; } = null!;

    // Ignore computed properties
    public string Location => $"Row {Row}, Seat {SeatNumber}";
}
