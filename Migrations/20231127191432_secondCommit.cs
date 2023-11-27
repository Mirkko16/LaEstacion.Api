using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaEstacion.Migrations
{
    public partial class secondCommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Familias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Eliminada = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Familias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Eliminada = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rubros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rubros", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Productos_FamiliaId",
                table: "Productos",
                column: "FamiliaId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_MarcaId",
                table: "Productos",
                column: "MarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_RubroId",
                table: "Productos",
                column: "RubroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Familias_FamiliaId",
                table: "Productos",
                column: "FamiliaId",
                principalTable: "Familias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Marcas_MarcaId",
                table: "Productos",
                column: "MarcaId",
                principalTable: "Marcas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Rubros_RubroId",
                table: "Productos",
                column: "RubroId",
                principalTable: "Rubros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Familias_FamiliaId",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Marcas_MarcaId",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Rubros_RubroId",
                table: "Productos");

            migrationBuilder.DropTable(
                name: "Familias");

            migrationBuilder.DropTable(
                name: "Marcas");

            migrationBuilder.DropTable(
                name: "Rubros");

            migrationBuilder.DropIndex(
                name: "IX_Productos_FamiliaId",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_MarcaId",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_RubroId",
                table: "Productos");
        }
    }
}
