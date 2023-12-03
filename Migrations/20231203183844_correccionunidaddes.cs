using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaEstacion.Migrations
{
    public partial class correccionunidaddes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UnidadMedida",
                table: "Unidades",
                newName: "Unidad");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Unidad",
                table: "Unidades",
                newName: "UnidadMedida");
        }
    }
}
