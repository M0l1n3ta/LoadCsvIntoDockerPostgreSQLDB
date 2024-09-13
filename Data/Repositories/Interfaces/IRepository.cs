
namespace loadCsvIntoDockerPostgreSQLDB.Data.Repositories;
public interface IRepository<T>
    where T : Entity
{


    /// <summary>
    /// Adds an entity asynchronously to the domain.
    /// </summary>
    /// <param name="entity">The entity containing details to be created.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task AddAsync(T entity);

    /// <summary>
    /// Finds an entity asynchronously.
    /// </summary>
    /// <param name="id">The id of the entity to find.</param>
    /// <returns>A task representing the asynchronous operation. The result of the task contains the found entity.</returns>
    Task<T?> FindByIdAsync(int id);

    /// <summary>
    /// Deletes an entity.
    /// </summary>
    /// <param name="entity">The entity to delete.</param>
    void Delete(T entity);

    /// <summary>
    /// Updates an entity.
    /// </summary>
    /// <remarks>
    /// This operation replaces the whole entity and sets it as modified.
    /// </remarks>
    /// <param name="entity">The entity to update.</param>
    void Update(T entity);
}