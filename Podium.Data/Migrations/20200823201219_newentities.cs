using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Podium.Data.Migrations
{
    public partial class newentities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserDetails",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PropertyDetails",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    PropertyValue = table.Column<double>(nullable: false),
                    DepositAmount = table.Column<double>(nullable: false),
                    UserDetailsId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropertyDetails_UserDetails_UserDetailsId",
                        column: x => x.UserDetailsId,
                        principalTable: "UserDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LoanCalculations",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserDetailsId = table.Column<string>(nullable: true),
                    PropertyDetailsId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanCalculations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanCalculations_PropertyDetails_PropertyDetailsId",
                        column: x => x.PropertyDetailsId,
                        principalTable: "PropertyDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LoanCalculations_UserDetails_UserDetailsId",
                        column: x => x.UserDetailsId,
                        principalTable: "UserDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Lender = table.Column<string>(nullable: true),
                    InterestRate = table.Column<double>(nullable: false),
                    LoanType = table.Column<int>(nullable: false),
                    LoanToValue = table.Column<double>(nullable: false),
                    LoanCalculationId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_LoanCalculations_LoanCalculationId",
                        column: x => x.LoanCalculationId,
                        principalTable: "LoanCalculations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoanCalculations_PropertyDetailsId",
                table: "LoanCalculations",
                column: "PropertyDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanCalculations_UserDetailsId",
                table: "LoanCalculations",
                column: "UserDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_LoanCalculationId",
                table: "Products",
                column: "LoanCalculationId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyDetails_UserDetailsId",
                table: "PropertyDetails",
                column: "UserDetailsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "LoanCalculations");

            migrationBuilder.DropTable(
                name: "PropertyDetails");

            migrationBuilder.DropTable(
                name: "UserDetails");
        }
    }
}
