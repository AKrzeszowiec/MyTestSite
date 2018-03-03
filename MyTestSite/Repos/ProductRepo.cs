using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyTestSite.Models;
using System.Data.Entity;
using System.Threading.Tasks;

namespace MyTestSite.Repos
{
    public class ProductRepo : IDatabaseRepo<Product>, IDisposable
    {
        ApplicationDbContext Context = new ApplicationDbContext();
        DbSet<Product> Table;

        public ProductRepo()
        {
            Table = Context.Products;
        }

        public Task<int> AddAsync(Product entity)
        {
            Table.Add(entity);
            return Context.SaveChangesAsync();
        }

        public Task<int> AddRangeAsync(List<Product> entities)
        {
            Table.AddRange(entities);
            return Context.SaveChangesAsync();
        }

        public Task<int> DeleteAsync(Product entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
            return Context.SaveChangesAsync();
        }

        public Task<int> DeleteAsync(int id)
        {
            Context.Entry(new Product(){ProductId = id}).State = EntityState.Deleted;
            return Context.SaveChangesAsync();
        }

        public Task<List<Product>> GetAllAsync()
        {
            return Table.ToListAsync();
        }

        public Task<Product> GetByIdAsync(int? id)
        {
            return Table.FindAsync(id);
        }

        public Task<int> SaveAsync(Product entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return Context.SaveChangesAsync();
        }

        public List<Product> GetAll()
        {
            return Table.ToList();
        }

        public Product GetById(int? id)
        {
            return Table.Find(id);
        }

        public int Add(Product entity)
        {
            Context.Entry(entity).State = EntityState.Added;
            return Context.SaveChanges();
        }

        public int AddRange(List<Product> entities)
        {
            Table.AddRange(entities);
            return Context.SaveChanges();
        }

        public int Save(Product entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return Context.SaveChanges();
        }

        public int Delete(Product entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
            return Context.SaveChanges();
        }


        public int Delete(int id)
        {
            Context.Entry(new Product() { ProductId = id }).State = EntityState.Deleted;
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
        // ~ProductRepo() {
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