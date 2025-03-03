﻿// Interface Generique
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Project2_Brydel.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(int id);

    }
}
