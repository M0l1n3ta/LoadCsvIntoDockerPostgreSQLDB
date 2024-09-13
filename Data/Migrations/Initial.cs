using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;


namespace loadCsvIntoDockerPostgreSQLDB.Data.Migrations;

public class Initial : Migration
{

     protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                    name: "DeviceVendor",
                    columns: table => new
                    {
                        Id = table.Column<int>(type: "integer", nullable: false)
                            .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                        Name = table.Column<string>(type: "text", nullable: false),
                        Code = table.Column<string>(type: "text", nullable: false),
                        
                    },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_DeviceVendor", x => x.Id);
                    });
        }
}
