using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Pocos
{
    [Table("Stock")]
    public class Stock
    {
        [Key]
        public int IdStock { get; set; }

        [Required]
        public DateTime DateMouvement { get; set; }

        [Required]
        public String Sens { get; set; }

        [Required]
        [ForeignKey("IdLigneFacture")]
        public LigneFacture LigneFacture { get; set; }

      
    }
}
