using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class FactureDTO
    {
        public DateTime dateFacture { get; set; }
        public string nomClient { get; set; }
        public int numeroFacture { get; set; }
        public string referenceFacture { get; set; }
        public decimal montantFacture { get; set; }
        public List<LigneFactureDTO> ligneFactures { get; set; } = new List<LigneFactureDTO>() ;


    }
}
