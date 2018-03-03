using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTestSite.Repos
{
    interface IDatabaseRepo<T>
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int? id);
        Task<int> AddAsync(T entity);
        Task<int> AddRangeAsync(List<T> entities);
        Task<int> SaveAsync(T entity);
        Task<int> DeleteAsync(T entity);
        Task<int> DeleteAsync(int id);

    }
}
