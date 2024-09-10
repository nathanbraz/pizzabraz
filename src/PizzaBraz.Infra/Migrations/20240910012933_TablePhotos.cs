using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaBraz.Infra.Migrations
{
    /// <inheritdoc />
    public partial class TablePhotos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "role",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "role",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "permission",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "permission",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "phone",
                table: "company",
                type: "VARCHAR(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VARCHAR(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "cnpj",
                table: "company",
                type: "VARCHAR(14)",
                maxLength: 14,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "address",
                table: "company",
                type: "VARCHAR(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VARCHAR(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "customer_photo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "UUID", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    CustomerId = table.Column<Guid>(type: "UUID", nullable: false),
                    PhotoPath = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    FileName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    FileType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    IsMain = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer_photo", x => x.id);
                    table.ForeignKey(
                        name: "FK_customer_photo_customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "customer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "product_photo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "UUID", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    ProductId = table.Column<Guid>(type: "UUID", nullable: false),
                    PhotoPath = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    FileName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    FileType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    IsMain = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_photo", x => x.id);
                    table.ForeignKey(
                        name: "FK_product_photo_product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_photo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "UUID", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    UserId = table.Column<Guid>(type: "UUID", nullable: false),
                    PhotoPath = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    FileName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    FileType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    IsMain = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_photo", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_photo_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_customer_whatsapp_number",
                table: "customer",
                column: "whatsapp_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_company_cnpj",
                table: "company",
                column: "cnpj",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_company_email",
                table: "company",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_company_phone",
                table: "company",
                column: "phone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_company_subdomain",
                table: "company",
                column: "subdomain",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_customer_photo_CustomerId",
                table: "customer_photo",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_product_photo_ProductId",
                table: "product_photo",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_user_photo_UserId",
                table: "user_photo",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customer_photo");

            migrationBuilder.DropTable(
                name: "product_photo");

            migrationBuilder.DropTable(
                name: "user_photo");

            migrationBuilder.DropIndex(
                name: "IX_customer_whatsapp_number",
                table: "customer");

            migrationBuilder.DropIndex(
                name: "IX_company_cnpj",
                table: "company");

            migrationBuilder.DropIndex(
                name: "IX_company_email",
                table: "company");

            migrationBuilder.DropIndex(
                name: "IX_company_phone",
                table: "company");

            migrationBuilder.DropIndex(
                name: "IX_company_subdomain",
                table: "company");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "role");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "role");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "permission");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "permission");

            migrationBuilder.AlterColumn<string>(
                name: "phone",
                table: "company",
                type: "VARCHAR(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "cnpj",
                table: "company",
                type: "VARCHAR(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(14)",
                oldMaxLength: 14);

            migrationBuilder.AlterColumn<string>(
                name: "address",
                table: "company",
                type: "VARCHAR(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(255)",
                oldMaxLength: 255);
        }
    }
}
