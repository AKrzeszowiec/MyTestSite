﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace MyTestSite.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [StringLength(20)]
        public string Category { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }

        public ICollection<OrderDetails> OrdersDetails { get; set; }
    }

    public enum ProductCategory
    {
        [Display(Name = "Potions")]
        potion,
        [Display(Name = "Artefacts")]
        artefact,
        [Display(Name ="Ointments")]
        ointment,
        [Display(Name = "Enchanted Items")]
        enchantedItem,
    }
}