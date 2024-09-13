using loadCsvIntoDockerPostgreSQLDB.DbContexts;
using loadCsvIntoDockerPostgreSQLDB.Entities;
using Microsoft.EntityFrameworkCore;

namespace loadCsvIntoDockerPostgreSQLDB.Data.Repositories;

/// <summary>
/// Repository for interacting with Alarms.
/// </summary>
public class VendorRepository(DatabaseDBContext dbContext) : Repository<Vendor>(dbContext)
{
     private readonly DatabaseDBContext _dbContext = dbContext;

     public Vendor? FindByCodeAsync(string vendorCode)
        => _dbContext.Vendors.FirstOrDefault(sv => sv.Code.Trim().ToLower().Equals(vendorCode.Trim().ToLower()));

        public List<Vendor> GetVendors()
        => _dbContext.Vendors.ToList();

}