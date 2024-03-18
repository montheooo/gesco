using Entities.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.client
{
    public class LigneFactureDTOClient
    {
        public Produit article { get; set; }
        public Depot depot { get; set; }
        public decimal prix_unitaire { get; set; }
        public decimal quantite { get; set; }
    }
}
