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

        [StringLength(50)]
        public string ReferenceFacture { get; set; }

        public ICollection<LigneFactureFournisseur> LigneFactureFournisseur { get; set; }
        public int IdProduction { get; set; }

        [ForeignKey("IdProduction")]
        public Production Production { get; set; }

    }
}
