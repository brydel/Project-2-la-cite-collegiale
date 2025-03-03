using Project2_Brydel.Models;
using Microsoft.EntityFrameworkCore;
using Project2_Brydel.Data;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Project2_Brydel.Repositories
{
    public class ClientDAO : IRepository<Client>
    {
        private readonly AppDbContext _context;

        public ClientDAO(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Client> AddAsync(Client entity)
        {
            await _context.Clients.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Client> DeleteAsync(int id)
        {
            var entity = await _context.Clients.FindAsync(id);
            if (entity == null)
            {
                return entity;
            }

            _context.Clients.Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<IEnumerable<Client>> GetAllAsync()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<Client> GetByIdAsync(int id)
        {
            return await _context.Clients.FindAsync(id);
        }

        public async Task<Client> UpdateAsync(Client entity)
        {
            _context.Clients.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
