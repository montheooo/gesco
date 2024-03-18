using Entities.DTO.client;
using Entities.Pocos;
using Gesco_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Gesco_DataAccess
{
    public class InvoicesRepositoryImpl : IinvoicesRepository
    {
        private readonly GescoDbContext _gescoDbContext = new GescoDbContext();

       
        public void addInvoice(FactureDTOClient invoice)
        {
            using var transaction = _gescoDbContext.Database.BeginTransaction();

            try
            {
                Facture facture = new Facture();

                facture.ReferenceFacture = invoice.invoiceReference;

                _gescoDbContext.Add(facture);
                _gescoDbContext.SaveChanges();

                facture.LigneFacture = new List<LigneFacture>();

                EnteteFacture enteteFacture = new EnteteFacture();
                enteteFacture.DateFacture = invoice.invoiceDate;
                enteteFacture.Facture = facture;
                enteteFacture.Client = _gescoDbContext.Clients.SingleOrDefault((c) => c.IdClient == invoice.client.IdClient);
                enteteFacture.Status = invoice.status;

                _gescoDbContext.Add(enteteFacture);
                _gescoDbContext.SaveChanges();

                foreach (var item in invoice.invoiceLines)
                {
                    var ligne = new LigneFacture();

                    _gescoDbContext.Add(ligne);
                   

                    ligne.Facture = facture;
                    ligne.Produit = _gescoDbContext.Produits.SingleOrDefault((p) => p.IdProduit == item.article.IdProduit);
                    ligne.Depot = _gescoDbContext.Depot.SingleOrDefault((d) => d.IdDepot == item.depot.IdDepot);
                    ligne.Quantite = item.quantite;
                    ligne.Prix = item.prix_unitaire;
                    ligne.Montant = item.quantite * item.prix_unitaire;

                    _gescoDbContext.SaveChanges();

                    facture.LigneFacture.Add(ligne);
                }

                _gescoDbContext.SaveChanges();

                transaction.Commit();
            }
            catch (Exception e)
            {

                transaction.Rollback();
            }
        }
    }
}
