using Microsoft.EntityFrameworkCore;
using NubimetricsChallenge.Application.Interfaces.Repositories;
using System.Linq.Expressions;

namespace NubimetricsChallenge.Infrastructure.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected internal readonly DbContext _context;
    protected internal readonly DbSet<T> _dbSet;

    public GenericRepository(DbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.Set<T>().AsNoTracking<T>().ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        var entity = await _context.Set<T>().FindAsync(id);
        if (entity != null)
        {
            _context.Entry(entity).State = EntityState.Detached;
        }
        return entity;
    }
    
    public async Task<int> CountAsync(Expression<Func<T, bool>>? filter = null)
    {
        IQueryable<T> query = _dbSet;

        if (filter != null)
            query = query.Where(filter);

        return await query.CountAsync();
    }

    public async Task InsertAsync(T entityToInsert)
    {
        await _context.Set<T>().AddAsync(entityToInsert);
    }

    public void Update(T entityToUpdate)
    {
        _context.Attach(entityToUpdate).State = EntityState.Modified;
    }

    public void Delete(T entityToDelete)
    {
        _context.Set<T>().Remove(entityToDelete);
    }

    public async Task Delete(object id)
    {
        var entityToDelete = await _context.Set<T>().FindAsync(id);
        if (entityToDelete != null)
        {
            _context.Set<T>().Remove(entityToDelete);
        }

    }

    public void DeAttach(T entity)
    {
        _context.Attach(entity).State = EntityState.Detached;
    }

}
