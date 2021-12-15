using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab5_Gadgets.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    customerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customerFName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    customerLName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    customerPhonenumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    customerEmail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer", x => x.customerID);
                });

            migrationBuilder.CreateTable(
                name: "salesRep",
                columns: table => new
                {
                    salesRepID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    salesRepFName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    salesRepLName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    salesRepExt = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_salesRep", x => x.salesRepID);
                });

            migrationBuilder.CreateTable(
                name: "appointment",
                columns: table => new
                {
                    appointmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    appointmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    salesRepID = table.Column<int>(type: "int", nullable: false),
                    salesRepFName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    salesRepLName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    customerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointment", x => x.appointmentID);
                    table.ForeignKey(
                        name: "FK_appointment_customer_customerID",
                        column: x => x.customerID,
                        principalTable: "customer",
                        principalColumn: "customerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_appointment_salesRep_salesRepID",
                        column: x => x.salesRepID,
                        principalTable: "salesRep",
                        principalColumn: "salesRepID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_appointment_customerID",
                table: "appointment",
                column: "customerID");

            migrationBuilder.CreateIndex(
                name: "IX_appointment_salesRepID",
                table: "appointment",
                column: "salesRepID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "appointment");

            migrationBuilder.DropTable(
                name: "customer");

            migrationBuilder.DropTable(
                name: "salesRep");
        }
    }
}
