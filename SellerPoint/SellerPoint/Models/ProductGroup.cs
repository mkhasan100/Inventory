using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SellerPoint.Models
{
    public class ProductGroup
    {
        [Key]
        public string Name { get; set; }
    }
}
