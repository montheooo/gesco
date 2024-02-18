using Entities.DTO;
using Entities.Pocos;
using Gesco_DataAccess;
using Gesco_Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Gesco_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvoicesController : ControllerBase
    {
        private readonly ILogger<InvoicesController> _logger;
        private readonly IGlobalRepository<LigneFacture> _facturepository = new GlobalRepositoryImpl<LigneFacture>();

        public InvoicesController(ILogger<InvoicesController> logger)
        {
            _logger = logger;
        } 
        [HttpGet]
        public ActionResult<Facture> Get()

        {
            var facturesDTo = new List<FactureDTO>();

            var ligneFactureList = _facturepository.GetAll(lignefac => lignefac.Facture.EnteteFacture, lignefac => lignefac.Produit, lignefac => lignefac.Facture.EnteteFacture.Client);

            var factureList = ligneFactureList.DistinctBy(ligne => ligne.IdFacture).ToList();


            foreach (var item in factureList)
            {
                var factureDTo = new FactureDTO();

                factureDTo.dateFacture = item.Facture.EnteteFacture.DateFacture;
                factureDTo.referenceFacture = item.Facture.ReferenceFacture;
                factureDTo.numeroFacture = item.IdFacture;
                factureDTo.nomClient = item.Facture.EnteteFacture.Client.NomClient;

                

                foreach (var item1 in ligneFactureList)
                {

                    if (factureDTo.numeroFacture == item1.IdFacture)
                    {
                        var ligneFactureDTO = new LigneFactureDTO();

                        ligneFactureDTO.prixUnitaire = item1.Prix;
                        ligneFactureDTO.quantite = item1.Quantite;
                        ligneFactureDTO.nomArticle = item1.Produit.NomProduit;

                        factureDTo.ligneFactures.Add(ligneFactureDTO); 
                    }
                }

                facturesDTo.Add(factureDTo);
            }

            _logger.LogInformation("Toutes les Factures recuperer", facturesDTo.ToString());

            return new OkObjectResult(facturesDTo);
        }

      
    }
}
