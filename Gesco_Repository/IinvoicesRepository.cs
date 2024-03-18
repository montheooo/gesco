using Entities.DTO.client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gesco_Repository
{
    public interface IinvoicesRepository
    {
        void addInvoice(FactureDTOClient invoice);

    }
}
