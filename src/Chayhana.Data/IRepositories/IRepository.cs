using Chayhana.Domain.Commons;
using System.Linq.Expressions;

namespace Chayhana.Data.IRepositories;

public interface IRepository<TEntity> where TEntity : Auditable
{
    ValueTask<TEntity> InsertAsync(TEntity entity);
    TEntity Update(TEntity entity);
    ValueTask<bool> DeleteAsync(Expression<Func<TEntity, bool>> predicate);
    ValueTask<TEntity> SelectAsync(Expression<Func<TEntity, bool>> predicate, string[] includes = null);
    IQueryable<TEntity> SelectAll(Expression<Func<TEntity, bool>> predicate = null, string[] includes = null, bool isTracking = true);
    ValueTask SaveAsync();
}
