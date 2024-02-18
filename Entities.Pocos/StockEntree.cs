using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Pocos
{
    [Table("StockEntree")]
     public class StockEntree
    {
        [Key]
        public int IdStockEntree { get; set; }
        public DateTime DateMouvement { get; set; }
        public string Sens { get; set; }
    }
}
