using Microsoft.EntityFrameworkCore;
using Project2_Brydel.Data;
using Project2_Brydel.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Project2_Brydel.Repositories
{
    public class CommandeDAO : IRepository<Commande>
    {
        private readonly AppDbContext _context;

        public CommandeDAO(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Commande> AddAsync(Commande entity)
        {
            await _context.Commandes.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Commande> DeleteAsync(int id)
        {
            var entity = await _context.Commandes.FindAsync(id);
            if (entity == null)
            {
                return entity;
            }

            _context.Commandes.Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<IEnumerable<Commande>> GetAllAsync()
        {
            return await _context.Commandes.ToListAsync();
        }

        public async Task<Commande> GetByIdAsync(int id)
        {
            return await _context.Commandes
                                 .Include(c => c.Produit) 
                                 .FirstOrDefaultAsync(c => c.CommandeId == id);
        }




        public async Task<Commande> UpdateAsync(Commande entity)
        {
            _context.Commandes.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
