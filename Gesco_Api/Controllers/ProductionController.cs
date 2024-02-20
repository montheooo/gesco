using Entities.DTO;
using Entities.Pocos;
using Gesco_DataAccess;
using Gesco_Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Gesco_Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductionController : ControllerBase
    {
        private readonly ILogger<ProductionController> _logger;
        private readonly IGlobalRepository<LigneFactureFournisseur> _productionpository = new GlobalRepositoryImpl<LigneFactureFournisseur>();

        public ProductionController(ILogger<ProductionController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<Facture> Get()

        {
            var productionsDTo = new List<ProductionDTO>();

            var ligneFactureList = _productionpository.GetAll(lignefac => lignefac.FactureFournisseur.EnteteFactureFournisseur, lignefac => lignefac.ProduitFournisseur, lignefac => lignefac.FactureFournisseur.EnteteFactureFournisseur.Fournisseur, lignefac => lignefac.FactureFournisseur.Production);

            var productionList = ligneFactureList.DistinctBy(ligne => ligne.FactureFournisseur.Production.IdProduction).ToList();

            var factureList = ligneFactureList.DistinctBy(ligne => ligne.FactureFournisseur.IdFactureFournisseur).ToList();

            foreach (var item in productionList)
            {
                var productionDTo = new ProductionDTO();

                productionDTo.DateDebutProduction = item.FactureFournisseur.Production.DateDebutProduction;
                productionDTo.CoutProduction = 0;
                productionDTo.IdProduction = item.FactureFournisseur.IdProduction;
                productionDTo.Status = item.FactureFournisseur.Production.StatusProduction;
                productionDTo.CoutRevient = 0;
                productionDTo.FacturesProduction = new List<FactureProductionDTO>();


                foreach (var item1 in factureList)
                {
                    

                    if (productionDTo.IdProduction == item1.FactureFournisseur.IdProduction)
                    {
                        var FactureDTO = new FactureProductionDTO();

                        FactureDTO.DateFacture = item1.FactureFournisseur.EnteteFactureFournisseur.DateFacture;
                        FactureDTO.NomFournisseur = item1.FactureFournisseur.EnteteFactureFournisseur.Fournisseur.NomFournisseur;
                        FactureDTO.NumeroFacture = item1.FactureFournisseur.IdFactureFournisseur;
                        FactureDTO.ReferenceFacture = item1.FactureFournisseur.ReferenceFacture;
                        FactureDTO.LignesFactureProductionDTO = new List<LigneFactureProductionDTO>();

                        foreach (var item2 in ligneFactureList)
                        {
                            if (FactureDTO.NumeroFacture == item2.FactureFournisseur.IdFactureFournisseur)
                            {
                                var ligneDTO = new LigneFactureProductionDTO();

                                ligneDTO.idArticle = item2.IdProduit;
                                ligneDTO.nomArticle = item2.ProduitFournisseur.NomProduit;
                                ligneDTO.quantite = item2.Quantite;
                                ligneDTO.prixUnitaire = item2.Prix;

                                FactureDTO.LignesFactureProductionDTO.Add(ligneDTO);
                            }
                        }
                        productionDTo.FacturesProduction.Add(FactureDTO);
                    }

                   

                    
                    
                }

              

                productionsDTo.Add(productionDTo);
            }

            _logger.LogInformation("Toutes les Factures recuperer", productionsDTo.ToString());

            return new OkObjectResult(productionsDTo);

        }


        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
