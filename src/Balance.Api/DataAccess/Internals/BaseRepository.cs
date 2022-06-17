using System.Linq.Expressions;
using Balance.Api.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Balance.Api.DataAccess.Internals;

internal abstract class BaseRepository<T> : IBaseRepository<T> where T : class
{
    private readonly AppDbContext _context;

    protected DbSet<T> DbSet => _context.Set<T>();

    protected BaseRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task<T> Get(
        Expression<Func<T, bool>> predicate,
        CancellationToken token = default,
        params Expression<Func<T, object>>[] include)
    {
        return GetQuery(DbSet.Where(predicate).AsQueryable(), include).FirstOrDefaultAsync(cancellationToken: token);
    }

    public Task<T> GetRead(
        Expression<Func<T, bool>> predicate,
        CancellationToken token = default,
        params Expression<Func<T, object>>[] include)
    {
        return Get(predicate, e => e, token, include);
    }

    public Task<TK> Get<TK>(
        Expression<Func<T, bool>> predicate,
        Expression<Func<T, TK>> selector,
        CancellationToken token = default,
        params Expression<Func<T, object>>[] include)
    {
        return GetQuery(DbSet.AsNoTracking().Where(predicate).AsQueryable(), include)
            .Select(selector)
            .FirstOrDefaultAsync(cancellationToken: token);
    }

    public Task<List<T>> GetAll(
        Expression<Func<T, bool>> predicate,
        CancellationToken token = default,
        params Expression<Func<T, object>>[] include)
    {
        return GetAll(predicate, e => e, token, include);
    }

    public Task<List<TK>> GetAll<TK>(
        Expression<Func<T, bool>> predicate,
        Expression<Func<T, TK>> selector,
        CancellationToken token = default,
        params Expression<Func<T, object>>[] include)
    {
        return GetQuery(DbSet.Where(predicate).AsQueryable(), include)
            .Select(selector)
            .ToListAsync(cancellationToken: token);
    }

    public async Task<(int total, List<TK> list)> GetPaged<TK>(
        Expression<Func<T, bool>> predicate,
        Expression<Func<T, TK>> selector,
        int page,
        int count,
        CancellationToken token = default,
        params Expression<Func<T, object>>[] include)
    {
        var query = GetQuery(DbSet.Where(predicate).AsQueryable(), include);
        var total = await query.CountAsync(cancellationToken: token);
        var data = await query.Select(selector)
            .Skip(((page <= 0 ? 1 : page) - 1) * count)
            .Take(count)
            .ToListAsync(cancellationToken: token);

        return (total, data);
    }

    public async Task<T> Add(T entity, CancellationToken token = default)
    {
        await DbSet.AddAsync(entity, token);
        await _context.SaveChangesAsync(token);
        return entity;
    }

    public async Task<bool> Remove(T entity, CancellationToken token = default)
    {
        DbSet.Remove(entity);
        return await _context.SaveChangesAsync(token) > 0;
    }

    private IQueryable<T> GetQuery(IQueryable<T> query, Expression<Func<T, object>>[]? include)
    {
        if (include != null && include.Any())
            return include.Aggregate(query, (current, inc) => current.Include(inc));

        return query;
    }
}