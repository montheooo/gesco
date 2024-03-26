using Entities.Pocos;
using Gesco_DataAccess;
using Gesco_Repository;
using Microsoft.AspNetCore.Mvc;

namespace Gesco_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProduitController : ControllerBase
    {
       

        private readonly ILogger<ProduitController> _logger;
        private readonly IGlobalRepository<Produit> _produitrepository;

        public ProduitController(ILogger<ProduitController> logger, IGlobalRepository<Produit> produitrepository)
        {
            _logger = logger;
            _produitrepository = produitrepository;
        }

        [HttpGet]
        [Route("{idproduit}")]
        public ActionResult<Produit> GetProduit(int idproduit)
        {
            var produit = _produitrepository.GetSingle(p => p.IdProduit == idproduit);

            _logger.LogInformation("Produit recuperer", produit.ToString());

            return new OkObjectResult(produit);
        }

        [HttpGet]
        public ActionResult<Produit> GetAllProduit(int idproduit)
        {
            var produitList = _produitrepository.GetAll();

            _logger.LogInformation("Tous les Produits recuperer", produitList.ToString());

            return new OkObjectResult(produitList);
        }
    }
}