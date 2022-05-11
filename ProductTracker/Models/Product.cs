using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProductTracker.Models
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { set; get; }
        public string itemName { set; get; }
        public double price { set; get; }
        public int? kCal { set; get; }
        public string? url { get; set; }
        public int? supplierId { get; set; }

        public Product(ProductSupplierResponse response)
        {

            if(response.id != null)
            {
                id = (long)response.id;
            }

            itemName = response.itemName;
            price = response.price;
            kCal = response.kCal;
            url = response.url;
            supplierId = response.supplier.id;

        }

        public Product() { }

    }
}
