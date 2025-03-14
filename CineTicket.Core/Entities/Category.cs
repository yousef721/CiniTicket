namespace CineTicket.Core.Entities;
public class Category
{
    public int Id { get; set;}
    public string Name { get; set;} = null!;
    public virtual List<Movie> Movies { get; set; } = [];
}
