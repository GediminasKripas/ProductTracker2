using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductTracker.Models
{
    public class ProductSupplierResponse
    {

        public long id { set; get; }
        public string itemName { set; get; }
        public double price { set; get; }
        public int? kCal { set; get; }
        public string? url { get; set; }
        public int supplierId { get; set; }
        public Supplier supplier { get; set; }

        public ProductSupplierResponse(Product product, Supplier supplier)
        {
            this.id = product.id;
            this.itemName = product.itemName;
            this.price = product.price;
            this.kCal = product.kCal;
            this.url = product.url;
            this.supplier = supplier;
        }

        public ProductSupplierResponse() { }

    }
}
