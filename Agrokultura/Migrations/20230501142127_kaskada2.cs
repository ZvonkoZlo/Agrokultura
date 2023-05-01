using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agrokultura.Migrations
{
    /// <inheritdoc />
    public partial class kaskada2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__contract__provid__5CD6CB2B",
                table: "contract");

            migrationBuilder.AddForeignKey(
                name: "FK__contract__provid__5CD6CB2B",
                table: "contract",
                column: "provider_id",
                principalTable: "person",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__contract__provid__5CD6CB2B",
                table: "contract");

            migrationBuilder.AddForeignKey(
                name: "FK__contract__provid__5CD6CB2B",
                table: "contract",
                column: "provider_id",
                principalTable: "person",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
