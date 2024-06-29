﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DayaAcces.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Info = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
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
                values: new object[,]
                {
                    { 1, "login", "Dimon", "password" },
                    { 2, "login1", "Pashka", "password1" }
                });

            migrationBuilder.InsertData(
                table: "Notess",
                columns: new[] { "Id", "Date", "Info", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 7, 20, 18, 30, 25, 0, DateTimeKind.Unspecified), "Dimon Info1", 1 },
                    { 2, new DateTime(2024, 7, 20, 18, 30, 25, 0, DateTimeKind.Unspecified), "Pashka Info1", 2 }
                });

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
