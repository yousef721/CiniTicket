using System.Linq.Expressions;
using CineTicket.Core.Interfaces.ReposInterfaces;
using CineTicket.Data.Data;
using Microsoft.EntityFrameworkCore;

namespace CineTicket.Data.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly ApplicationDbContext _dbContext;
    readonly DbSet<T> _dbSet;

    public Repository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<T>();
    }
    public void Create(T entity)
    {
        _dbSet.Add(entity);
        _dbContext.SaveChanges();
    }
    public void Update(T entity) 
    {
        _dbSet.Update(entity);
        _dbContext.SaveChanges();
    }
    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
        _dbContext.SaveChanges();
    }
    public IQueryable<T> Read(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IQueryable<T>>? include = null, bool tracked = true)
    {
        IQueryable<T> query = _dbSet;

        if (include != null)
        {
            query = include(query);
        }

        if (filter != null)
        {
            query = query.Where(filter);
        }
        
        if (!tracked)
        {
            query = query.AsNoTracking();
        }
    
        return query;
    }
    public T ReadOne(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IQueryable<T>>? include = null, bool tracked = true)
    {   
        return Read(filter, include, tracked).FirstOrDefault() ?? throw new Exception("Entity not found.");
    }
}
