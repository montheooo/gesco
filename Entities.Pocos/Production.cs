using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Pocos
{
    [Table("Production")]
    public class Production
    {
        [Key]
        public int IdProduction { get; set; }
        public DateTime DateDebutProduction { get; set; }
        public DateTime? DateFinProduction { get; set; }
        public int IdStockEntree { get; set; }
        public int IdProduit { get; set; }

        [ForeignKey("IdProduit")]
        public Produit Produit { get; set; }

        [ForeignKey("IdStockEntree")]
        public StockEntree StockEntree { get; set; }
        public int IdFactureFournisseur { get; set; }

        [ForeignKey("IdFactureFournisseur")]
        public FactureFournisseur FactureFournisseur { get; set; }


    }
}
