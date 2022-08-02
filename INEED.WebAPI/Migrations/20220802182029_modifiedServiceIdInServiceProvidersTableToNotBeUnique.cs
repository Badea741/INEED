using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace INEED.WebAPI.Migrations
{
    public partial class modifiedServiceIdInServiceProvidersTableToNotBeUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "propertyCategories",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    title = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    parentId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_propertyCategories", x => x.id);
                    table.ForeignKey(
                        name: "propertyCategories_ibfk_1",
                        column: x => x.parentId,
                        principalTable: "propertyCategories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "serviceCategories",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    title = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    parentId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_serviceCategories", x => x.id);
                    table.ForeignKey(
                        name: "serviceCategories_ibfk_1",
                        column: x => x.parentId,
                        principalTable: "serviceCategories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "uniques",
                columns: table => new
                {
                    phoneNumber = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.phoneNumber);
                    table.UniqueConstraint("AK_uniques_email", x => x.email);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "properties",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    categoryId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    details = table.Column<string>(type: "text", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    price = table.Column<decimal>(type: "decimal(9,2)", precision: 9, scale: 2, nullable: false),
                    rate = table.Column<decimal>(type: "decimal(3,1)", precision: 3, scale: 1, nullable: true),
                    image = table.Column<byte[]>(type: "longblob", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_properties", x => x.id);
                    table.ForeignKey(
                        name: "properties_ibfk_1",
                        column: x => x.categoryId,
                        principalTable: "propertyCategories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    phoneNumber = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    name = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    latitude = table.Column<decimal>(type: "decimal(7,5)", precision: 7, scale: 5, nullable: true),
                    longitude = table.Column<decimal>(type: "decimal(8,5)", precision: 8, scale: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.phoneNumber);
                    table.ForeignKey(
                        name: "customers_ibfk_1",
                        column: x => x.phoneNumber,
                        principalTable: "uniques",
                        principalColumn: "phoneNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "customers_ibfk_2",
                        column: x => x.email,
                        principalTable: "uniques",
                        principalColumn: "email");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "serviceProviders",
                columns: table => new
                {
                    phoneNumber = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    name = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nationalId = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    rate = table.Column<decimal>(type: "decimal(3,1)", precision: 3, scale: 1, nullable: true),
                    serviceId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    latitude = table.Column<decimal>(type: "decimal(7,5)", precision: 7, scale: 5, nullable: false),
                    longitude = table.Column<decimal>(type: "decimal(8,5)", precision: 8, scale: 5, nullable: false),
                    profilePicture = table.Column<byte[]>(type: "longblob", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.phoneNumber);
                    table.ForeignKey(
                        name: "serviceProviders_ibfk_1",
                        column: x => x.serviceId,
                        principalTable: "serviceCategories",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "serviceProviders_ibfk_2",
                        column: x => x.phoneNumber,
                        principalTable: "uniques",
                        principalColumn: "phoneNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "serviceProviders_ibfk_3",
                        column: x => x.email,
                        principalTable: "uniques",
                        principalColumn: "email");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "messages",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    senderPhone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    receiverPhone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    content = table.Column<string>(type: "varchar(5000)", maxLength: 5000, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    time = table.Column<DateTime>(type: "datetime", nullable: false),
                    isSent = table.Column<bool>(type: "tinyint(1)", nullable: true, defaultValueSql: "'0'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_messages", x => x.id);
                    table.ForeignKey(
                        name: "messages_ibfk_1",
                        column: x => x.senderPhone,
                        principalTable: "customers",
                        principalColumn: "phoneNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "messages_ibfk_2",
                        column: x => x.receiverPhone,
                        principalTable: "serviceProviders",
                        principalColumn: "phoneNumber");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    customerPhone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    workerPhone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    content = table.Column<string>(type: "varchar(10000)", maxLength: 10000, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    time = table.Column<DateTime>(type: "datetime", nullable: false),
                    isSent = table.Column<bool>(type: "tinyint(1)", nullable: true, defaultValueSql: "'0'"),
                    image = table.Column<byte[]>(type: "longblob", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.id);
                    table.ForeignKey(
                        name: "orders_ibfk_1",
                        column: x => x.customerPhone,
                        principalTable: "customers",
                        principalColumn: "phoneNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "orders_ibfk_2",
                        column: x => x.workerPhone,
                        principalTable: "serviceProviders",
                        principalColumn: "phoneNumber",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateIndex(
                name: "email",
                table: "customers",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "receiverPhone",
                table: "messages",
                column: "receiverPhone");

            migrationBuilder.CreateIndex(
                name: "senderPhone",
                table: "messages",
                column: "senderPhone");

            migrationBuilder.CreateIndex(
                name: "customerPhone",
                table: "orders",
                column: "customerPhone");

            migrationBuilder.CreateIndex(
                name: "workerPhone",
                table: "orders",
                column: "workerPhone");

            migrationBuilder.CreateIndex(
                name: "categoryId",
                table: "properties",
                column: "categoryId");

            migrationBuilder.CreateIndex(
                name: "parentId",
                table: "propertyCategories",
                column: "parentId");

            migrationBuilder.CreateIndex(
                name: "parentId1",
                table: "serviceCategories",
                column: "parentId");

            migrationBuilder.CreateIndex(
                name: "email1",
                table: "serviceProviders",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_serviceProviders_serviceId",
                table: "serviceProviders",
                column: "serviceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "serviceId",
                table: "serviceProviders",
                column: "serviceId");

            migrationBuilder.CreateIndex(
                name: "email2",
                table: "uniques",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "phoneNumber",
                table: "uniques",
                column: "phoneNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "messages");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "properties");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "serviceProviders");

            migrationBuilder.DropTable(
                name: "propertyCategories");

            migrationBuilder.DropTable(
                name: "serviceCategories");

            migrationBuilder.DropTable(
                name: "uniques");
        }
    }
}
