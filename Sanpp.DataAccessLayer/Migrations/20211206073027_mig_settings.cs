using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Snapp.DataAccessLayer.Migrations
{
    public partial class mig_settings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tel = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    About = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Terms = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConsiderWeatherForPrice = table.Column<bool>(type: "bit", nullable: false),
                    ConsiderDistanceForPrice = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Settings");
        }
    }
}
