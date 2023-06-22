using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agrokultura.Migrations
{
    /// <inheritdoc />
    public partial class test55 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__income_an__plant__5FB337D6",
                table: "income_and_expenses");

            migrationBuilder.AddForeignKey(
                name: "FK__income_an__plant__5FB337D6",
                table: "income_and_expenses",
                column: "plant_id",
                principalTable: "plant",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__income_an__plant__5FB337D6",
                table: "income_and_expenses");

            migrationBuilder.AddForeignKey(
                name: "FK__income_an__plant__5FB337D6",
                table: "income_and_expenses",
                column: "plant_id",
                principalTable: "plant",
                principalColumn: "id");
        }
    }
}
