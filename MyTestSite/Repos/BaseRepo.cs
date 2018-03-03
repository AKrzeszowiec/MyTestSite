using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyTestSite.Models;
using System.Data.Entity;
using System.Threading.Tasks;

namespace MyTestSite.Repos
{
    public class BaseRepo<T> : IDisposable where T:class, new()
    {

        public ApplicationDbContext Context { get; }  = new ApplicationDbContext();
        protected DbSet<T> Table;


        public Task<int> AddAsync(T entity)
        {
            Table.Add(entity);
            return Context.SaveChangesAsync();
        }

        public Task<int> AddRangeAsync(List<T> entities)
        {
            Table.AddRange(entities);
            return Context.SaveChangesAsync();
        }

        public Task<int> DeleteAsync(T entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
            return Context.SaveChangesAsync();
        }


        public Task<List<T>> GetAllAsync()
        {
            return Table.ToListAsync();
        }

        public Task<T> GetByIdAsync(int? id)
        {
            return Table.FindAsync(id);
        }

        public Task<int> SaveAsync(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return Context.SaveChangesAsync();
        }

        public List<T> GetAll()
        {
            return Table.ToList();
        }

        public T GetById(int? id)
        {
            return Table.Find(id);
        }

        public int Add(T entity)
        {
            Context.Entry(entity).State = EntityState.Added;
            return Context.SaveChanges();
        }

        public int AddRange(List<T> entities)
        {
            Table.AddRange(entities);
            return Context.SaveChanges();
        }

        public int Save(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return Context.SaveChanges();
        }

        public int Delete(T entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
            return Context.SaveChanges();
        }




        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    Context.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~TRepo() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }


        #endregion
    }
}
