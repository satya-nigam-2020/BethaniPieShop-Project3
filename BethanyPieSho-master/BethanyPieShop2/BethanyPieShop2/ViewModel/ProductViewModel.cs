using BethanyPieShop2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BethanyPieShop2.ViewModel
{
    public class ProductViewModel
    {
        public ProductDetail ProductDetails { get; set; }
        public int Quantity { get; set; }
    }
}