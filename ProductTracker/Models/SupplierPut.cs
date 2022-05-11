using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductTracker.Models
{
    public class SupplierPut
    {
        //[JsonIgnore]
        public int id { get; set; }
        //[JsonProperty("surname")]
        public string surname { get; set; }
        //[JsonProperty("name")]
        public string name { get; set; }
        //[JsonProperty("number")]
        public string number { get; set; }
        //[JsonProperty("email")]
        public string email { get; set; }

        public SupplierPut(ProductSupplierResponse response)
        {
            Supplier supplier = response.supplier;
            id = supplier.id;
            surname = supplier.surname;
            name = supplier.surname;
            number = supplier.number;
            email = supplier.email;
        }

        public SupplierPut() { }
    }
}
