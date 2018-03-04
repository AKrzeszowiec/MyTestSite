using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyTestSite.Models;
using MyTestSite.Repos;
using Microsoft.AspNet.Identity;
using MyTestSite.Helpers;

namespace MyTestSite.Controllers
{
    public class CartController : Controller
    {
        private ProductRepo repo = new ProductRepo();
        private OrderProcessor orderProcessor = new OrderProcessor();
        // GET: Cart
        public RedirectToRouteResult AddToCart(int productId, string returnUrl)
        {
            Product product = repo.GetById(productId);
            if (product != null)
            {
                GetCart().AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(int productId, string returnUrl)
        {
            Product product = repo.GetById(productId);
            if (product != null)
            {
                GetCart().RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public ViewResult Index(string returnUrl)
        {
            return View(new CartViewModel
            {
                Cart = GetCart(),
                ReturnUrl = returnUrl
            });
        }

        public PartialViewResult Summary()
        {
            Cart cart = GetCart();
            return PartialView(cart);
        }

        [Authorize]
        public ViewResult Checkout()
        {
            int? shippingId = User.Identity.GetShippingDetails();
            ShippingDetails shippingDetails = new ShippingDetails();
            if (shippingId != null)
            {
                using (ShippingDetailsRepo shipRepo = new ShippingDetailsRepo())
                {
                    shippingDetails = shipRepo.GetById(shippingId);
                }

            }
 
            return View(shippingDetails);
        }

        [Authorize]
        [HttpPost]
        public ViewResult Checkout(ShippingDetails shippingDetails)
        {
            Cart cart = GetCart();
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }
            if (ModelState.IsValid)
            {
                int? shippingId = User.Identity.GetShippingDetails();
                string userId = User.Identity.GetUserId();
                orderProcessor.ProcessOrder(cart, shippingDetails, userId, shippingId);
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(shippingDetails);
            }
        }


        private Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
    }
}