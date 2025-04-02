using CineTicket.Core.Entities;
using CineTicket.Core.Interfaces.ReposInterfaces;
using CineTicket.Data.Data;

namespace CineTicket.Data.Repositories.Implementations;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
