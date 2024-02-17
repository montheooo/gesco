using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gesco_Repository.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    IdClient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomClient = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AddresseClient = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.IdClient);
                });

            migrationBuilder.CreateTable(
                name: "Facture",
                columns: table => new
                {
                    IdFacture = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReferenceFacture = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facture", x => x.IdFacture);
                });

            migrationBuilder.CreateTable(
                name: "FactureFournisseur",
                columns: table => new
                {
                    IdFournisseur = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactureFournisseur", x => x.IdFournisseur);
                });

            migrationBuilder.CreateTable(
                name: "Fournisseur",
                columns: table => new
                {
                    IdFournisseur = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomFournisseur = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AddresseFournisseur = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fournisseur", x => x.IdFournisseur);
                });

            migrationBuilder.CreateTable(
                name: "Produit",
                columns: table => new
                {
                    IdProduit = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomProduit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PrixProduit = table.Column<decimal>(type: "decimal(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produit", x => x.IdProduit);
                });

            migrationBuilder.CreateTable(
                name: "ProduitFournisseur",
                columns: table => new
                {
                    IdProduit = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomProduit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PrixProduit = table.Column<decimal>(type: "decimal(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProduitFournisseur", x => x.IdProduit);
                });

            migrationBuilder.CreateTable(
                name: "EnteteFacture",
                columns: table => new
                {
                    IdEnteteFacture = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateFacture = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdFacture = table.Column<int>(type: "int", nullable: false),
                    IdClient = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnteteFacture", x => x.IdEnteteFacture);
                    table.ForeignKey(
                        name: "FK_EnteteFacture_Client_IdClient",
                        column: x => x.IdClient,
                        principalTable: "Client",
                        principalColumn: "IdClient",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnteteFacture_Facture_IdFacture",
                        column: x => x.IdFacture,
                        principalTable: "Facture",
                        principalColumn: "IdFacture",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnteteFactureFournisseur",
                columns: table => new
                {
                    IdEnteteFactureFournisseur = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdFactureFournisseur = table.Column<int>(type: "int", nullable: false),
                    DateFacture = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReferenceFactureFournisseur = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IdFournisseur = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnteteFactureFournisseur", x => x.IdEnteteFactureFournisseur);
                    table.ForeignKey(
                        name: "FK_EnteteFactureFournisseur_FactureFournisseur_IdFactureFournisseur",
                        column: x => x.IdFactureFournisseur,
                        principalTable: "FactureFournisseur",
                        principalColumn: "IdFournisseur",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnteteFactureFournisseur_Fournisseur_IdFournisseur",
                        column: x => x.IdFournisseur,
                        principalTable: "Fournisseur",
                        principalColumn: "IdFournisseur",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LigneFacture",
                columns: table => new
                {
                    IdLigneFacture = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProduit = table.Column<int>(type: "int", nullable: false),
                    IdFacture = table.Column<int>(type: "int", nullable: false),
                    Prix = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    Quantite = table.Column<decimal>(type: "decimal(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LigneFacture", x => x.IdLigneFacture);
                    table.ForeignKey(
                        name: "FK_LigneFacture_Facture_IdFacture",
                        column: x => x.IdFacture,
                        principalTable: "Facture",
                        principalColumn: "IdFacture",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LigneFacture_Produit_IdProduit",
                        column: x => x.IdProduit,
                        principalTable: "Produit",
                        principalColumn: "IdProduit",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LigneFactureFournisseur",
                columns: table => new
                {
                    IdLigneFactureFournisseur = table.Column<int>(type: "int", nullable: false),
                    Quantite = table.Column<int>(type: "int", nullable: false),
                    IdProduit = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LigneFactureFournisseur", x => x.IdLigneFactureFournisseur);
                    table.ForeignKey(
                        name: "FK_LigneFactureFournisseur_FactureFournisseur_IdLigneFactureFournisseur",
                        column: x => x.IdLigneFactureFournisseur,
                        principalTable: "FactureFournisseur",
                        principalColumn: "IdFournisseur",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LigneFactureFournisseur_ProduitFournisseur_IdProduit",
                        column: x => x.IdProduit,
                        principalTable: "ProduitFournisseur",
                        principalColumn: "IdProduit",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stock",
                columns: table => new
                {
                    IdStock = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateMouvement = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sens = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdLigneFacture = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => x.IdStock);
                    table.ForeignKey(
                        name: "FK_Stock_LigneFacture_IdLigneFacture",
                        column: x => x.IdLigneFacture,
                        principalTable: "LigneFacture",
                        principalColumn: "IdLigneFacture",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EnteteFacture_IdClient",
                table: "EnteteFacture",
                column: "IdClient");

            migrationBuilder.CreateIndex(
                name: "IX_EnteteFacture_IdFacture",
                table: "EnteteFacture",
                column: "IdFacture",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EnteteFactureFournisseur_IdFactureFournisseur",
                table: "EnteteFactureFournisseur",
                column: "IdFactureFournisseur",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EnteteFactureFournisseur_IdFournisseur",
                table: "EnteteFactureFournisseur",
                column: "IdFournisseur");

            migrationBuilder.CreateIndex(
                name: "IX_LigneFacture_IdFacture",
                table: "LigneFacture",
                column: "IdFacture");

            migrationBuilder.CreateIndex(
                name: "IX_LigneFacture_IdProduit",
                table: "LigneFacture",
                column: "IdProduit");

            migrationBuilder.CreateIndex(
                name: "IX_LigneFactureFournisseur_IdProduit",
                table: "LigneFactureFournisseur",
                column: "IdProduit");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_IdLigneFacture",
                table: "Stock",
                column: "IdLigneFacture");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnteteFacture");

            migrationBuilder.DropTable(
                name: "EnteteFactureFournisseur");

            migrationBuilder.DropTable(
                name: "LigneFactureFournisseur");

            migrationBuilder.DropTable(
                name: "Stock");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Fournisseur");

            migrationBuilder.DropTable(
                name: "FactureFournisseur");

            migrationBuilder.DropTable(
                name: "ProduitFournisseur");

            migrationBuilder.DropTable(
                name: "LigneFacture");

            migrationBuilder.DropTable(
                name: "Facture");

            migrationBuilder.DropTable(
                name: "Produit");
        }
    }
}
