using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyTestSite.Models;
using Microsoft.AspNet.Identity;
using MyTestSite.Helpers;


namespace MyTestSite.Repos
{
    public class OrderProcessor
    {
        public void ProcessOrder(Cart cart, ShippingDetails shippingInfo, string userId, int? shippingId)
        {
            int orderId;
            int currentShippingId;
            using (ShippingDetailsRepo shipRepo = new ShippingDetailsRepo())
            {

                if (shippingId==null)
                {
                    shipRepo.Add(shippingInfo);
                    currentShippingId = shippingInfo.ShippingId;
                }
                else
                {
                    currentShippingId = (int)shippingId;
                    shippingInfo.ShippingId = currentShippingId;
                    shipRepo.Save(shippingInfo);
                }
            }
            using(OrderRepo orderRepo = new OrderRepo())
            {
                Order newOrder = new Order() { Id = userId, Bill = cart.ComputeTotalValue(), ShippingId = currentShippingId };
                orderRepo.Add(newOrder);
                orderId = newOrder.OrderId;
            }
            using(OrderDetailsRepo detailsRepo = new OrderDetailsRepo())
            {
                foreach(CartLine line in cart.Lines)
                {
                    detailsRepo.Add(new OrderDetails() { OrderId = orderId, ProductId = line.Product.ProductId, Quantity = line.Quantity});
                }

            }
        }
    }
}