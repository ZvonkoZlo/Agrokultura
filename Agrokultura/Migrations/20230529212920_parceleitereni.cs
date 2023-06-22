using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agrokultura.Migrations
{
    /// <inheritdoc />
    public partial class parceleitereni : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ground_slope",
                table: "terrain");

            migrationBuilder.DropColumn(
                name: "sun_persence",
                table: "terrain");

            migrationBuilder.DropColumn(
                name: "coordinates",
                table: "plot");

            migrationBuilder.DropColumn(
                name: "corners",
                table: "plot");

            migrationBuilder.DropColumn(
                name: "longitudes",
                table: "plot");

            migrationBuilder.RenameColumn(
                name: "ground_id",
                table: "plot",
                newName: "GroundId");

            migrationBuilder.RenameIndex(
                name: "IX_plot_ground_id",
                table: "plot",
                newName: "IX_plot_GroundId");

            migrationBuilder.AddColumn<int>(
                name: "ground_slope",
                table: "plot",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "sun_presence",
                table: "plot",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ground_slope",
                table: "plot");

            migrationBuilder.DropColumn(
                name: "sun_presence",
                table: "plot");

            migrationBuilder.RenameColumn(
                name: "GroundId",
                table: "plot",
                newName: "ground_id");

            migrationBuilder.RenameIndex(
                name: "IX_plot_GroundId",
                table: "plot",
                newName: "IX_plot_ground_id");

            migrationBuilder.AddColumn<int>(
                name: "ground_slope",
                table: "terrain",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "sun_persence",
                table: "terrain",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "coordinates",
                table: "plot",
                type: "varchar(256)",
                unicode: false,
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "corners",
                table: "plot",
                type: "varchar(256)",
                unicode: false,
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "longitudes",
                table: "plot",
                type: "varchar(256)",
                unicode: false,
                maxLength: 256,
                nullable: true);
        }
    }
}
