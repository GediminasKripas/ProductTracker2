using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProductWebservice.Models
{
    public class Product
    {
        [JsonIgnore]
        public string id { get; set; }
        public string productName { get; set; }
        public double price { get; set; }
        public string date { get; set; }
    }
}
