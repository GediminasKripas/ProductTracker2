using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductTracker.Models
{
    public class Supplier
    {
        public int id { get; set; }
        public string surname { get; set; }
        public string name { get; set; }
        public string number { get; set; }
        public string email { get; set; }

       public Supplier(ProductSupplierResponse response)
        {
            Supplier supplier = response.supplier;
            id = supplier.id;
            surname = supplier.surname;
            name = supplier.surname;
            number = supplier.number;
            email = supplier.email;
        }

        public Supplier() { }

    }
}
