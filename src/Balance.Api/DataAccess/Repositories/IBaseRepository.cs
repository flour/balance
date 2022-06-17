using System.Linq.Expressions;

namespace Balance.Api.DataAccess.Repositories;

public interface IBaseRepository<T> where T : class
{
    Task<T> Get(
        Expression<Func<T, bool>> predicate,
        CancellationToken token = default,
        params Expression<Func<T, object>>[] include);

    Task<T> GetRead(
        Expression<Func<T, bool>> predicate,
        CancellationToken token = default,
        params Expression<Func<T, object>>[] include);

    Task<TK> Get<TK>(
        Expression<Func<T, bool>> predicate,
        Expression<Func<T, TK>> selector,
        CancellationToken token = default,
        params Expression<Func<T, object>>[] include);

    Task<List<T>> GetAll(
        Expression<Func<T, bool>> predicate, 
        CancellationToken token = default,
        params Expression<Func<T, object>>[] include);
    
    Task<List<TK>> GetAll<TK>(
        Expression<Func<T, bool>> predicate, 
        Expression<Func<T, TK>> selector,
        CancellationToken token = default,
        params Expression<Func<T, object>>[] include);

    Task<(int total, List<TK> list)> GetPaged<TK>(
        Expression<Func<T, bool>> predicate,
        Expression<Func<T, TK>> selector,
        int page,
        int count,
        CancellationToken token = default,
        params Expression<Func<T, object>>[] include);
    
    Task<T> Add(T entity, CancellationToken token = default);
    
    Task<bool> Remove(T entity, CancellationToken token = default);
}