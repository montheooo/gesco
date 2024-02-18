using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Pocos
{
    [Table("EnteteFacture")]
    public class EnteteFacture
    {
        [Key]
        public int IdEnteteFacture { get; set; }

        [Required]
        public DateTime DateFacture { get; set; }

        [Required]
        [ForeignKey("IdFacture")]
        public virtual Facture Facture { get; set; }
        
        [Required]
        [ForeignKey("IdClient")]
        public virtual Client Client { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }
    }
}
