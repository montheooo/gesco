using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Pocos
{
    [Table("Depot")]
    public class Depot
    {
        [Key]
        public int IdDepot { get; set; }
        public string NomDepot { get; set; }

       
    }
}
