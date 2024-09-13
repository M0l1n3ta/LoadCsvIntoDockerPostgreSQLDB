
namespace loadCsvIntoDockerPostgreSQLDB.Entities;

public  class  Region
{
    public required string Name { get; set;}
    public required string Country  { get; set;}
    public required int AccountID { get; set;}
    public required string Currency {get; set;}
    
    public double GrossProfit{get; set;}
    
    public double TaxRate{get; set;}


    internal static Region ParseRow(string row)
        {
            var columns = row.Split(',');
            return new Region()
            {
                Name = columns[0],
                Country = columns[1],
                AccountID = int.Parse(columns[2]),
                Currency = columns[3],
                GrossProfit = double.Parse(columns[4]),
                TaxRate = double.Parse(columns[5])
           
            };
        }
}