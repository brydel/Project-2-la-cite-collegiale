using Microsoft.AspNetCore.Mvc;
using Project2_Brydel.Models;
using Project2_Brydel.Repositories;
using System;
using System.Threading.Tasks;

namespace Project2_Brydel.Controllers
{
	public class CommandeController : Controller
	{
		private readonly IRepository<Commande> _commandeRepository;
		private readonly IRepository<Produit> _produitRepository;

		public CommandeController(IRepository<Commande> commandeRepository, IRepository<Produit> produitRepository)
		{
			_commandeRepository = commandeRepository;
			_produitRepository = produitRepository;
		}

		public async Task<IActionResult> Index()
		{
			var commandes = await _commandeRepository.GetAllAsync();
			return View(commandes);
		}

		public async Task<IActionResult> Details(int id)
		{
			var commande = await _commandeRepository.GetByIdAsync(id);
			if (commande == null)
			{
				return NotFound();
			}
			return View(commande);
		}

        
        public async Task<IActionResult> Create(int produitId)
        {
            var produit = await _produitRepository.GetByIdAsync(produitId);
            if (produit == null)
            {
                return NotFound();
            }

            var autresProduits = (await _produitRepository.GetAllAsync())
                                 .Where(p => p.ProduitId != produitId)
                                 .ToList();

            ViewBag.Produits = autresProduits;

            var commande = new Commande
            {
                ProduitId = produit.ProduitId,
                Produit = produit,
            };

            return View(commande);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Commande commande)
        {
            
            if (commande.ProduitId == 0)
            {
                ModelState.AddModelError("", "Produit non trouvé.");
                return View(commande);
            }

            var produit = await _produitRepository.GetByIdAsync(commande.ProduitId);
            if (produit == null)
            {
                ModelState.AddModelError("", "Le produit sélectionné n'existe pas.");
                return View(commande);
            }

            commande.Produit = produit;
            commande.DateCommande = DateTime.Now;

       
            await _commandeRepository.AddAsync(commande);

            return RedirectToAction(nameof(Confirm), new { id = commande.CommandeId });
        }



        public async Task<IActionResult> Edit(int id)
		{
			var commande = await _commandeRepository.GetByIdAsync(id);
			if (commande == null)
			{
				return NotFound();
			}

			
			commande.Produit = await _produitRepository.GetByIdAsync(commande.ProduitId);

			return View(commande);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id, Commande commande)
		{
			if (id != commande.CommandeId)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				await _commandeRepository.UpdateAsync(commande);
				return RedirectToAction(nameof(Index));
			}
			return View(commande);
		}

		public async Task<IActionResult> Delete(int id)
		{
			var commande = await _commandeRepository.GetByIdAsync(id);
			if (commande == null)
			{
				return NotFound();
			}
			return View(commande);
		}

		[HttpPost, ActionName("Delete")]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			await _commandeRepository.DeleteAsync(id);
			return RedirectToAction(nameof(Index));
		}

		//  Page de confirmation après commande
		public async Task<IActionResult> Confirm(int id)
		{
			var commande = await _commandeRepository.GetByIdAsync(id);
			if (commande == null) return NotFound();

			return View(commande);
		}
	}
}
