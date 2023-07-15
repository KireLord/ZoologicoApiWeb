using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZoologicoApiWeb.Migrations
{
    public partial class inicio1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Contrasena",
                table: "Registro",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Registro",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NombreUsuario",
                table: "Registro",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Contrasena",
                table: "Registro");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Registro");

            migrationBuilder.DropColumn(
                name: "NombreUsuario",
                table: "Registro");
        }
    }
}
