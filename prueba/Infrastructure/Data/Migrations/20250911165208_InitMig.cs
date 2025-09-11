using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "audiences",
                columns: table => new
                {
                    id = table.Column<int>(type: "SERIAL", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    description = table.Column<string>(type: "VARCHAR", maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_audiences", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "benefits",
                columns: table => new
                {
                    id = table.Column<int>(type: "SERIAL", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    description = table.Column<string>(type: "VARCHAR", maxLength: 80, nullable: true),
                    detail = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_benefits", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    id = table.Column<int>(type: "SERIAL", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    description = table.Column<string>(type: "VARCHAR", maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "category_polls",
                columns: table => new
                {
                    id = table.Column<int>(type: "SERIAL", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "VARCHAR", maxLength: 80, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category_polls", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "countries",
                columns: table => new
                {
                    isocode = table.Column<string>(type: "VARCHAR", maxLength: 10, nullable: false),
                    name = table.Column<string>(type: "VARCHAR", maxLength: 50, nullable: false),
                    alsa_iso_two = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    alsa_iso_three = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_countries", x => x.isocode);
                });

            migrationBuilder.CreateTable(
                name: "memberships",
                columns: table => new
                {
                    id = table.Column<int>(type: "SERIAL", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_memberships", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "periods",
                columns: table => new
                {
                    id = table.Column<int>(type: "SERIAL", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "VARCHAR", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_periods", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "subdivision_categories",
                columns: table => new
                {
                    id = table.Column<int>(type: "SERIAL", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    description = table.Column<string>(type: "VARCHAR", maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subdivision_categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "type_identification",
                columns: table => new
                {
                    id = table.Column<int>(type: "SERIAL", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    description = table.Column<string>(type: "VARCHAR", maxLength: 60, nullable: true),
                    sufix = table.Column<string>(type: "VARCHAR", maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_type_identification", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "types_products",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    description = table.Column<string>(type: "VARCHAR", maxLength: 80, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_types_products", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "unit_of_measure",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    description = table.Column<string>(type: "VARCHAR", maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_unit_of_measure", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "audience_benefits",
                columns: table => new
                {
                    audience_id = table.Column<int>(type: "INTEGER", nullable: false),
                    benefit_id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_audience_benefits", x => new { x.audience_id, x.benefit_id });
                    table.ForeignKey(
                        name: "FK_audience_benefits_audiences_audience_id",
                        column: x => x.audience_id,
                        principalTable: "audiences",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_audience_benefits_benefits_benefit_id",
                        column: x => x.benefit_id,
                        principalTable: "benefits",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "polls",
                columns: table => new
                {
                    id = table.Column<int>(type: "SERIAL", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: true),
                    description = table.Column<string>(type: "TEXT", nullable: true),
                    is_active = table.Column<bool>(type: "BOOLEAN", nullable: true),
                    categorypoll_id = table.Column<int>(type: "INT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_polls", x => x.id);
                    table.ForeignKey(
                        name: "FK_polls_category_polls_categorypoll_id",
                        column: x => x.categorypoll_id,
                        principalTable: "category_polls",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "states_or_regions",
                columns: table => new
                {
                    code = table.Column<string>(type: "VARCHAR", maxLength: 6, nullable: false),
                    name = table.Column<string>(type: "VARCHAR", maxLength: 60, nullable: true),
                    country_id = table.Column<string>(type: "VARCHAR", maxLength: 6, nullable: true),
                    code_3166 = table.Column<string>(type: "VARCHAR", maxLength: 10, nullable: true),
                    subdivision_category_id = table.Column<int>(type: "INT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_states_or_regions", x => x.code);
                    table.ForeignKey(
                        name: "FK_states_or_regions_countries_country_id",
                        column: x => x.country_id,
                        principalTable: "countries",
                        principalColumn: "isocode");
                    table.ForeignKey(
                        name: "FK_states_or_regions_subdivision_categories_subdivision_catego~",
                        column: x => x.subdivision_category_id,
                        principalTable: "subdivision_categories",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    id = table.Column<int>(type: "SERIAL", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "VARCHAR", maxLength: 80, nullable: true),
                    city_id = table.Column<string>(type: "TEXT", maxLength: 6, nullable: true),
                    price = table.Column<double>(type: "DOUBLE", nullable: true),
                    typeproduct_id = table.Column<int>(type: "INT", nullable: true),
                    image = table.Column<string>(type: "VARCHAR", maxLength: 80, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.id);
                    table.ForeignKey(
                        name: "FK_products_types_products_typeproduct_id",
                        column: x => x.typeproduct_id,
                        principalTable: "types_products",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "city_or_municipalities",
                columns: table => new
                {
                    code = table.Column<string>(type: "VARCHAR", maxLength: 6, nullable: false),
                    name = table.Column<string>(type: "VARCHAR", maxLength: 60, nullable: true),
                    state_reg_id = table.Column<string>(type: "VARCHAR", maxLength: 6, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_city_or_municipalities", x => x.code);
                    table.ForeignKey(
                        name: "FK_city_or_municipalities_states_or_regions_state_reg_id",
                        column: x => x.state_reg_id,
                        principalTable: "states_or_regions",
                        principalColumn: "code");
                });

            migrationBuilder.CreateTable(
                name: "companies",
                columns: table => new
                {
                    id = table.Column<string>(type: "VARCHAR", maxLength: 20, nullable: false),
                    TypeId = table.Column<int>(type: "SERIAL", nullable: true),
                    name = table.Column<string>(type: "VARCHAR", maxLength: 80, nullable: true),
                    category_id = table.Column<int>(type: "INT", nullable: true),
                    city_id = table.Column<string>(type: "VARCHAR", maxLength: 6, nullable: true),
                    audience_id = table.Column<int>(type: "INT", nullable: true),
                    cellphone = table.Column<string>(type: "VARCHAR", maxLength: 15, nullable: true),
                    email = table.Column<string>(type: "VARCHAR", maxLength: 80, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_companies", x => x.id);
                    table.ForeignKey(
                        name: "FK_companies_audiences_audience_id",
                        column: x => x.audience_id,
                        principalTable: "audiences",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_companies_categories_category_id",
                        column: x => x.category_id,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_companies_city_or_municipalities_city_id",
                        column: x => x.city_id,
                        principalTable: "city_or_municipalities",
                        principalColumn: "code");
                    table.ForeignKey(
                        name: "FK_companies_type_identification_TypeId",
                        column: x => x.TypeId,
                        principalTable: "type_identification",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    id = table.Column<int>(type: "SERIAL", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "VARCHAR", maxLength: 80, nullable: true),
                    city_id = table.Column<string>(type: "VARCHAR", maxLength: 6, nullable: true),
                    audience_id = table.Column<int>(type: "INTEGER", nullable: true),
                    cellphone = table.Column<string>(type: "VARCHAR", maxLength: 20, nullable: true),
                    email = table.Column<string>(type: "VARCHAR", maxLength: 100, nullable: true),
                    address = table.Column<string>(type: "VARCHAR", maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.id);
                    table.ForeignKey(
                        name: "FK_customers_audiences_audience_id",
                        column: x => x.audience_id,
                        principalTable: "audiences",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_customers_city_or_municipalities_city_id",
                        column: x => x.city_id,
                        principalTable: "city_or_municipalities",
                        principalColumn: "code");
                });

            migrationBuilder.CreateTable(
                name: "company_products",
                columns: table => new
                {
                    company_id = table.Column<string>(type: "VARCHAR", maxLength: 20, nullable: false),
                    product_id = table.Column<int>(type: "INT", nullable: false),
                    price = table.Column<double>(type: "double", nullable: true),
                    unit_measure_id = table.Column<int>(type: "INT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_company_products", x => new { x.company_id, x.product_id });
                    table.ForeignKey(
                        name: "FK_company_products_companies_company_id",
                        column: x => x.company_id,
                        principalTable: "companies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_company_products_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_company_products_unit_of_measure_unit_measure_id",
                        column: x => x.unit_measure_id,
                        principalTable: "unit_of_measure",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "membership_periods",
                columns: table => new
                {
                    id = table.Column<int>(type: "SERIAL", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    membership_id = table.Column<int>(type: "INT", nullable: true),
                    period_id = table.Column<int>(type: "INT", nullable: true),
                    name = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: true),
                    description = table.Column<string>(type: "TEXT", nullable: true),
                    price = table.Column<double>(type: "DOUBLE", nullable: true),
                    company_id = table.Column<string>(type: "VARCHAR", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_membership_periods", x => x.id);
                    table.ForeignKey(
                        name: "FK_membership_periods_companies_company_id",
                        column: x => x.company_id,
                        principalTable: "companies",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_membership_periods_memberships_membership_id",
                        column: x => x.membership_id,
                        principalTable: "memberships",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_membership_periods_periods_period_id",
                        column: x => x.period_id,
                        principalTable: "periods",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "favorites",
                columns: table => new
                {
                    id = table.Column<int>(type: "SERIAL", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    customer_id = table.Column<int>(type: "iNTEGER", nullable: true),
                    company_id = table.Column<string>(type: "VARCHAR", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_favorites", x => x.id);
                    table.ForeignKey(
                        name: "FK_favorites_companies_company_id",
                        column: x => x.company_id,
                        principalTable: "companies",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_favorites_customers_customer_id",
                        column: x => x.customer_id,
                        principalTable: "customers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "quality_products",
                columns: table => new
                {
                    product_id = table.Column<int>(type: "INT", nullable: false),
                    customer_id = table.Column<int>(type: "INT", nullable: false),
                    poll_id = table.Column<int>(type: "INT", nullable: false),
                    company_id = table.Column<string>(type: "VARCHAR", maxLength: 20, nullable: false),
                    daterating = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    rating = table.Column<double>(type: "DOUBLE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quality_products", x => new { x.product_id, x.customer_id, x.poll_id, x.company_id });
                    table.ForeignKey(
                        name: "FK_quality_products_companies_company_id",
                        column: x => x.company_id,
                        principalTable: "companies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_quality_products_customers_customer_id",
                        column: x => x.customer_id,
                        principalTable: "customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_quality_products_polls_poll_id",
                        column: x => x.poll_id,
                        principalTable: "polls",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_quality_products_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "rates",
                columns: table => new
                {
                    customer_id = table.Column<int>(type: "INT", nullable: false),
                    company_id = table.Column<string>(type: "VARCHAR", nullable: false),
                    poll_id = table.Column<int>(type: "INT", nullable: false),
                    daterating = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    rating = table.Column<double>(type: "DOUBLE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rates", x => new { x.customer_id, x.company_id, x.poll_id });
                    table.ForeignKey(
                        name: "FK_rates_companies_company_id",
                        column: x => x.company_id,
                        principalTable: "companies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_rates_customers_customer_id",
                        column: x => x.customer_id,
                        principalTable: "customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_rates_polls_poll_id",
                        column: x => x.poll_id,
                        principalTable: "polls",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "membership_benefits",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    membership_period_id = table.Column<int>(type: "INTEGER", nullable: false),
                    benefit_id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_membership_benefits", x => x.id);
                    table.ForeignKey(
                        name: "FK_membership_benefits_benefits_benefit_id",
                        column: x => x.benefit_id,
                        principalTable: "benefits",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_membership_benefits_membership_periods_membership_period_id",
                        column: x => x.membership_period_id,
                        principalTable: "membership_periods",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "details_favorites",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    favorite_id = table.Column<int>(type: "INT", nullable: false),
                    product_id = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_details_favorites", x => x.id);
                    table.ForeignKey(
                        name: "FK_details_favorites_favorites_favorite_id",
                        column: x => x.favorite_id,
                        principalTable: "favorites",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_details_favorites_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_audience_benefits_benefit_id",
                table: "audience_benefits",
                column: "benefit_id");

            migrationBuilder.CreateIndex(
                name: "IX_categories_description",
                table: "categories",
                column: "description",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_category_polls_name",
                table: "category_polls",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_city_or_municipalities_name",
                table: "city_or_municipalities",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_city_or_municipalities_state_reg_id",
                table: "city_or_municipalities",
                column: "state_reg_id");

            migrationBuilder.CreateIndex(
                name: "IX_companies_audience_id",
                table: "companies",
                column: "audience_id");

            migrationBuilder.CreateIndex(
                name: "IX_companies_category_id",
                table: "companies",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_companies_cellphone",
                table: "companies",
                column: "cellphone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_companies_city_id",
                table: "companies",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "IX_companies_email",
                table: "companies",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_companies_TypeId",
                table: "companies",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_company_products_product_id",
                table: "company_products",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_company_products_unit_measure_id",
                table: "company_products",
                column: "unit_measure_id");

            migrationBuilder.CreateIndex(
                name: "IX_countries_alsa_iso_three",
                table: "countries",
                column: "alsa_iso_three",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_countries_alsa_iso_two",
                table: "countries",
                column: "alsa_iso_two",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_countries_name",
                table: "countries",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_customers_audience_id",
                table: "customers",
                column: "audience_id");

            migrationBuilder.CreateIndex(
                name: "IX_customers_cellphone",
                table: "customers",
                column: "cellphone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_customers_city_id",
                table: "customers",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "IX_customers_email",
                table: "customers",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_details_favorites_favorite_id",
                table: "details_favorites",
                column: "favorite_id");

            migrationBuilder.CreateIndex(
                name: "IX_details_favorites_product_id",
                table: "details_favorites",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_favorites_company_id",
                table: "favorites",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_favorites_customer_id",
                table: "favorites",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_membership_benefits_benefit_id",
                table: "membership_benefits",
                column: "benefit_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_membership_benefits_membership_period_id",
                table: "membership_benefits",
                column: "membership_period_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_membership_periods_company_id",
                table: "membership_periods",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_membership_periods_membership_id",
                table: "membership_periods",
                column: "membership_id");

            migrationBuilder.CreateIndex(
                name: "IX_membership_periods_name",
                table: "membership_periods",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_membership_periods_period_id",
                table: "membership_periods",
                column: "period_id");

            migrationBuilder.CreateIndex(
                name: "IX_memberships_name",
                table: "memberships",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_periods_name",
                table: "periods",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_polls_categorypoll_id",
                table: "polls",
                column: "categorypoll_id");

            migrationBuilder.CreateIndex(
                name: "IX_polls_name",
                table: "polls",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_products_name",
                table: "products",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_products_typeproduct_id",
                table: "products",
                column: "typeproduct_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_quality_products_company_id",
                table: "quality_products",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_quality_products_customer_id",
                table: "quality_products",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_quality_products_poll_id",
                table: "quality_products",
                column: "poll_id");

            migrationBuilder.CreateIndex(
                name: "IX_rates_company_id",
                table: "rates",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_rates_poll_id",
                table: "rates",
                column: "poll_id");

            migrationBuilder.CreateIndex(
                name: "IX_states_or_regions_code_3166",
                table: "states_or_regions",
                column: "code_3166",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_states_or_regions_country_id",
                table: "states_or_regions",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "IX_states_or_regions_name",
                table: "states_or_regions",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_states_or_regions_subdivision_category_id",
                table: "states_or_regions",
                column: "subdivision_category_id");

            migrationBuilder.CreateIndex(
                name: "IX_subdivision_categories_description",
                table: "subdivision_categories",
                column: "description",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_types_products_description",
                table: "types_products",
                column: "description",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_unit_of_measure_description",
                table: "unit_of_measure",
                column: "description",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "audience_benefits");

            migrationBuilder.DropTable(
                name: "company_products");

            migrationBuilder.DropTable(
                name: "details_favorites");

            migrationBuilder.DropTable(
                name: "membership_benefits");

            migrationBuilder.DropTable(
                name: "quality_products");

            migrationBuilder.DropTable(
                name: "rates");

            migrationBuilder.DropTable(
                name: "unit_of_measure");

            migrationBuilder.DropTable(
                name: "favorites");

            migrationBuilder.DropTable(
                name: "benefits");

            migrationBuilder.DropTable(
                name: "membership_periods");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "polls");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "companies");

            migrationBuilder.DropTable(
                name: "memberships");

            migrationBuilder.DropTable(
                name: "periods");

            migrationBuilder.DropTable(
                name: "types_products");

            migrationBuilder.DropTable(
                name: "category_polls");

            migrationBuilder.DropTable(
                name: "audiences");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "city_or_municipalities");

            migrationBuilder.DropTable(
                name: "type_identification");

            migrationBuilder.DropTable(
                name: "states_or_regions");

            migrationBuilder.DropTable(
                name: "countries");

            migrationBuilder.DropTable(
                name: "subdivision_categories");
        }
    }
}
