using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Pocos
{
    [Table("FactureFournisseur")]
    public class FactureFournisseur
    {
        [Key]
        public int IdFactureFournisseur { get; set; }

        [Required]
        public EnteteFactureFournisseur EnteteFactureFournisseur { get; set; }

        [ForeignKey("IdLigneFactureFournisseur")]
        public ICollection<LigneFactureFournisseur> LigneFactureFournisseur { get; set; }

    }
}
