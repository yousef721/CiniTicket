namespace CineTicket.Core.Entities;
public class Ticket
{
    public int Id { get; set; }
    public decimal AmountPaid { get; set; }
    public DateTime PurchaseDate { get; set; } = DateTime.Now;
    public string SeatNumber { get; set; } = null!;
    // public int? UserId { get; set; }
    // public User? User { get; set; }
    public int ScheduleCinemaId { get; set; }
    public virtual ScheduleCinema ScheduleCinema { get; set; } = null!;
}
