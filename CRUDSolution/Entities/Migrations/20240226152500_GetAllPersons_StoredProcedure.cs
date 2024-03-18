using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    public partial class GetAllPersons_StoredProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string spGetAllPersons = @"
                CREATE PROC [dbo].[spGetAllPersons]
                AS
                BEGIN
                    SELECT PersonId, PersonName, DateOfBirth, Gender, Email,
                           CountryId, ReceivingNewsLetters, Address FROM [dbo].[Persons]
                END
            ";
            migrationBuilder.Sql(spGetAllPersons);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string spGetAllPersons = @"
                DROP PROC [dbo].[spGetAllPersons]
            ";
            migrationBuilder.Sql(spGetAllPersons);
        }
    }
}
