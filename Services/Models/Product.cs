using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceProject.Models
{
    public class Product
    {
        public int Stock { get; set; }
        public string MerchantProductNo { get; set; }
        public string Description { get; set; }
        public string Gtin { get;set; }
    }
}
