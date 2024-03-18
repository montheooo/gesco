using Entities.DTO;
using Entities.DTO.client;
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
        private readonly IGlobalRepository<Produit> _produitrepository = new GlobalRepositoryImpl<Produit>();
        private readonly IGlobalRepository<Client> _clientrepository = new GlobalRepositoryImpl<Client>();
        private readonly IGlobalRepository<Depot> _depotrepository = new GlobalRepositoryImpl<Depot>();
        private readonly IinvoicesRepository _invoiceRepository = new InvoicesRepositoryImpl();

        public InvoicesController(ILogger<InvoicesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("add-invoice-data")]
        public ActionResult<Facture> GetInvoiceData()

        {
            var invoiceDataDTO = new InvoiceDataDTO();

            invoiceDataDTO.Articles = _produitrepository.GetAll().ToList();
            invoiceDataDTO.Clients = _clientrepository.GetAll().ToList();
            invoiceDataDTO.Depots = _depotrepository.GetAll().ToList();

            return new OkObjectResult(invoiceDataDTO);
        }

        [HttpPost]
        [Route("post-invoice")]
        public ActionResult PostInvoice([FromBody]  FactureDTOClient invoice )

        {
            try
            {
                _invoiceRepository.addInvoice(invoice);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
            }

            return Accepted();
        }

        [HttpGet]
        public ActionResult<Facture> Get()

        {
            var facturesDTo = new List<FactureDTO>();

            var ligneFactureList = _facturepository.GetAll(lignefac => lignefac.Facture.EnteteFacture, lignefac => lignefac.Produit, lignefac => lignefac.Facture.EnteteFacture.Client, lignefac => lignefac.Depot);

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
                        ligneFactureDTO.nomDepot = item1.Depot.NomDepot; 

                        factureDTo.ligneFactures.Add(ligneFactureDTO); 
                    }
                }

                factureDTo.montantFacture = factureDTo.ligneFactures.Sum(l => l.quantite * l.prixUnitaire);

                facturesDTo.Add(factureDTo);
            }

            _logger.LogInformation("Toutes les Factures recuperer", facturesDTo.ToString());

            return new OkObjectResult(facturesDTo);
        }

      
    }
}
