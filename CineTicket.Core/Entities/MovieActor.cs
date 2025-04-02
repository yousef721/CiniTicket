namespace CineTicket.Core.Entities;
public class MovieActor
{
    public int MovieId { get; set;}
    public int ActorId { get; set;}
    public virtual Movie Movie { get; set;} = null!;
    public virtual Actor Actor { get; set;} = null!;
}
