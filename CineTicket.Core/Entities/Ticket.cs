namespace CineTicket.Core.Entities;
public class Ticket
{
    public int Id { get; set; }
    public decimal AmountPaid { get; set; }
    public DateTime PurchaseDate { get; set; } = DateTime.Now;
    public string SeatNumber { get; set; } = null!;
    public int ApplicationUserId { get; set; }
    public virtual ApplicationUser ApplicationUser { get; set; } = null!;
    public int ScheduleCinemaId { get; set; }
    public virtual ScheduleCinema ScheduleCinema { get; set; } = null!;
}
