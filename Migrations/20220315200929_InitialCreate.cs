using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnet_studies.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Updated_At = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Created_At = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cameras",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    VideoUrl = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Updated_At = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Created_At = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cameras", x => x.Id);
                });
            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "Name", "Email", "Password", "Updated_At", "Created_At" },
                values: new object[] { new Guid() , 
                    "Admin", 
                    "admin@email.com", 
                    "$2a$10$8FbfUnfYKTcHfXz/nJ7fuuZhUT6QMTL6U5QOzsbCOzaRy8JPGVejC",
                    DateTime.UtcNow,
                    DateTime.UtcNow
                }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Cameras");
        }
    }
}
