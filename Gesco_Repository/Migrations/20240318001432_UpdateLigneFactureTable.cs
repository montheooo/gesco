using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gesco_Repository.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLigneFactureTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LigneFacture_Depot_IdDepot",
                table: "LigneFacture");

            migrationBuilder.AlterColumn<int>(
                name: "IdDepot",
                table: "LigneFacture",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ReferenceFacture",
                table: "Facture",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LigneFacture_Depot_IdDepot",
                table: "LigneFacture",
                column: "IdDepot",
                principalTable: "Depot",
                principalColumn: "IdDepot");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LigneFacture_Depot_IdDepot",
                table: "LigneFacture");

            migrationBuilder.AlterColumn<int>(
                name: "IdDepot",
                table: "LigneFacture",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReferenceFacture",
                table: "Facture",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddForeignKey(
                name: "FK_LigneFacture_Depot_IdDepot",
                table: "LigneFacture",
                column: "IdDepot",
                principalTable: "Depot",
                principalColumn: "IdDepot",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
