using DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        public GenericRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<T> Add(T entity)
        {
            await _db.AddAsync(entity);
            await _db.SaveChangesAsync();   

            return entity; 
        }

        public async Task Delete(T entity)
        {
            _db.Set<T>().Remove(entity);
            _db.SaveChangesAsync();
        }

        public async Task<T> FindById(int id)
        {
            return await _db.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _db.Set<T>().ToListAsync();
        }

        public async Task Update(T entity)
        {
            _db.Set<T>().Update(entity);
            await _db.SaveChangesAsync();
        }
    }
}
