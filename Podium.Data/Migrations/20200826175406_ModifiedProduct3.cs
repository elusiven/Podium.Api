using Microsoft.EntityFrameworkCore.Migrations;

namespace Podium.Data.Migrations
{
    public partial class ModifiedProduct3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LoanCalculationId1",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_LoanCalculationId1",
                table: "Products",
                column: "LoanCalculationId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_LoanCalculations_LoanCalculationId1",
                table: "Products",
                column: "LoanCalculationId1",
                principalTable: "LoanCalculations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_LoanCalculations_LoanCalculationId1",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_LoanCalculationId1",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "LoanCalculationId1",
                table: "Products");
        }
    }
}
