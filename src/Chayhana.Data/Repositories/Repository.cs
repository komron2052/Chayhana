using Chayhana.Data.DbContexts;
using Chayhana.Data.IRepositories;
using Chayhana.Domain.Commons;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Chayhana.Data.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Auditable
{
    private readonly ChayhanaDbContext dbContext;
    private readonly DbSet<TEntity> dbSet;
    public Repository(ChayhanaDbContext dbContext, DbSet<TEntity> dbSet)
    {
        this.dbContext = dbContext;
        this.dbSet = dbContext.Set<TEntity>();
    }

    public async ValueTask<bool> DeleteAsync(Expression<Func<TEntity, bool>> predicate)
    {
        var entity = await this.dbSet.FirstOrDefaultAsync(predicate);
        if (entity == null)
            return false;

        this.dbSet.Remove(entity);
        
        return true;
    }

    public async ValueTask<TEntity> InsertAsync(TEntity entity)
    {
        var entry = await this.dbSet.AddAsync(entity);

        return entry.Entity;
    }

    public async ValueTask SaveAsync() =>
        this.dbContext.SaveChanges();

    public IQueryable<TEntity> SelectAll(Expression<Func<TEntity, bool>> predicate = null, string[] includes = null, bool isTracking = true)
    {
        var entities = predicate is null ? dbSet : dbSet.Where(predicate);

        if(includes is not null)
            foreach(var include in includes)
                entities= entities.Include(include);    

        if (!isTracking)
            entities=entities.AsNoTracking();

        return entities;
    }

    public async ValueTask<TEntity> SelectAsync(Expression<Func<TEntity, bool>> predicate, string[] includes = null) =>
        await SelectAll(predicate, includes).FirstOrDefaultAsync();

    public TEntity Update(TEntity entity)
    {
        var entry = this.dbSet.Update(entity);

        return entry.Entity;    
    }
}
