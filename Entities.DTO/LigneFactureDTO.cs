using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class LigneFactureDTO
    {
        public int idArticle { get; set; }
        public string nomArticle { get; set; }
        public string nomDepot { get; set; }
        public decimal prixUnitaire { get; set; }
        public decimal quantite { get; set; }
    }
}
