using Microsoft.AspNetCore.Identity;

namespace CineTicket.Core.Entities;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
    public string ProfilePicture { get; set; } = null!;
    public string Country { get; set; } = null!;
    public string State { get; set; } = null!;
    public string City { get; set; } = null!;
    public string Street { get; set; } = null!;
    public bool IsActive { get; set; } = true;
    public DateTime LastLoginDate { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    // Relationships
    public virtual ICollection<Ticket> Tickets { get; set; } = [];
    
    // Ignore computed properties
    public string? FullName => $"{FirstName} {LastName}";

}
