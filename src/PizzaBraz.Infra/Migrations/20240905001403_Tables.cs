using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaBraz.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "company",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "UUID", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    name = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: true),
                    cnpj = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    address = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: true),
                    phone = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: true),
                    email = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    subdomain = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    created_at = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_at = table.Column<DateTime>(type: "TIMESTAMP", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_company", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "product_type",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "UUID", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    name = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    type = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "VARCHAR(500)", maxLength: 500, nullable: true),
                    created_at = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_at = table.Column<DateTime>(type: "TIMESTAMP", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "UUID", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    name = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    whatsapp_number = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: true),
                    email = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    company_id = table.Column<Guid>(type: "UUID", nullable: false),
                    created_at = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_at = table.Column<DateTime>(type: "TIMESTAMP", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer", x => x.id);
                    table.ForeignKey(
                        name: "FK_customer_company_company_id",
                        column: x => x.company_id,
                        principalTable: "company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "UUID", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    name = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    password = table.Column<string>(type: "VARCHAR(256)", maxLength: 256, nullable: false),
                    role = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    company_id = table.Column<Guid>(type: "UUID", nullable: false),
                    created_at = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_at = table.Column<DateTime>(type: "TIMESTAMP", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                    table.ForeignKey(
                        name: "FK_User_Company",
                        column: x => x.company_id,
                        principalTable: "company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "UUID", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    product_type_id = table.Column<Guid>(type: "UUID", nullable: false),
                    company_id = table.Column<Guid>(type: "UUID", nullable: false),
                    name = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "VARCHAR(500)", maxLength: 500, nullable: true),
                    price = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    created_at = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_at = table.Column<DateTime>(type: "TIMESTAMP", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.id);
                    table.ForeignKey(
                        name: "FK_product_company_company_id",
                        column: x => x.company_id,
                        principalTable: "company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_product_product_type_product_type_id",
                        column: x => x.product_type_id,
                        principalTable: "product_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "customer_address",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "UUID", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    customer_id = table.Column<Guid>(type: "UUID", nullable: false),
                    street = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    number = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: true),
                    complement = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: true),
                    neighborhood = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    city = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    state = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    zip_code = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    created_at = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_at = table.Column<DateTime>(type: "TIMESTAMP", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer_address", x => x.id);
                    table.ForeignKey(
                        name: "FK_customer_address_customer_customer_id",
                        column: x => x.customer_id,
                        principalTable: "customer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "customer_tokens",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "UUID", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    customer_id = table.Column<Guid>(type: "UUID", nullable: false),
                    token = table.Column<Guid>(type: "UUID", nullable: false),
                    token_created_at = table.Column<DateTime>(type: "TIMESTAMP", nullable: false),
                    token_expires_at = table.Column<DateTime>(type: "TIMESTAMP", nullable: false),
                    is_used = table.Column<bool>(type: "BOOLEAN", nullable: false),
                    created_at = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_at = table.Column<DateTime>(type: "TIMESTAMP", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer_tokens", x => x.id);
                    table.ForeignKey(
                        name: "FK_customer_tokens_customer_customer_id",
                        column: x => x.customer_id,
                        principalTable: "customer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "order",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "UUID", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    customer_id = table.Column<Guid>(type: "UUID", nullable: false),
                    company_id = table.Column<Guid>(type: "UUID", nullable: false),
                    date = table.Column<DateTime>(type: "TIMESTAMP", nullable: false),
                    status = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    total = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    created_at = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_at = table.Column<DateTime>(type: "TIMESTAMP", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order", x => x.id);
                    table.ForeignKey(
                        name: "FK_order_company_company_id",
                        column: x => x.company_id,
                        principalTable: "company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_order_customer_customer_id",
                        column: x => x.customer_id,
                        principalTable: "customer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "order_items",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "UUID", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    order_id = table.Column<Guid>(type: "UUID", nullable: false),
                    product_id = table.Column<Guid>(type: "UUID", nullable: false),
                    quantity = table.Column<int>(type: "INT", nullable: false),
                    unit_price = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    created_at = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_at = table.Column<DateTime>(type: "TIMESTAMP", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_items", x => x.id);
                    table.ForeignKey(
                        name: "FK_order_items_order_order_id",
                        column: x => x.order_id,
                        principalTable: "order",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_order_items_product_product_id",
                        column: x => x.product_id,
                        principalTable: "product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_customer_company_id",
                table: "customer",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_customer_email",
                table: "customer",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_customer_address_customer_id",
                table: "customer_address",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_customer_tokens_customer_id",
                table: "customer_tokens",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_company_id",
                table: "order",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_customer_id",
                table: "order",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_items_order_id",
                table: "order_items",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_items_product_id",
                table: "order_items",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_company_id",
                table: "product",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_product_type_id",
                table: "product",
                column: "product_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_company_id",
                table: "user",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_email",
                table: "user",
                column: "email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customer_address");

            migrationBuilder.DropTable(
                name: "customer_tokens");

            migrationBuilder.DropTable(
                name: "order_items");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "order");

            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "customer");

            migrationBuilder.DropTable(
                name: "product_type");

            migrationBuilder.DropTable(
                name: "company");
        }
    }
}
