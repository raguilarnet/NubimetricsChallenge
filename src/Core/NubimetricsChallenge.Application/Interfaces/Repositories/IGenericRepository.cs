using System.Linq.Expressions;

namespace NubimetricsChallenge.Application.Interfaces.Repositories;

public interface IGenericRepository<T>
        where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task<int> CountAsync(Expression<Func<T, bool>>? filter = null);
    Task InsertAsync(T entityToInsert);
    void Update(T entityToUpdate);
    void Delete(T entityToDelete);
    Task Delete(object id);
    void DeAttach(T entity);
}
