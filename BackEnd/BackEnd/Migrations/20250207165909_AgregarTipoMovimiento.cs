using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class AgregarTipoMovimiento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoMovimientoId",
                table: "Movimientos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TipoMovimiento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descripcion = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoMovimiento", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movimientos_TipoMovimientoId",
                table: "Movimientos",
                column: "TipoMovimientoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movimientos_TipoMovimiento_TipoMovimientoId",
                table: "Movimientos",
                column: "TipoMovimientoId",
                principalTable: "TipoMovimiento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movimientos_TipoMovimiento_TipoMovimientoId",
                table: "Movimientos");

            migrationBuilder.DropTable(
                name: "TipoMovimiento");

            migrationBuilder.DropIndex(
                name: "IX_Movimientos_TipoMovimientoId",
                table: "Movimientos");

            migrationBuilder.DropColumn(
                name: "TipoMovimientoId",
                table: "Movimientos");
        }
    }
}
