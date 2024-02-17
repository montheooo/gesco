using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Pocos
{
    [Table("LigneFactureFournisseur")]
    public class LigneFactureFournisseur
    {
        [Key]
        public int IdLigneFactureFournisseur { get; set; }
        public int Quantite { get; set; }

        [ForeignKey("IdProduit")]
        public ProduitFournisseur ProduitFournisseur { get; set; }
        
        public FactureFournisseur FactureFournisseur { get; set; }
    }
}
