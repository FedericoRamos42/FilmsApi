using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T?> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        Task Insert(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
