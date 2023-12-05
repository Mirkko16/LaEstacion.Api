using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaEstacion.Migrations
{
    public partial class correccionModeloProdVendido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemCantidad",
                table: "ProductosVendidos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ItemCantidad",
                table: "ProductosVendidos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
