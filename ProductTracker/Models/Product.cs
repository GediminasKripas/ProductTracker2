using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProductTracker.Models
{
    public class Product
    {
        public long id { set; get; }
        public string itemName { set; get; }
        public double price { set; get; }
        public int? kCal { set; get; }
        public string? url { get; set; }
        public int? supplierId { get; set; }

    }
}
