using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ContactManager.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorys",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorys", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "ContactInfos",
                columns: table => new
                {
                    ContactInfoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false),
                    Organization = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactInfos", x => x.ContactInfoID);
                    table.ForeignKey(
                        name: "FK_ContactInfos_Categorys_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categorys",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categorys",
                columns: new[] { "CategoryID", "Name" },
                values: new object[,]
                {
                    { 1, "Friend" },
                    { 2, "Work" },
                    { 3, "Family" },
                    { 4, "Foe" },
                    { 5, "Bestie" }
                });

            migrationBuilder.InsertData(
                table: "ContactInfos",
                columns: new[] { "ContactInfoID", "CategoryID", "CreateDate", "Email", "FirstName", "LastName", "Organization", "PhoneNumber" },
                values: new object[] { 1, 1, new DateTime(2022, 4, 5, 0, 0, 0, 0, DateTimeKind.Local), "FlyBoy@gmail.com", "Luke", "Skywalker", "The Rebellion", "502-896-1234" });

            migrationBuilder.InsertData(
                table: "ContactInfos",
                columns: new[] { "ContactInfoID", "CategoryID", "CreateDate", "Email", "FirstName", "LastName", "Organization", "PhoneNumber" },
                values: new object[] { 3, 4, new DateTime(2022, 4, 5, 0, 0, 0, 0, DateTimeKind.Local), "PewPewLasers@gmail.com", "Imperial ", "StormTrooper", "The Empire", "502-444-4123" });

            migrationBuilder.InsertData(
                table: "ContactInfos",
                columns: new[] { "ContactInfoID", "CategoryID", "CreateDate", "Email", "FirstName", "LastName", "Organization", "PhoneNumber" },
                values: new object[] { 2, 5, new DateTime(2022, 4, 5, 0, 0, 0, 0, DateTimeKind.Local), "BountyHunter@gmail.com", "Boba", "Fett", "Bounty Hunter's Guild", "502-999-5555" });

            migrationBuilder.CreateIndex(
                name: "IX_ContactInfos_CategoryID",
                table: "ContactInfos",
                column: "CategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactInfos");

            migrationBuilder.DropTable(
                name: "Categorys");
        }
    }
}
