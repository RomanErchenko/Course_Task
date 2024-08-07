using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DayaAcces.Migrations
{
    /// <inheritdoc />
    public partial class ssk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notess",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Info = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notess", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notess_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "Name", "Password" },
                values: new object[] { new Guid("54f2f515-54a1-454a-9585-54a1454a9585"), "login", "Dimon", "password" });

            migrationBuilder.InsertData(
                table: "Notess",
                columns: new[] { "Id", "Date", "Info", "UserId" },
                values: new object[] { new Guid("dc3a0147-b895-48dd-82f4-420c4611a4c9"), new DateTime(2024, 7, 20, 18, 30, 25, 0, DateTimeKind.Unspecified), "Pashka Info1", new Guid("54f2f515-54a1-454a-9585-54a1454a9585") });

            migrationBuilder.CreateIndex(
                name: "IX_Notess_UserId",
                table: "Notess",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notess");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
