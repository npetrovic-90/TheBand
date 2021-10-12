using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BandAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Founded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MainGenre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    BandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Albums_Bands_BandId",
                        column: x => x.BandId,
                        principalTable: "Bands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Bands",
                columns: new[] { "Id", "Founded", "MainGenre", "Name" },
                values: new object[,]
                {
                    { new Guid("2c64a452-0d46-4d10-9801-995ccb964c1b"), new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Heavy Metal", "Metallica" },
                    { new Guid("82fe9c1a-57be-4b28-b2ff-11f4e17acaad"), new DateTime(1985, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rock", "Guns'N'Roses" },
                    { new Guid("67952c0e-6009-472b-8bec-b19f3a79d9a9"), new DateTime(1965, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Disco", "ABBA" },
                    { new Guid("87f1ab3e-cea6-4e50-8f3b-d09524a0a6ee"), new DateTime(1965, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alternative", "Oasis" },
                    { new Guid("bbd1357d-eb6c-4b2a-9290-98d704c004c3"), new DateTime(1981, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pop", "A-ha" }
                });

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "Id", "BandId", "Description", "Title" },
                values: new object[,]
                {
                    { new Guid("beaacd3f-aaa4-4044-9c66-cec29ee3805c"), new Guid("2c64a452-0d46-4d10-9801-995ccb964c1b"), "One of the best heavy metal albums ever", "Master of Puppets" },
                    { new Guid("d2663550-2412-4e29-8b7c-056431032cec"), new Guid("82fe9c1a-57be-4b28-b2ff-11f4e17acaad"), "Amazing Rock Album with raw sound", "Appetite for Destruction" },
                    { new Guid("491d3ef0-cfa6-4ec6-98f8-20112c9f3d29"), new Guid("67952c0e-6009-472b-8bec-b19f3a79d9a9"), "Very groovy album", "Waterloo" },
                    { new Guid("814092af-023e-4ccc-9474-86b29da4588e"), new Guid("87f1ab3e-cea6-4e50-8f3b-d09524a0a6ee"), "One of the best albums by Oasis", "Be Here Now" },
                    { new Guid("36a6190e-6eed-4ae8-88a1-6d987c47c029"), new Guid("bbd1357d-eb6c-4b2a-9290-98d704c004c3"), "One of the best heavy metal albums ever", "Hunting High and Low" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Albums_BandId",
                table: "Albums",
                column: "BandId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "Bands");
        }
    }
}
