
using loadCsvIntoDockerPostgreSQLDB.Data.Repositories;

namespace loadCsvIntoDockerPostgreSQLDB.Entities;
public class Vendor : Entity
{
    public required string Name { get; set;}
    public required string Code { get; set;}

   public Vendor(){}
    public Vendor( string name,  string code)
    {
        Name = name;
        Code = code;
    }

     internal static Vendor ParseRow(string row)
        {
            var columns = row.Split(',');
            return new Vendor()
            {
                Code = columns[0],
                Name = columns[1],
            };
        }
}