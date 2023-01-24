using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.IRepository
{
    public interface IGenericRepository<T> where T : class 
    {
        Task<T> FindById(int id);
        Task<IEnumerable<T>> GetAll();
        Task<T> Add(T entity);
        Task Delete(T entity);
        Task Update(T entity);   
    }

}
