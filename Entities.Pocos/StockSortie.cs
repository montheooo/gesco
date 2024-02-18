using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Pocos
{
    [Table("StockSortie")]
    public class StockSortie
    {
        [Key]
        public int IdStockSortie { get; set; }

        [Required]
        public LigneFacture LigneFacture { get; set; }

        [Required]
        public DateTime DateMouvement { get; set; }

        [Required]
        public String Sens { get; set; }

       

      
    }
}
