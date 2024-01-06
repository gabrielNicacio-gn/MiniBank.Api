using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniBank.Api.Migrations
{
    /// <inheritdoc />
    public partial class Deposite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TransactionDate",
                table: "Transactions",
                newName: "TransactionDateAndTime");

            migrationBuilder.CreateTable(
                name: "Deposites",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Value = table.Column<decimal>(type: "TEXT", nullable: false),
                    DepositeDateAndTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deposites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deposites_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Deposites_UserId",
                table: "Deposites",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Deposites");

            migrationBuilder.RenameColumn(
                name: "TransactionDateAndTime",
                table: "Transactions",
                newName: "TransactionDate");
        }
    }
}
