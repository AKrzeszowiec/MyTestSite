using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyTestSite.Models;
using MyTestSite.Helpers;

namespace MyTestSite.Controllers
{
    public class NavController : Controller
    {
        // GET: Nav
        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;
            var categories = Enum.GetNames(typeof(ProductCategory)).Cast<string>().OrderBy(x => x);
            Dictionary<string,string> model = new Dictionary<string, string>();
            foreach (var link in categories)
            {
                Enum.TryParse(link, out ProductCategory myEnum);
                string name = myEnum.GetDisplayName();
                model.Add(link, name);
            }
            {
                return PartialView(model);
            }




        }
    }
}