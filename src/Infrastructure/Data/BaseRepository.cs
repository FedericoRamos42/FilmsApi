using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {

        private readonly ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            
        }
        public async Task<T?> GetById(int id)
        {
           return await _context.Set<T>().FindAsync(id);
        }
        public async Task<IEnumerable<T>> GetAll()
        {
           return await _context.Set<T>().ToListAsync();
        }

        public async Task Insert(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();

        }
        public async Task Update(T entity)
        {
             _context.Set<T>().Update(entity);
             await _context.SaveChangesAsync();
        }
        public async Task Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();

        }

    }
}
