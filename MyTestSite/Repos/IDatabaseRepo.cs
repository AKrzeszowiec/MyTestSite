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
        List<T> GetAll();
        Task<T> GetByIdAsync(int? id);
        T GetById(int? id);
        Task<int> AddAsync(T entity);
        int Add(T entity);
        Task<int> AddRangeAsync(List<T> entities);
        int AddRange(List<T> entities);
        Task<int> SaveAsync(T entity);
        int Save(T entity);
        Task<int> DeleteAsync(T entity);
        int Delete(T entity);
        Task<int> DeleteAsync(int id);
        int Delete(int id);

    }
}
