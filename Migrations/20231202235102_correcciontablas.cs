using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaEstacion.Migrations
{
    public partial class correcciontablas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductosVendidos_Ventas_VentaModelId",
                table: "ProductosVendidos");

            migrationBuilder.AlterColumn<int>(
                name: "VentaModelId",
                table: "ProductosVendidos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductosVendidos_Ventas_VentaModelId",
                table: "ProductosVendidos",
                column: "VentaModelId",
                principalTable: "Ventas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductosVendidos_Ventas_VentaModelId",
                table: "ProductosVendidos");

            migrationBuilder.AlterColumn<int>(
                name: "VentaModelId",
                table: "ProductosVendidos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductosVendidos_Ventas_VentaModelId",
                table: "ProductosVendidos",
                column: "VentaModelId",
                principalTable: "Ventas",
                principalColumn: "Id");
        }
    }
}
