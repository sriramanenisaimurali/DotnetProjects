﻿// <auto-generated />
using System;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Entities.Migrations
{
    [DbContext(typeof(PersonsDbContext))]
    [Migration("20240226152500_GetAllPersons_StoredProcedure")]
    partial class GetAllPersons_StoredProcedure
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Entities.Country", b =>
                {
                    b.Property<Guid>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CountryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CountryId");

                    b.ToTable("Countries", (string)null);

                    b.HasData(
                        new
                        {
                            CountryId = new Guid("efea4699-de54-4951-b4fe-1a9a661dc7eb"),
                            CountryName = "Mexico"
                        },
                        new
                        {
                            CountryId = new Guid("bb1bcf6d-61a8-4a98-91d7-a8e1288bdb53"),
                            CountryName = "Russia"
                        },
                        new
                        {
                            CountryId = new Guid("c1d50dc8-f925-4cfe-a3f6-68d1219395c7"),
                            CountryName = "Indonesia"
                        },
                        new
                        {
                            CountryId = new Guid("5967e166-86cc-4e36-9af2-288eec1992dd"),
                            CountryName = "Nigeria"
                        },
                        new
                        {
                            CountryId = new Guid("b452dad6-287c-4493-9fdc-d47988805850"),
                            CountryName = "Peru"
                        },
                        new
                        {
                            CountryId = new Guid("78e38ba1-bd86-43bd-a1cd-5073e65940e8"),
                            CountryName = "Serbia"
                        },
                        new
                        {
                            CountryId = new Guid("aed43d62-7e52-4033-8aa2-98a7be2a6352"),
                            CountryName = "United States"
                        });
                });

            modelBuilder.Entity("Entities.Person", b =>
                {
                    b.Property<Guid>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid?>("CountryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Gender")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("PersonName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("ReceivingNewsLetters")
                        .HasColumnType("bit");

                    b.HasKey("PersonId");

                    b.ToTable("Persons", (string)null);

                    b.HasData(
                        new
                        {
                            PersonId = new Guid("e54b1d65-de12-40e1-9eb5-26c397267456"),
                            Address = "63399 Algoma Drive",
                            CountryId = new Guid("efea4699-de54-4951-b4fe-1a9a661dc7eb"),
                            DateOfBirth = new DateTime(1995, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "fhendrich0@github.io",
                            Gender = "Male",
                            PersonName = "Filippo Hendrich",
                            ReceivingNewsLetters = false
                        },
                        new
                        {
                            PersonId = new Guid("862dea7f-1933-4aed-9e3f-294faa39ae11"),
                            Address = "770 Schlimgen Center",
                            CountryId = new Guid("efea4699-de54-4951-b4fe-1a9a661dc7eb"),
                            DateOfBirth = new DateTime(1964, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "atyrwhitt1@ycombinator.com",
                            Gender = "Male",
                            PersonName = "Adolphus Tyrwhitt",
                            ReceivingNewsLetters = true
                        },
                        new
                        {
                            PersonId = new Guid("9aef28a7-f6b7-4a88-93f6-14d76a1b0537"),
                            Address = "7587 Express Trail",
                            CountryId = new Guid("bb1bcf6d-61a8-4a98-91d7-a8e1288bdb53"),
                            DateOfBirth = new DateTime(2008, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "hast2@goodreads.com",
                            Gender = "Female",
                            PersonName = "Harley Ast",
                            ReceivingNewsLetters = false
                        },
                        new
                        {
                            PersonId = new Guid("a4a74f3c-9bab-4913-b332-fe30512a65c6"),
                            Address = "82131 2nd Park",
                            CountryId = new Guid("bb1bcf6d-61a8-4a98-91d7-a8e1288bdb53"),
                            DateOfBirth = new DateTime(1981, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "lcartan3@wordpress.org",
                            Gender = "Female",
                            PersonName = "Lotty Cartan",
                            ReceivingNewsLetters = true
                        },
                        new
                        {
                            PersonId = new Guid("eae0067f-8b16-45d9-888e-2150bdaa2c2c"),
                            Address = "78721 Anniversary Lane",
                            CountryId = new Guid("c1d50dc8-f925-4cfe-a3f6-68d1219395c7"),
                            DateOfBirth = new DateTime(1960, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "uphipp4@boston.com",
                            Gender = "Male",
                            PersonName = "Ulrich Phipp",
                            ReceivingNewsLetters = false
                        },
                        new
                        {
                            PersonId = new Guid("3c4a543c-109e-4da1-988d-34e031cec84b"),
                            Address = "536 Gerald Alley",
                            CountryId = new Guid("c1d50dc8-f925-4cfe-a3f6-68d1219395c7"),
                            DateOfBirth = new DateTime(2004, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "npeskett5@t.co",
                            Gender = "Female",
                            PersonName = "Nyssa Peskett",
                            ReceivingNewsLetters = true
                        },
                        new
                        {
                            PersonId = new Guid("c40dcef6-ba67-4d6b-9f4f-1a047d6e84e0"),
                            Address = "0821 Carey Parkway",
                            CountryId = new Guid("5967e166-86cc-4e36-9af2-288eec1992dd"),
                            DateOfBirth = new DateTime(1995, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "snovik6@netlog.com",
                            Gender = "Female",
                            PersonName = "Sibylle Novik",
                            ReceivingNewsLetters = false
                        },
                        new
                        {
                            PersonId = new Guid("5004a318-05c5-4ecb-970a-928275345a39"),
                            Address = "95 Porter Terrace",
                            CountryId = new Guid("5967e166-86cc-4e36-9af2-288eec1992dd"),
                            DateOfBirth = new DateTime(1958, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "ovallentin7@last.fm",
                            Gender = "Male",
                            PersonName = "Owen Vallentin",
                            ReceivingNewsLetters = false
                        },
                        new
                        {
                            PersonId = new Guid("6cc43e4d-9f33-4558-bc36-fab55c39a24d"),
                            Address = "11336 Clarendon Road",
                            CountryId = new Guid("b452dad6-287c-4493-9fdc-d47988805850"),
                            DateOfBirth = new DateTime(1951, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "qblazhevich8@google.com",
                            Gender = "Female",
                            PersonName = "Querida Blazhevich",
                            ReceivingNewsLetters = true
                        },
                        new
                        {
                            PersonId = new Guid("689e36d3-f6ac-4912-94d2-549b4d50ac35"),
                            Address = "3 Coleman Hill",
                            CountryId = new Guid("b452dad6-287c-4493-9fdc-d47988805850"),
                            DateOfBirth = new DateTime(1992, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "efifoot9@ft.com",
                            Gender = "Others",
                            PersonName = "Evin Fifoot",
                            ReceivingNewsLetters = true
                        },
                        new
                        {
                            PersonId = new Guid("2d3044c4-bdb6-461e-abce-23aa137d5a32"),
                            Address = "406 Macpherson Way",
                            CountryId = new Guid("78e38ba1-bd86-43bd-a1cd-5073e65940e8"),
                            DateOfBirth = new DateTime(2004, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "primoura@unesco.org",
                            Gender = "Female",
                            PersonName = "Phelia Rimour",
                            ReceivingNewsLetters = false
                        },
                        new
                        {
                            PersonId = new Guid("300a9d49-1bba-4647-83df-a603051401b5"),
                            Address = "5 Russell Court",
                            CountryId = new Guid("78e38ba1-bd86-43bd-a1cd-5073e65940e8"),
                            DateOfBirth = new DateTime(1974, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "eadamob@weather.com",
                            Gender = "Female",
                            PersonName = "Ellynn Adamo",
                            ReceivingNewsLetters = true
                        },
                        new
                        {
                            PersonId = new Guid("3939d52c-f88e-4042-bcea-8a921ad64380"),
                            Address = "0 Porter Junction",
                            CountryId = new Guid("aed43d62-7e52-4033-8aa2-98a7be2a6352"),
                            DateOfBirth = new DateTime(1996, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "mscrivinc@usatoday.com",
                            Gender = "Female",
                            PersonName = "Minnaminnie Scrivin",
                            ReceivingNewsLetters = false
                        },
                        new
                        {
                            PersonId = new Guid("7d49adb9-8790-4061-b8ca-c896de0cab8b"),
                            Address = "55115 Logan Circle",
                            CountryId = new Guid("aed43d62-7e52-4033-8aa2-98a7be2a6352"),
                            DateOfBirth = new DateTime(1982, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "fellesd@soundcloud.com",
                            Gender = "Male",
                            PersonName = "Frederic Elles",
                            ReceivingNewsLetters = true
                        },
                        new
                        {
                            PersonId = new Guid("2cdf1ca6-407a-41fb-8639-7d373493ba54"),
                            Address = "85 Kipling Place",
                            CountryId = new Guid("aed43d62-7e52-4033-8aa2-98a7be2a6352"),
                            DateOfBirth = new DateTime(1992, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "bnettlese@shinystat.com",
                            Gender = "Others",
                            PersonName = "Berri Nettles",
                            ReceivingNewsLetters = false
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
