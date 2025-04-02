namespace CineTicket.Core.Entities;
public class Ticket
{
    public int Id { get; set; }
    public decimal AmountPaid { get; set; }
    public DateTime PurchaseDate { get; set; } = DateTime.Now;
    public string SeatNumber { get; set; } = null!;

    // Relationships
    public string ApplicationUserId { get; set; } = null!;
    public virtual ApplicationUser ApplicationUser { get; set; } = null!;
    public int ScheduleCinemaId { get; set; }
    public virtual ScheduleCinema ScheduleCinema { get; set; } = null!;
}
