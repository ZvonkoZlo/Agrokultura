using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agrokultura.Migrations
{
    /// <inheritdoc />
    public partial class Prva : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "chore",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "varchar(5000)", unicode: false, maxLength: 5000, nullable: false),
                    duration = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__chore__3213E83F1CB3BDDD", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "chore_status",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__chore_st__3213E83FAD3F0B0E", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "country",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__country__3213E83FE9403171", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "goods_type",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__goods_ty__3213E83FCF7F9773", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ground",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "varchar(5000)", unicode: false, maxLength: 5000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ground__3213E83FFFF90794", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "order_status",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__order_st__3213E83F8D778D95", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "plant_type",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "varchar(5000)", unicode: false, maxLength: 5000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__plant_ty__3213E83FD20B8659", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "varchar(5000)", unicode: false, maxLength: 5000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__role__3213E83FA722BBF2", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "terrain",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    sun_persence = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ground_slope = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__terrain__3213E83F7D46155D", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "city",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    postal_code = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    country_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__city__3213E83F0FBAFC12", x => x.id);
                    table.ForeignKey(
                        name: "FK__city__country_id__5AEE82B9",
                        column: x => x.country_id,
                        principalTable: "country",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "person",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    full_name = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    phone_number = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: false),
                    email = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    adress = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    city_id = table.Column<int>(type: "int", nullable: true),
                    role_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__person__3213E83FC6A192CC", x => x.id);
                    table.ForeignKey(
                        name: "FK__person__city_id__6477ECF3",
                        column: x => x.city_id,
                        principalTable: "city",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__person__role_id__656C112C",
                        column: x => x.role_id,
                        principalTable: "role",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "chore_person",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "varchar(5000)", unicode: false, maxLength: 5000, nullable: true),
                    order_status_id = table.Column<int>(type: "int", nullable: false),
                    chore_id = table.Column<int>(type: "int", nullable: false),
                    person_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__chore_pe__3213E83F7148C5FF", x => x.id);
                    table.ForeignKey(
                        name: "FK__chore_per__chore__5812160E",
                        column: x => x.chore_id,
                        principalTable: "chore",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__chore_per__order__59063A47",
                        column: x => x.order_status_id,
                        principalTable: "order_status",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__chore_per__perso__59FA5E80",
                        column: x => x.person_id,
                        principalTable: "person",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "contract",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    provider_id = table.Column<int>(type: "int", nullable: false),
                    beneficiary_id = table.Column<int>(type: "int", nullable: false),
                    date_of_conclusion = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    date_of_expiration = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__contract__3213E83F65AEF21C", x => x.id);
                    table.ForeignKey(
                        name: "FK__contract__benefi__5BE2A6F2",
                        column: x => x.beneficiary_id,
                        principalTable: "person",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__contract__provid__5CD6CB2B",
                        column: x => x.provider_id,
                        principalTable: "person",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "plant",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    description = table.Column<string>(type: "varchar(5000)", unicode: false, maxLength: 5000, nullable: true),
                    subspecies_name = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    amount_of_goods = table.Column<double>(type: "float", nullable: true),
                    price = table.Column<double>(type: "float", nullable: true),
                    plant_type_id = table.Column<int>(type: "int", nullable: true),
                    goods_type_id = table.Column<int>(type: "int", nullable: true),
                    manufacturer_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__plant__3213E83FA4C407E4", x => x.id);
                    table.ForeignKey(
                        name: "FK__plant__goods_typ__66603565",
                        column: x => x.goods_type_id,
                        principalTable: "goods_type",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__plant__manufactu__6754599E",
                        column: x => x.manufacturer_id,
                        principalTable: "person",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__plant__plant_typ__68487DD7",
                        column: x => x.plant_type_id,
                        principalTable: "plant_type",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "plot",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    coordinates = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    longitudes = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    corners = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    ground_id = table.Column<int>(type: "int", nullable: true),
                    terrain_id = table.Column<int>(type: "int", nullable: true),
                    owner_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__plot__3213E83F0E997AF4", x => x.id);
                    table.ForeignKey(
                        name: "FK__plot__ground_id__693CA210",
                        column: x => x.ground_id,
                        principalTable: "ground",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__plot__owner_id__6A30C649",
                        column: x => x.owner_id,
                        principalTable: "person",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__plot__terrain_id__6B24EA82",
                        column: x => x.terrain_id,
                        principalTable: "terrain",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "order",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    amount_of_goods = table.Column<double>(type: "float", nullable: true),
                    customer_id = table.Column<int>(type: "int", nullable: false),
                    plant_id = table.Column<int>(type: "int", nullable: false),
                    order_status_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__order__3213E83FEB6A7775", x => x.id);
                    table.ForeignKey(
                        name: "FK__order__customer___619B8048",
                        column: x => x.customer_id,
                        principalTable: "person",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__order__order_sta__628FA481",
                        column: x => x.order_status_id,
                        principalTable: "order_status",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__order__plant_id__6383C8BA",
                        column: x => x.plant_id,
                        principalTable: "plant",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "contract_plot",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    contract_id = table.Column<int>(type: "int", nullable: true),
                    plot_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__contract__3213E83F21D8BA34", x => x.id);
                    table.ForeignKey(
                        name: "FK__contract___contr__5DCAEF64",
                        column: x => x.contract_id,
                        principalTable: "contract",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__contract___plot___5EBF139D",
                        column: x => x.plot_id,
                        principalTable: "plot",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "income_and_expenses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    plot_id = table.Column<int>(type: "int", nullable: true),
                    plant_id = table.Column<int>(type: "int", nullable: true),
                    amount_of_plants = table.Column<double>(type: "float", nullable: true),
                    price = table.Column<double>(type: "float", nullable: true),
                    date_of_planting = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    end_date_of_planting = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    amount_of_goods = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__income_a__3213E83F01D52852", x => x.id);
                    table.ForeignKey(
                        name: "FK__income_an__plant__5FB337D6",
                        column: x => x.plant_id,
                        principalTable: "plant",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__income_an__plot___60A75C0F",
                        column: x => x.plot_id,
                        principalTable: "plot",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_chore_person_chore_id",
                table: "chore_person",
                column: "chore_id");

            migrationBuilder.CreateIndex(
                name: "IX_chore_person_order_status_id",
                table: "chore_person",
                column: "order_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_chore_person_person_id",
                table: "chore_person",
                column: "person_id");

            migrationBuilder.CreateIndex(
                name: "IX_city_country_id",
                table: "city",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "IX_contract_beneficiary_id",
                table: "contract",
                column: "beneficiary_id");

            migrationBuilder.CreateIndex(
                name: "IX_contract_provider_id",
                table: "contract",
                column: "provider_id");

            migrationBuilder.CreateIndex(
                name: "IX_contract_plot_contract_id",
                table: "contract_plot",
                column: "contract_id");

            migrationBuilder.CreateIndex(
                name: "IX_contract_plot_plot_id",
                table: "contract_plot",
                column: "plot_id");

            migrationBuilder.CreateIndex(
                name: "IX_income_and_expenses_plant_id",
                table: "income_and_expenses",
                column: "plant_id");

            migrationBuilder.CreateIndex(
                name: "IX_income_and_expenses_plot_id",
                table: "income_and_expenses",
                column: "plot_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_customer_id",
                table: "order",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_order_status_id",
                table: "order",
                column: "order_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_plant_id",
                table: "order",
                column: "plant_id");

            migrationBuilder.CreateIndex(
                name: "IX_person_city_id",
                table: "person",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "IX_person_role_id",
                table: "person",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_plant_goods_type_id",
                table: "plant",
                column: "goods_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_plant_manufacturer_id",
                table: "plant",
                column: "manufacturer_id");

            migrationBuilder.CreateIndex(
                name: "IX_plant_plant_type_id",
                table: "plant",
                column: "plant_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_plot_ground_id",
                table: "plot",
                column: "ground_id");

            migrationBuilder.CreateIndex(
                name: "IX_plot_owner_id",
                table: "plot",
                column: "owner_id");

            migrationBuilder.CreateIndex(
                name: "IX_plot_terrain_id",
                table: "plot",
                column: "terrain_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "chore_person");

            migrationBuilder.DropTable(
                name: "chore_status");

            migrationBuilder.DropTable(
                name: "contract_plot");

            migrationBuilder.DropTable(
                name: "income_and_expenses");

            migrationBuilder.DropTable(
                name: "order");

            migrationBuilder.DropTable(
                name: "chore");

            migrationBuilder.DropTable(
                name: "contract");

            migrationBuilder.DropTable(
                name: "plot");

            migrationBuilder.DropTable(
                name: "order_status");

            migrationBuilder.DropTable(
                name: "plant");

            migrationBuilder.DropTable(
                name: "ground");

            migrationBuilder.DropTable(
                name: "terrain");

            migrationBuilder.DropTable(
                name: "goods_type");

            migrationBuilder.DropTable(
                name: "person");

            migrationBuilder.DropTable(
                name: "plant_type");

            migrationBuilder.DropTable(
                name: "city");

            migrationBuilder.DropTable(
                name: "role");

            migrationBuilder.DropTable(
                name: "country");
        }
    }
}
