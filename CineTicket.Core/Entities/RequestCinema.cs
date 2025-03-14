using CineTicket.Core.Enums;

namespace CineTicket.Core.Entities;
public class RequestCinema
{
    public int Id { get; set;}
    public string Name { get; set;} = null!;
    public string Description { get; set;} = null!;
    public string ExplainAccept { get; set;} = null!;
    public string Email { get; set;} = null!;
    public string PhoneNumber { get; set;} = null!;
    public string Country { get; set;} = null!;
    public string State { get; set;} = null!;
    public string City { get; set;} = null!;
    public string Street { get; set;} = null!;
    public string Website { get; set;} = null!;
    public ApprovalStatus Status { get; set; } = ApprovalStatus.Pending;
    public DateTime RequestDate { get; set; } = DateTime.Now;

    // Ignore computed property
    public string FullAddress => $"{Country} {City} {State} {Street}";
}
