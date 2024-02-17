using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Pocos
{
    [Table("ProduitFournisseur")]
    public class ProduitFournisseur
    {
        [Key]
        public int IdProduit { get; set; }

        [Required]
        [StringLength(50)]
        public String NomProduit { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public Decimal PrixProduit { get; set; } = 0;
    }
}
