using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class AgregarRelacionProducto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductoId",
                table: "Inventario",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Inventario_ProductoId",
                table: "Inventario",
                column: "ProductoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventario_Productos_ProductoId",
                table: "Inventario",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventario_Productos_ProductoId",
                table: "Inventario");

            migrationBuilder.DropIndex(
                name: "IX_Inventario_ProductoId",
                table: "Inventario");

            migrationBuilder.DropColumn(
                name: "ProductoId",
                table: "Inventario");
        }
    }
}
