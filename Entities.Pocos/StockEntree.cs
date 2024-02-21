using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Pocos
{
    [Table("StockEntree")]
     public class StockEntree
    {
        [Key]
        public int IdStockEntree { get; set; }
        public DateTime DateMouvement { get; set; }

        [StringLength(10)]
        public string Sens { get; set; }

        [StringLength(200)]
        public string Commentaire { get; set; }

        [Range(0, 100)]
        public int Quantite { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        public decimal Valeur { get; set; }

        public int IdProduit { get; set; }

        [ForeignKey("IdProduit")]
        public Produit Produit { get; set; }
    }
}
