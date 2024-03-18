using Entities.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.client
{
    public class FactureDTOClient
    {
        public Client client { get; set; }
        public string invoiceReference { get; set; }
        public DateTime invoiceDate { get; set; }
        public List<LigneFactureDTOClient> invoiceLines { get; set; }
        public string status { get; set; }
    }
}
