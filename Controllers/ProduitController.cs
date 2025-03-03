using Microsoft.AspNetCore.Mvc;
using Project2_Brydel.Models;
using Project2_Brydel.Repositories;
using System.Threading.Tasks;

namespace Project2_Brydel.Controllers
{
    public class ProduitController : Controller
    {
        private readonly IRepository<Produit> _produitRepository;

        public ProduitController(IRepository<Produit> produitRepository)
        {
            _produitRepository = produitRepository;
        }

        public async Task<IActionResult> Index()
        {
            var produits = await _produitRepository.GetAllAsync();
            return View(produits);
        }

        public async Task<IActionResult> Details(int id)
        {
            var produit = await _produitRepository.GetByIdAsync(id);
            if (produit == null)
            {
                return NotFound();
            }
            return View(produit);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Produit produit)
        {
            if (ModelState.IsValid)
            {
                await _produitRepository.AddAsync(produit);
                return RedirectToAction(nameof(Index));
            }
            return View(produit);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var produit = await _produitRepository.GetByIdAsync(id);
            if (produit == null)
            {
                return NotFound();
            }
            return View(produit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Produit produit)
        {
            if (id != produit.ProduitId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _produitRepository.UpdateAsync(produit);
                return RedirectToAction(nameof(Index));
            }
            return View(produit);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var produit = await _produitRepository.GetByIdAsync(id);
            if (produit == null)
            {
                return NotFound();
            }

            return View(produit);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _produitRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
