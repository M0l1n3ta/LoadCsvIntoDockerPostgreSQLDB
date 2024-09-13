using Microsoft.EntityFrameworkCore;
using loadCsvIntoDockerPostgreSQLDB.DbContexts;

namespace loadCsvIntoDockerPostgreSQLDB.Data.Repositories;
/// <summary>
/// Abstract base class for repositories handling entities of type T.
/// </summary>
/// <typeparam name="T">The type of entity handled by the repository.</typeparam>
/// <param name="dbContext">The dbContext instance.</param>
public abstract class Repository<T>(DatabaseDBContext dbContext): IRepository<T>
    where T : Entity
{
  
    public async Task AddAsync(T entity)
    {
        await dbContext.Set<T>().AddAsync(entity);
    }


    public virtual async Task<T?> FindByIdAsync(int id)
    {
        return await dbContext.Set<T>().FindAsync(id);
    }

    /// <inheritdoc/>
    public void Delete(T entity)
    {
        dbContext.Set<T>().Remove(entity);
    }

    /// <inheritdoc/>
    public void Update(T entity)
    {
        dbContext.Entry(entity).State = EntityState.Modified;
    }

    
}