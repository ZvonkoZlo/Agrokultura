using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agrokultura.Migrations
{
    /// <inheritdoc />
    public partial class plotcontractv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__contract___contr__5DCAEF64",
                table: "contract_plot");

            migrationBuilder.DropForeignKey(
                name: "FK__contract___plot___5EBF139D",
                table: "contract_plot");

            migrationBuilder.AddColumn<decimal>(
                name: "monthly_payment",
                table: "contract_plot",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "price",
                table: "contract_plot",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK__contract___contr__5DCAEF64",
                table: "contract_plot",
                column: "contract_id",
                principalTable: "contract",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__contract___plot___5EBF139D",
                table: "contract_plot",
                column: "plot_id",
                principalTable: "plot",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__contract___contr__5DCAEF64",
                table: "contract_plot");

            migrationBuilder.DropForeignKey(
                name: "FK__contract___plot___5EBF139D",
                table: "contract_plot");

            migrationBuilder.DropColumn(
                name: "monthly_payment",
                table: "contract_plot");

            migrationBuilder.DropColumn(
                name: "price",
                table: "contract_plot");

            migrationBuilder.AddForeignKey(
                name: "FK__contract___contr__5DCAEF64",
                table: "contract_plot",
                column: "contract_id",
                principalTable: "contract",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__contract___plot___5EBF139D",
                table: "contract_plot",
                column: "plot_id",
                principalTable: "plot",
                principalColumn: "id");
        }
    }
}
