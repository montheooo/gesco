using Entities.Pocos;
using Microsoft.EntityFrameworkCore;

namespace Gesco_Repository
{
    public class GescoDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<EnteteFacture> EnteteFactures { get; set; }
        public DbSet<EnteteFactureFournisseur> EnteteFacturesFournisseur { get; set; }
        public DbSet<Facture> Factures { get; set; }
        public DbSet<FactureFournisseur> FacturesFournisseur { get; set; }
        public DbSet<Fournisseur> Fournisseurs { get; set; }
        public DbSet<LigneFacture> LignesFactures { get; set; }
        public DbSet<LigneFactureFournisseur> LignesFacturesFournisseur { get; set; }
        public DbSet<Produit> Produits { get; set; }
        public DbSet<ProduitFournisseur> ProduitsFournisseur { get; set; }
        public DbSet<StockSortie> Stocks { get; set; }
        public DbSet<Depot> Depot { get; set; }
        public DbSet<ProduitDepot> ProduitDepot { get; set; }
        public DbSet<Production> Production { get; set; }
        public DbSet<StockEntree> StockEntree { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseMySql("server=localhost;database=gesco;user=gesco;password=gesco");
            // optionsBuilder.UseMySql("server=localhost;user=gesco;password=gesco;database=gesco", ServerVersion.AutoDetect("server=localhost;user=gesco;password=gesco"));
            optionsBuilder.UseSqlServer("Data Source=POWERNEWLIFE\\SQL2022;Initial Catalog=gesco;Integrated Security=True;TrustServerCertificate=True");
        }

    }
}