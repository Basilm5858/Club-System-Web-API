using Club_Management_System.Data;
using Club_Management_System.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Club_Management_System.Repos.Implementation
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly My_AppContext _context;
        public GenericRepo(My_AppContext context)
        {
            _context = context;
        }
        public async Task AddAsync(T item)
        {
            await _context.Set<T>().AddAsync(item);
        }

        public void Delete(T item)
        {
            _context.Set<T>().Remove(item);
        }

        public async Task<ICollection<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
    }
}
