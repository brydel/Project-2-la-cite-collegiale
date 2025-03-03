using Microsoft.EntityFrameworkCore;
using Project2_Brydel.Data;
using Project2_Brydel.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Project2_Brydel.Repositories
{
    public class ProduitDAO : IRepository<Produit>
    {
        private readonly AppDbContext _context;

        public ProduitDAO(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Produit> GetByIdAsync(int id)
        {
            return await _context.Produits.FindAsync(id);
        }

        public async Task<IEnumerable<Produit>> GetAllAsync()
        {
            return await _context.Produits.ToListAsync();
        }

        public async Task<Produit> AddAsync(Produit entity)
        {
            await _context.Produits.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Produit> UpdateAsync(Produit entity)
        {
            _context.Produits.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Produit> DeleteAsync(int id)
        {
            var entity = await _context.Produits.FindAsync(id);
            if (entity == null)
            {
                return entity;
            }

            _context.Produits.Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
