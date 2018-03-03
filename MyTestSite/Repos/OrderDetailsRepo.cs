using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyTestSite.Models;
using System.Data.Entity;
using System.Threading.Tasks;

namespace MyTestSite.Repos
{
    public class OrderDetailsRepo : BaseRepo<OrderDetails>, IDatabaseRepo<OrderDetails>, IDisposable
    {

        public OrderDetailsRepo()
        {
            Table = Context.OrdersDetails;
        }


        public Task<int> DeleteAsync(int id)
        {
            Context.Entry(new OrderDetails() { OrderDetailsId = id }).State = EntityState.Deleted;
            return Context.SaveChangesAsync();
        }

        public int Delete(int id)
        {
            Context.Entry(new OrderDetails() { OrderDetailsId = id }).State = EntityState.Deleted;
            return Context.SaveChanges();
        }
    }
}
