

using System.Runtime.CompilerServices;

namespace loadCsvIntoDockerPostgreSQLDB.Data.Repositories;
public abstract class Entity
{
    /// <summary>
    /// Gets or sets the unique identifier of the entity.
    /// </summary>
    public virtual int Id { get; set; }

    /// <summary>
    /// Determines whether the entity is transient (i.e., has not been persisted).
    /// </summary>
    /// <returns>True if the entity is transient; otherwise, false.</returns>
    public bool IsTransient() => this.Id == default;

    /// <summary>
    /// Determines whether the current entity is equal to another entity.
    /// </summary>
    /// <param name="obj">The object to compare with the current entity.</param>
    /// <returns>True if the current entity is equal to the other object; otherwise, false.</returns>
    public override bool Equals(object? obj)
    {
        if (obj == null!)
        {
            return false;
        }

        if (obj is not Entity)
        {
            return false;
        }

        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        if (!GetType().Equals(obj.GetType()))
        {
            return false;
        }

        Entity item = (Entity)obj;

        if (IsTransient() || item.IsTransient())
        {
            return false;
        }

        return item.Id == this.Id;
    }

    /// <summary>
    /// Serves as the default hash function.
    /// </summary>
    /// <returns>A hash code for the current entity.</returns>
    public override int GetHashCode()
    {
        if (!IsTransient())
        {
            return this.Id.GetHashCode() ^ 31;
        }
        else
        {
            return RuntimeHelpers.GetHashCode(this);
        }
    }

    /// <summary>
    /// Determines whether two entities are equal.
    /// </summary>
    /// <param name="left">The first entity to compare.</param>
    /// <param name="right">The second entity to compare.</param>
    /// <returns>True if the entities are equal; otherwise, false.</returns>
    public static bool operator ==(Entity left, Entity right)
    {
        return Equals(left, null) ? Equals(right, null) : left.Equals(right);
    }

    /// <summary>
    /// Determines whether two entities are not equal.
    /// </summary>
    /// <param name="left">The first entity to compare.</param>
    /// <param name="right">The second entity to compare.</param>
    /// <returns>True if the entities are not equal; otherwise, false.</returns>
    public static bool operator !=(Entity left, Entity right)
    {
        return !(left == right);
    }
}