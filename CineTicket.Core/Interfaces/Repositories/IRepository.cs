using System.Linq.Expressions;

namespace CineTicket.Core.Interfaces.Repositories;

public interface IRepository<T> where T : class
{
    public void Create(T entity);
    public void Update(T entity);
    public void Delete(T entity);
    public IQueryable<T> Read(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IQueryable<T>>? include = null,bool tracked = true);
    public T ReadOne(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IQueryable<T>>? include = null,bool tracked = true);
}
