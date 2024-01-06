using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaEstacion.Migrations
{
    public partial class correccionProductos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserLogIn",
                table: "Usuarios",
                newName: "Username");

            migrationBuilder.AddColumn<decimal>(
                name: "StockMinimo",
                table: "Productos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StockMinimo",
                table: "Productos");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Usuarios",
                newName: "UserLogIn");
        }
    }
}
