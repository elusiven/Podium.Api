using Microsoft.EntityFrameworkCore.Migrations;

namespace Podium.Data.Migrations
{
    public partial class ModifiedProduct5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_LoanCalculations_LoanCalculationId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_LoanCalculationId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "LoanCalculationId",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "LoanCalculationId",
                table: "LoanCalculationProducts",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LoanCalculationProducts_LoanCalculationId",
                table: "LoanCalculationProducts",
                column: "LoanCalculationId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanCalculationProducts_LoanCalculations_LoanCalculationId",
                table: "LoanCalculationProducts",
                column: "LoanCalculationId",
                principalTable: "LoanCalculations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanCalculationProducts_LoanCalculations_LoanCalculationId",
                table: "LoanCalculationProducts");

            migrationBuilder.DropIndex(
                name: "IX_LoanCalculationProducts_LoanCalculationId",
                table: "LoanCalculationProducts");

            migrationBuilder.AddColumn<string>(
                name: "LoanCalculationId",
                table: "Products",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LoanCalculationId",
                table: "LoanCalculationProducts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_LoanCalculationId",
                table: "Products",
                column: "LoanCalculationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_LoanCalculations_LoanCalculationId",
                table: "Products",
                column: "LoanCalculationId",
                principalTable: "LoanCalculations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
