using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Pocos
{
    [Table("Facture")]
    public class Facture
    {
        [Key]
        public int IdFacture { get; set; }

        [MaxLength(50)]
        public String  ReferenceFacture { get; set; }
        public EnteteFacture  EnteteFacture { get; set; }
        public virtual ICollection<LigneFacture>? LigneFacture { get; set; }

        
    }
}
