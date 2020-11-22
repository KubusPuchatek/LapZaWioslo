using Microsoft.EntityFrameworkCore.Migrations;

namespace LapZaWioslo.Migrations
{
    public partial class EventDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "EventInformation",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "EventInformation");
        }
    }
}
