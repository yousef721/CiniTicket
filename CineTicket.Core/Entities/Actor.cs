namespace CineTicket.Core.Entities;
public class Actor
{
    public int Id { get; set;}
    public string FirstName { get; set;} = null!;
    public string LastName { get; set;} = null!;
    public string Bio { get; set;} = null!;
    public string ProfilePicture { get; set;} = null!;
    public string News { get; set;} = null!;
    public virtual List<MovieActor> MovieActors { get; set; } = [];

    // Ignore computed property
    public string FullName => $"{FirstName} {LastName}";
}
