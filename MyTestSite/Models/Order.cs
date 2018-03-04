using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MyTestSite.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        public string Id { get; set; }

        public decimal Bill { get; set; }

        public string ShippingId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public ShippingDetails ShippingDetails { get; set; }

        public ICollection<OrderDetails> OrdersDetails { get; set; }
    }
}