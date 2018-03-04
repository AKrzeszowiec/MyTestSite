﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyTestSite.Models;
using MyTestSite.Repos;

namespace MyTestSite.Controllers
{
    public class CartController : Controller
    {
        private ProductRepo repo = new ProductRepo();
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

        public RedirectResult RemoveFromCart(int productId, string returnUrl)
        {
            Product product = repo.GetById(productId);
            if (product != null)
            {
                GetCart().RemoveLine(product);
            }
            return Redirect(returnUrl);
        }

        public ViewResult Index(string returnUrl)
        {
            return View(new CartViewModel
            {
                Cart = GetCart(),
                ReturnUrl = returnUrl
            });
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