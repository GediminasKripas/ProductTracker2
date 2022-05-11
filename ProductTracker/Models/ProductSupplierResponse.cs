using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProductTracker.Models
{
    public class ProductSupplierResponse
    {
        public long? id { set; get; }
        public string itemName { set; get; }
        public double price { set; get; }
        public int? kCal { set; get; }
        public string? url { get; set; }
        public int? supplierId { get; set; }
        public Supplier supplier { get; set; }

        public ProductSupplierResponse(Product product, Supplier supplier)
        {
            id = product.id;
            itemName = product.itemName;
            price = product.price;
            kCal = product.kCal;
            url = product.url;
            supplierId = supplier.id;
            this.supplier = supplier;
        }
        public ProductSupplierResponse() { }

    }
}
