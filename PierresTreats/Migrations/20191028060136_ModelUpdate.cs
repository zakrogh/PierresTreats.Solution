using Microsoft.EntityFrameworkCore.Migrations;

namespace PierresTreats.Migrations
{
    public partial class ModelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FlavorName",
                table: "TreatFlavor",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TreatName",
                table: "TreatFlavor",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FlavorName",
                table: "TreatFlavor");

            migrationBuilder.DropColumn(
                name: "TreatName",
                table: "TreatFlavor");
        }
    }
}
