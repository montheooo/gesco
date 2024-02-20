using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Pocos
{
    [Table("Fournisseur")]
    public class Fournisseur
    {
        [Key]
        public int IdFournisseur { get; set; }

        [Required]
        [Column("NomFournisseur")]
        [MaxLength(50)]
        public String NomFournisseur { get; set; }

        [Column("AddresseFournisseur")]
        [MaxLength(50)]
        public String? AddresseFournisseur { get; set;}
    }
}
