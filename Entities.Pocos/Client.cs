using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Pocos
{
    [Table("Client")]
    public class Client
    {
        [Key]
        public int IdClient { get; set; }

        [Required]
        [MaxLength(50)]
        public String NomClient { get; set; }

        [MaxLength(50)]
        public String? AddresseClient { get; set;}
    }
}
