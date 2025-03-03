using Microsoft.AspNetCore.Mvc;
using Project2_Brydel.Models;
using Project2_Brydel.Repositories;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Project2_Brydel.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository<Produit> _produitRepository;

        public HomeController(ILogger<HomeController> logger, IRepository<Produit> produitRepository)
        {
            _logger = logger;
            _produitRepository = produitRepository;
        }

        public async Task<IActionResult> Index()
        {
            var produits = await _produitRepository.GetAllAsync(); 
            return View(produits); 
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
