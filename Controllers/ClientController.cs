using Microsoft.AspNetCore.Mvc;
using Project2_Brydel.Models;
using Project2_Brydel.Repositories;

namespace Project2_Brydel.Controllers
{
    public class ClientController : Controller
    {

        private readonly IRepository<Client> _clientRepository;

        public ClientController(IRepository<Client> clientRepository)
        {
            _clientRepository = clientRepository;
        }

        // afficher tout les clients

        public async Task<IActionResult> Index()
        {
            var clients = await _clientRepository.GetAllAsync();
            return View(clients);
        }


        // detail d'un client

        public async Task<IActionResult> Details(int id)
        {
            var client = await _clientRepository.GetByIdAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        // formulaire d'ajout d'un client

        public IActionResult Create()
        {
            return View();
        }

        // ajout d'un client a la base de donnees
        [HttpPost]
        public async Task<IActionResult> Create(Client client)
        {
            if (ModelState.IsValid)
            {
                await _clientRepository.AddAsync(client);
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

        // formulaire de modification d'un client

        public async Task<IActionResult> Edit(int id)
        {
            var client = await _clientRepository.GetByIdAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        // modification d'un client dans la base de donnees
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Client client)
        {
           

            if (ModelState.IsValid)
            {
                await _clientRepository.UpdateAsync(client);
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

        // confirmation de suppression d'un client

        public async Task<IActionResult> Delete(int id)
        {
            var client = await _clientRepository.GetByIdAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        // suppression d'un client de la base de donnees

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _clientRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
