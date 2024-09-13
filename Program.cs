
using Microsoft.EntityFrameworkCore;
using Testcontainers.PostgreSql;
using loadCsvIntoDockerPostgreSQLDB.DbContexts;
using loadCsvIntoDockerPostgreSQLDB.Entities;
using loadCsvIntoDockerPostgreSQLDB.Data.Repositories;

namespace loadCsvIntoDockerPostgreSQLDB;

class Program
{

    public static PostgreSqlContainer Postgres { get; private set; } = null!;
    static async Task  Main(string[] args)
    {
       
          
        Console.WriteLine("Hello, World!");
        Postgres = new PostgreSqlBuilder()
            .WithImage("postgres:16.3")
            .WithDatabase("DeviceVendors")
            .WithUsername("eroldan")
            .WithPassword("pass1234")
            .Build();

        string filePath = @"Resources\ListVendors.csv";
         // Check if the CSV file exists.
        if (!File.Exists(filePath))
        {
            // Message stating CSV file could not be located.
            Console.WriteLine("Could not locate the CSV file.");
            System.Environment.Exit(1);
        }
        
        var lista = File.ReadAllLines(filePath)
                .Skip(1)
                .Where(row => row.Length > 0)
                .Select(Vendor.ParseRow).ToList();
        Console.WriteLine($"Tamaño lista:  {lista.Count}");

        await Postgres.StartAsync();
        await DbContextCreateDatabaseOneTimeSetUpAsync();

        using var dbContext =  CreateDbContext();
        await dbContext.Vendors.AddRangeAsync(lista);
        await dbContext.SaveChangesAsync();

        Vendor? vendor = new VendorRepository(dbContext).FindByCodeAsync("00003C");

        Console.WriteLine($"Vendor Name: {vendor!.Name}");

        List<Vendor> listaDb = new VendorRepository(dbContext).GetVendors();

        Console.WriteLine($"Numero de elementos: {listaDb.Count}");
    }

  /// <summary>
    /// Obtains an instance of testcontainerDB with configured options.
    /// </summary>
    /// <returns>An instance of IntegrationTestDbContext.</returns>
    protected static DatabaseDBContext CreateDbContext()
    {
        // Configure DbContextOptions with PostgreSQL connection string and migration assembly
        var dbContextOptions = new DbContextOptionsBuilder<DatabaseDBContext>()
            .UseNpgsql(
                Postgres.GetConnectionString(),
                npgsqlOptions => npgsqlOptions.MigrationsAssembly("Rutile.Infrastructure.Data"))
            .Options;

        // Create and return a new instance of IntegrationTestDbContext with the configured options
        return new DatabaseDBContext(dbContextOptions);
    }

     /// <summary>
    /// Creates a new instance of the database asynchronously.
    /// </summary>
    private async static Task DbContextCreateDatabaseOneTimeSetUpAsync()
    {
        using var dbContext = CreateDbContext();
        await DbContextCreateDatabaseAsync(dbContext);
    }

      /// <summary>
    /// Create a new one database instance asynchronously.
    /// </summary>
    private static async Task DbContextCreateDatabaseAsync(DatabaseDBContext dbContext) => await dbContext.Database.EnsureCreatedAsync();

}
