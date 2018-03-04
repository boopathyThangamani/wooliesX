using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WooliesxAssignment.Models
{
    public class ShopperHistory
    {
        public int CustomerId { get; set; }
        public List<Product> Products { get; set; }
    }
}