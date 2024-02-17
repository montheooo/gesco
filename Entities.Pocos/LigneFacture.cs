using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Pocos
{
    [Table("LigneFacture")]
    public class LigneFacture
    {
        [Key]
        public int IdLigneFacture { get; set; }
        public int IdProduit { get; set; }

        [ForeignKey("IdProduit ")]
        public Produit Produit { get; set; }

        public int IdFacture { get; set; }

        [ForeignKey("IdFacture")]
        public Facture Facture { get; set; }


        [Column(TypeName = "decimal(5,2)")]
        public decimal Prix { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal Quantite { get; set; }

    }
}
