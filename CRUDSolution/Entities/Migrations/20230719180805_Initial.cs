using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ReceivingNewsLetters = table.Column<bool>(type: "bit", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonId);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "CountryName" },
                values: new object[,]
                {
                    { new Guid("5967e166-86cc-4e36-9af2-288eec1992dd"), "Nigeria" },
                    { new Guid("78e38ba1-bd86-43bd-a1cd-5073e65940e8"), "Serbia" },
                    { new Guid("aed43d62-7e52-4033-8aa2-98a7be2a6352"), "United States" },
                    { new Guid("b452dad6-287c-4493-9fdc-d47988805850"), "Peru" },
                    { new Guid("bb1bcf6d-61a8-4a98-91d7-a8e1288bdb53"), "Russia" },
                    { new Guid("c1d50dc8-f925-4cfe-a3f6-68d1219395c7"), "Indonesia" },
                    { new Guid("efea4699-de54-4951-b4fe-1a9a661dc7eb"), "Mexico" }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "PersonId", "Address", "CountryId", "DateOfBirth", "Email", "Gender", "PersonName", "ReceivingNewsLetters" },
                values: new object[,]
                {
                    { new Guid("2cdf1ca6-407a-41fb-8639-7d373493ba54"), "85 Kipling Place", new Guid("aed43d62-7e52-4033-8aa2-98a7be2a6352"), new DateTime(1992, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "bnettlese@shinystat.com", "Others", "Berri Nettles", false },
                    { new Guid("2d3044c4-bdb6-461e-abce-23aa137d5a32"), "406 Macpherson Way", new Guid("78e38ba1-bd86-43bd-a1cd-5073e65940e8"), new DateTime(2004, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "primoura@unesco.org", "Female", "Phelia Rimour", false },
                    { new Guid("300a9d49-1bba-4647-83df-a603051401b5"), "5 Russell Court", new Guid("78e38ba1-bd86-43bd-a1cd-5073e65940e8"), new DateTime(1974, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "eadamob@weather.com", "Female", "Ellynn Adamo", true },
                    { new Guid("3939d52c-f88e-4042-bcea-8a921ad64380"), "0 Porter Junction", new Guid("aed43d62-7e52-4033-8aa2-98a7be2a6352"), new DateTime(1996, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "mscrivinc@usatoday.com", "Female", "Minnaminnie Scrivin", false },
                    { new Guid("3c4a543c-109e-4da1-988d-34e031cec84b"), "536 Gerald Alley", new Guid("c1d50dc8-f925-4cfe-a3f6-68d1219395c7"), new DateTime(2004, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "npeskett5@t.co", "Female", "Nyssa Peskett", true },
                    { new Guid("5004a318-05c5-4ecb-970a-928275345a39"), "95 Porter Terrace", new Guid("5967e166-86cc-4e36-9af2-288eec1992dd"), new DateTime(1958, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ovallentin7@last.fm", "Male", "Owen Vallentin", false },
                    { new Guid("689e36d3-f6ac-4912-94d2-549b4d50ac35"), "3 Coleman Hill", new Guid("b452dad6-287c-4493-9fdc-d47988805850"), new DateTime(1992, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "efifoot9@ft.com", "Others", "Evin Fifoot", true },
                    { new Guid("6cc43e4d-9f33-4558-bc36-fab55c39a24d"), "11336 Clarendon Road", new Guid("b452dad6-287c-4493-9fdc-d47988805850"), new DateTime(1951, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "qblazhevich8@google.com", "Female", "Querida Blazhevich", true },
                    { new Guid("7d49adb9-8790-4061-b8ca-c896de0cab8b"), "55115 Logan Circle", new Guid("aed43d62-7e52-4033-8aa2-98a7be2a6352"), new DateTime(1982, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "fellesd@soundcloud.com", "Male", "Frederic Elles", true },
                    { new Guid("862dea7f-1933-4aed-9e3f-294faa39ae11"), "770 Schlimgen Center", new Guid("efea4699-de54-4951-b4fe-1a9a661dc7eb"), new DateTime(1964, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "atyrwhitt1@ycombinator.com", "Male", "Adolphus Tyrwhitt", true },
                    { new Guid("9aef28a7-f6b7-4a88-93f6-14d76a1b0537"), "7587 Express Trail", new Guid("bb1bcf6d-61a8-4a98-91d7-a8e1288bdb53"), new DateTime(2008, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "hast2@goodreads.com", "Female", "Harley Ast", false },
                    { new Guid("a4a74f3c-9bab-4913-b332-fe30512a65c6"), "82131 2nd Park", new Guid("bb1bcf6d-61a8-4a98-91d7-a8e1288bdb53"), new DateTime(1981, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "lcartan3@wordpress.org", "Female", "Lotty Cartan", true },
                    { new Guid("c40dcef6-ba67-4d6b-9f4f-1a047d6e84e0"), "0821 Carey Parkway", new Guid("5967e166-86cc-4e36-9af2-288eec1992dd"), new DateTime(1995, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "snovik6@netlog.com", "Female", "Sibylle Novik", false },
                    { new Guid("e54b1d65-de12-40e1-9eb5-26c397267456"), "63399 Algoma Drive", new Guid("efea4699-de54-4951-b4fe-1a9a661dc7eb"), new DateTime(1995, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "fhendrich0@github.io", "Male", "Filippo Hendrich", false },
                    { new Guid("eae0067f-8b16-45d9-888e-2150bdaa2c2c"), "78721 Anniversary Lane", new Guid("c1d50dc8-f925-4cfe-a3f6-68d1219395c7"), new DateTime(1960, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "uphipp4@boston.com", "Male", "Ulrich Phipp", false }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
