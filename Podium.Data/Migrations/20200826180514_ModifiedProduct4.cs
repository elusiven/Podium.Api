using Microsoft.EntityFrameworkCore.Migrations;

namespace Podium.Data.Migrations
{
    public partial class ModifiedProduct4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "LoanCalculationProducts",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    LoanCalculationId = table.Column<string>(nullable: true),
                    ProductId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanCalculationProducts", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoanCalculationProducts");

            migrationBuilder.AddColumn<string>(
                name: "LoanCalculationId1",
                table: "Products",
                type: "nvarchar(450)",
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
    }
}
