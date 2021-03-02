using System;
using Goiabinha_API_Core.Context;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Goiabinha_API_Core.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    firstName = table.Column<string>(nullable: true),
                    surname = table.Column<string>(nullable: true),
                    age = table.Column<int>(nullable: false),
                    creationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
