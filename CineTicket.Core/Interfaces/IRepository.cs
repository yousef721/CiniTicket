using System.Linq.Expressions;

namespace CineTicket.Core.Interfaces;

public interface IRepository<T> where T : class
{
    public void Add(T entity);
    public void Alter(T entity);
    public void Delete(T entity);
    public IQueryable<T> Get(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IQueryable<T>>? include = null,bool tracked = true);
    public T GetOne(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IQueryable<T>>? include = null,bool tracked = true);
}
