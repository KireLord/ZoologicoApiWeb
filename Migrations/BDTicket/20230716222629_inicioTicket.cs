using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZoologicoApiWeb.Migrations.BDTicket
{
    public partial class inicioTicket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddTickets",
                columns: table => new
                {
                    TicketId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Precio = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddTickets", x => x.TicketId);
                });

            migrationBuilder.CreateTable(
                name: "Promocion",
                columns: table => new
                {
                    PromoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaPromo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TicketId = table.Column<int>(type: "int", nullable: false),
                    AddTicketsTicketId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promocion", x => x.PromoId);
                    table.ForeignKey(
                        name: "FK_Promocion_AddTickets_AddTicketsTicketId",
                        column: x => x.AddTicketsTicketId,
                        principalTable: "AddTickets",
                        principalColumn: "TicketId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Promocion_AddTicketsTicketId",
                table: "Promocion",
                column: "AddTicketsTicketId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Promocion");

            migrationBuilder.DropTable(
                name: "AddTickets");
        }
    }
}
