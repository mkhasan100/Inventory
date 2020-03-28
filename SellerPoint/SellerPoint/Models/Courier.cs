using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SellerPoint.Models
{
    public class Courier
    {
        [Key]
        public string ContactPersonName { get; set; }
        public string CourierShop { get; set; }
    }
}
