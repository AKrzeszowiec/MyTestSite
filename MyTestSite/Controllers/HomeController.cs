using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyTestSite.Models;
using MyTestSite.Repos;
using MyTestSite.Helpers;

namespace MyTestSite.Controllers
{
    public class HomeController : Controller
    {
        private ProductRepo repo = new ProductRepo();
        public int PageSize = 5;
        public ActionResult Index(ProductCategory? category, int page = 1)
        {
            var UnorderedProducts = repo.GetAll();
            if (category != null)
            {
                UnorderedProducts = UnorderedProducts.Where(p => p.Category == category.ToString()).ToList();
            }
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = UnorderedProducts.OrderBy(p => p.ProductId).Skip((page - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo { CurrentPage = page, ItemsPerPage = PageSize, TotalItems = UnorderedProducts.Count() },
                CurrentCategory = category

            };
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}