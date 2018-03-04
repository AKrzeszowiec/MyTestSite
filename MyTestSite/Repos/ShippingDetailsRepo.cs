using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyTestSite.Models;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MyTestSite.Repos
{
    public class ShippingDetailsRepo : BaseRepo<ShippingDetails>, IDatabaseRepo<ShippingDetails>, IDisposable
    {

        public ShippingDetailsRepo()
        {
            Table = Context.ShippingsDetails;
        }


        public Task<int> DeleteAsync(int id)
        {
            Context.Entry(new ShippingDetails() { ShippingId = id }).State = EntityState.Deleted;
            return Context.SaveChangesAsync();
        }

        public int Delete(int id)
        {
            Context.Entry(new ShippingDetails() { ShippingId = id }).State = EntityState.Deleted;
            return Context.SaveChanges();
        }
    }
}