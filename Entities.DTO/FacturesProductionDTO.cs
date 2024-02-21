using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class FactureProductionDTO
    {
        public DateTime DateFacture { get; set; }
        public string ReferenceFacture { get; set; }
        public int IdFacture { get; set; }
        public int NumeroFacture { get; set; }
        public decimal MontantFacture { get; set; }
        public string NomFournisseur { get; set; }
        public List<LigneFactureProductionDTO> LignesFactureProduction { get; set; }
    }
}
