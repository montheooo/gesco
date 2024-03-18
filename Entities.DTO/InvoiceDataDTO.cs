using Entities.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class InvoiceDataDTO
    {
        public List<Client> Clients { get; set; }
        public List<Produit> Articles { get; set; }
        public List<Depot> Depots { get; set; }
    }
}
