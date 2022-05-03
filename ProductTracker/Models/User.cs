using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProductTracker.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }
        [Required]
        public string name { get; set; }
        public string phoneNumber { get; set; }
        public List<Product> products { get; set; }
        public User()
        {
            products = new List<Product>();
        }

    }
}
