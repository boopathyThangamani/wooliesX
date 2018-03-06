using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace WooliesxAssignment.Models
{
    public class TrolleyItems
    {
        [JsonProperty("products")]
        public List<TrollyProduct> products { get; set; }
        [JsonProperty("specials")]
        public List<Special> specials { get; set; }
        [JsonProperty("quantities")]
        public List<ProductQuantity> quantities { get; set; }
    }

    public class TrollyProduct
    {
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("price")]
        public double price { get; set; }
    }

    public class ProductQuantity
    {
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("quantity")]
        public double quantity { get; set; }
    }

    public class Special
    {
        [JsonProperty("quantities")]
        public List<ProductQuantity> quantities { get; set; }
        [JsonProperty("total")]
        public double total { get; set; }
    }
}