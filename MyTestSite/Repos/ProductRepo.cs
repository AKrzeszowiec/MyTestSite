﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyTestSite.Models;
using System.Data.Entity;
using System.Threading.Tasks;

namespace MyTestSite.Repos
{
    public class ProductRepo : BaseRepo<Product>, IDatabaseRepo<Product>, IDisposable
    {

        public ProductRepo()
        {
            Table = Context.Products;
        }


        public Task<int> DeleteAsync(int id)
        {
            Context.Entry(new Product(){ProductId = id}).State = EntityState.Deleted;
            return Context.SaveChangesAsync();
        }

        public int Delete(int id)
        {
            Context.Entry(new Product() { ProductId = id }).State = EntityState.Deleted;
            return Context.SaveChanges();
        }

    }
}