using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gesco_Repository.Migrations
{
    /// <inheritdoc />
    public partial class Init_Schema_Invoices_Management : Migration
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
                name: "Depot",
                columns: table => new
                {
                    IdDepot = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomDepot = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Depot", x => x.IdDepot);
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
                    IdFactureFournisseur = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactureFournisseur", x => x.IdFactureFournisseur);
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
                    PrixProduit = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    SuiviStock = table.Column<int>(type: "int", nullable: false)
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
                name: "StockEntree",
                columns: table => new
                {
                    IdStockEntree = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateMouvement = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sens = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockEntree", x => x.IdStockEntree);
                });

            migrationBuilder.CreateTable(
                name: "StockSortie",
                columns: table => new
                {
                    IdStockSortie = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateMouvement = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sens = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockSortie", x => x.IdStockSortie);
                });

            migrationBuilder.CreateTable(
                name: "EnteteFacture",
                columns: table => new
                {
                    IdEnteteFacture = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateFacture = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdFacture = table.Column<int>(type: "int", nullable: false),
                    IdClient = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
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
                        principalColumn: "IdFactureFournisseur",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnteteFactureFournisseur_Fournisseur_IdFournisseur",
                        column: x => x.IdFournisseur,
                        principalTable: "Fournisseur",
                        principalColumn: "IdFournisseur",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProduitDepot",
                columns: table => new
                {
                    IdProduitDepot = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateInventaire = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TypeInventaire = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdProduit = table.Column<int>(type: "int", nullable: false),
                    IdDepot = table.Column<int>(type: "int", nullable: false),
                    StockInitial = table.Column<decimal>(type: "decimal(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProduitDepot", x => x.IdProduitDepot);
                    table.ForeignKey(
                        name: "FK_ProduitDepot_Depot_IdDepot",
                        column: x => x.IdDepot,
                        principalTable: "Depot",
                        principalColumn: "IdDepot",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProduitDepot_Produit_IdProduit",
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
                    Quantite = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    Prix = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    IdProduit = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LigneFactureFournisseur", x => x.IdLigneFactureFournisseur);
                    table.ForeignKey(
                        name: "FK_LigneFactureFournisseur_FactureFournisseur_IdLigneFactureFournisseur",
                        column: x => x.IdLigneFactureFournisseur,
                        principalTable: "FactureFournisseur",
                        principalColumn: "IdFactureFournisseur",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LigneFactureFournisseur_ProduitFournisseur_IdProduit",
                        column: x => x.IdProduit,
                        principalTable: "ProduitFournisseur",
                        principalColumn: "IdProduit",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Production",
                columns: table => new
                {
                    IdProduction = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateDebutProduction = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateFinProduction = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdStockEntree = table.Column<int>(type: "int", nullable: false),
                    IdProduit = table.Column<int>(type: "int", nullable: false),
                    IdFactureFournisseur = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Production", x => x.IdProduction);
                    table.ForeignKey(
                        name: "FK_Production_FactureFournisseur_IdFactureFournisseur",
                        column: x => x.IdFactureFournisseur,
                        principalTable: "FactureFournisseur",
                        principalColumn: "IdFactureFournisseur",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Production_Produit_IdProduit",
                        column: x => x.IdProduit,
                        principalTable: "Produit",
                        principalColumn: "IdProduit",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Production_StockEntree_IdStockEntree",
                        column: x => x.IdStockEntree,
                        principalTable: "StockEntree",
                        principalColumn: "IdStockEntree",
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
                    IdStockSortie = table.Column<int>(type: "int", nullable: true),
                    IdDepot = table.Column<int>(type: "int", nullable: false),
                    Prix = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    Quantite = table.Column<decimal>(type: "decimal(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LigneFacture", x => x.IdLigneFacture);
                    table.ForeignKey(
                        name: "FK_LigneFacture_Depot_IdDepot",
                        column: x => x.IdDepot,
                        principalTable: "Depot",
                        principalColumn: "IdDepot",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_LigneFacture_StockSortie_IdStockSortie",
                        column: x => x.IdStockSortie,
                        principalTable: "StockSortie",
                        principalColumn: "IdStockSortie");
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
                name: "IX_LigneFacture_IdDepot",
                table: "LigneFacture",
                column: "IdDepot");

            migrationBuilder.CreateIndex(
                name: "IX_LigneFacture_IdFacture",
                table: "LigneFacture",
                column: "IdFacture");

            migrationBuilder.CreateIndex(
                name: "IX_LigneFacture_IdProduit_IdFacture",
                table: "LigneFacture",
                columns: new[] { "IdProduit", "IdFacture" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LigneFacture_IdStockSortie",
                table: "LigneFacture",
                column: "IdStockSortie",
                unique: true,
                filter: "[IdStockSortie] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_LigneFactureFournisseur_IdProduit",
                table: "LigneFactureFournisseur",
                column: "IdProduit");

            migrationBuilder.CreateIndex(
                name: "IX_Production_IdFactureFournisseur",
                table: "Production",
                column: "IdFactureFournisseur");

            migrationBuilder.CreateIndex(
                name: "IX_Production_IdProduit",
                table: "Production",
                column: "IdProduit");

            migrationBuilder.CreateIndex(
                name: "IX_Production_IdStockEntree",
                table: "Production",
                column: "IdStockEntree");

            migrationBuilder.CreateIndex(
                name: "IX_ProduitDepot_IdDepot",
                table: "ProduitDepot",
                column: "IdDepot");

            migrationBuilder.CreateIndex(
                name: "IX_ProduitDepot_IdProduit_IdDepot",
                table: "ProduitDepot",
                columns: new[] { "IdProduit", "IdDepot" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnteteFacture");

            migrationBuilder.DropTable(
                name: "EnteteFactureFournisseur");

            migrationBuilder.DropTable(
                name: "LigneFacture");

            migrationBuilder.DropTable(
                name: "LigneFactureFournisseur");

            migrationBuilder.DropTable(
                name: "Production");

            migrationBuilder.DropTable(
                name: "ProduitDepot");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Fournisseur");

            migrationBuilder.DropTable(
                name: "Facture");

            migrationBuilder.DropTable(
                name: "StockSortie");

            migrationBuilder.DropTable(
                name: "ProduitFournisseur");

            migrationBuilder.DropTable(
                name: "FactureFournisseur");

            migrationBuilder.DropTable(
                name: "StockEntree");

            migrationBuilder.DropTable(
                name: "Depot");

            migrationBuilder.DropTable(
                name: "Produit");
        }
    }
}
