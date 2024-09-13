using Microsoft.EntityFrameworkCore;
using loadCsvIntoDockerPostgreSQLDB.Entities;

namespace loadCsvIntoDockerPostgreSQLDB.DbContexts;

public class DatabaseDBContext : DbContext,IDatabaseDBContext
{

     /// <summary>
    /// Initializes a new instance of the <see cref="RutileDbContext"/> class.
    /// </summary>
    /// <param name="options">The database context options.</param>
    public DatabaseDBContext(DbContextOptions<DatabaseDBContext> options)
        : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }
    /// <inheritdoc/>
    public DbSet<Vendor> Vendors { get; set; }
}