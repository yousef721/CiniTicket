using CineTicket.Core.Entities;
using CineTicket.Core.Interfaces.Repositories.SpecificRepositories;
using CineTicket.Data.Data;

namespace CineTicket.Data.Repositories.SpecificRepositories;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
