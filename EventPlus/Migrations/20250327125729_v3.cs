using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventoPlus.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Presenca_IdEvento",
                table: "Presenca");

            migrationBuilder.CreateIndex(
                name: "IX_Presenca_IdEvento",
                table: "Presenca",
                column: "IdEvento",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Presenca_IdEvento",
                table: "Presenca");

            migrationBuilder.CreateIndex(
                name: "IX_Presenca_IdEvento",
                table: "Presenca",
                column: "IdEvento");
        }
    }
}
