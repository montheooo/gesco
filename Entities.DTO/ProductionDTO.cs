using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class ProductionDTO
    {
        public DateTime DateDebutProduction { get; set; }
        public decimal CoutProduction { get; set; }
        public decimal QuantiteProduction { get; set; }
        public decimal CoutRevient { get; set; }
        public string Status { get; set; }
        public int IdProduction { get; set; }
        public string Produit { get; set; }
        public List<FactureProductionDTO> FacturesProduction { get; set; }
    }
}
