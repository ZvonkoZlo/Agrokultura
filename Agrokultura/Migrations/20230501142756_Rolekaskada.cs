using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agrokultura.Migrations
{
    /// <inheritdoc />
    public partial class Rolekaskada : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__person__role_id__656C112C",
                table: "person");

            migrationBuilder.AddForeignKey(
                name: "FK__person__role_id__656C112C",
                table: "person",
                column: "role_id",
                principalTable: "role",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__person__role_id__656C112C",
                table: "person");

            migrationBuilder.AddForeignKey(
                name: "FK__person__role_id__656C112C",
                table: "person",
                column: "role_id",
                principalTable: "role",
                principalColumn: "id");
        }
    }
}
