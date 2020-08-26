using Microsoft.EntityFrameworkCore.Migrations;

namespace Podium.Data.Migrations
{
    public partial class ChangedTypesForProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "LoanToValue",
                table: "Products",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "InterestRate",
                table: "Products",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "LoanToValue",
                table: "Products",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<double>(
                name: "InterestRate",
                table: "Products",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
