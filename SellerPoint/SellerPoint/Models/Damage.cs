using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SellerPoint.Models
{
    public class Damage
    {
        [Key]
        public string WareHouse { get; set; }
        public string ProductDetial { get; set; }
        public string Quantity { get; set; }
    }
}
