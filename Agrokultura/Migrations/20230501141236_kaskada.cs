using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agrokultura.Migrations
{
    /// <inheritdoc />
    public partial class kaskada : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__city__country_id__5AEE82B9",
                table: "city");

            migrationBuilder.AddForeignKey(
                name: "FK__city__country_id__5AEE82B9",
                table: "city",
                column: "country_id",
                principalTable: "country",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__city__country_id__5AEE82B9",
                table: "city");

            migrationBuilder.AddForeignKey(
                name: "FK__city__country_id__5AEE82B9",
                table: "city",
                column: "country_id",
                principalTable: "country",
                principalColumn: "id");
        }
    }
}
