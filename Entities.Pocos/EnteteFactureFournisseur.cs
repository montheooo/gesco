using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Pocos
{
    [Table("EnteteFactureFournisseur")]
    public class EnteteFactureFournisseur
    {
        [Key]
        public int IdEnteteFactureFournisseur { get; set; }

        [Required]
        [ForeignKey("IdFactureFournisseur")]
        public FactureFournisseur FactureFournisseur { get; set; }

        [Required]
        public DateTime DateFacture { get; set; }

        [Required]
        [MaxLength(50)]
        public String ReferenceFactureFournisseur { get; set; }

        [Required]
        [ForeignKey("IdFournisseur")]
        public Fournisseur Fournisseur { get; set; }
    }
}
