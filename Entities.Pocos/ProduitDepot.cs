using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Pocos
{
    [Table("ProduitDepot")]
    [Index("IdProduit", "IdDepot", IsUnique = true)]
    public class ProduitDepot
    {
        [Key]
        public int IdProduitDepot { get; set; }
        public DateTime DateInventaire { get; set; }
        public string TypeInventaire { get; set; }
        public String? Description { get; set; }
        public int IdProduit { get; set; }

        [ForeignKey("IdProduit")]
        public Produit Produit { get; set; }
        public int IdDepot { get; set; }

        [ForeignKey("IdDepot")]
        public Depot Depot { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal StockInitial { get; set; }
    }
}
