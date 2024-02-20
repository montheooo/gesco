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

        [StringLength(50)]
        public string StatusProduction { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        public decimal CoutProduction { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        public decimal CoutRevient { get; set; }


        [Column(TypeName = "decimal(5,2)")]
        public decimal PrixUnitaireRecommande { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal Quantite { get; set; }

        public int IdProduit { get; set; }

        [ForeignKey("IdProduit")]
        public Produit Produit { get; set; }

      
       
    }
}
