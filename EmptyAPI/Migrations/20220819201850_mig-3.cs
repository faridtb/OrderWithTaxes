using Microsoft.EntityFrameworkCore.Migrations;

namespace EmptyAPI.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaxFeeSalt",
                table: "Tariffs");

            migrationBuilder.AddColumn<double>(
                name: "TaxFeePercent",
                table: "Tariffs",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaxFeePercent",
                table: "Tariffs");

            migrationBuilder.AddColumn<double>(
                name: "TaxFeeSalt",
                table: "Tariffs",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
