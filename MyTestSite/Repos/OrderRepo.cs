using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyTestSite.Models;
using System.Data.Entity;
using System.Threading.Tasks;

namespace MyTestSite.Repos
{
    public class OrderRepo : BaseRepo<Order>, IDatabaseRepo<Order>, IDisposable
    {

        public OrderRepo()
        {
            Table = Context.Orders;
        }


        public Task<int> DeleteAsync(int id)
        {
            Context.Entry(new Order() { OrderId = id }).State = EntityState.Deleted;
            return Context.SaveChangesAsync();
        }

        public int Delete(int id)
        {
            Context.Entry(new Order() { OrderId = id }).State = EntityState.Deleted;
            return Context.SaveChanges();
        }
    }

}
