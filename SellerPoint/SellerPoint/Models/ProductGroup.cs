using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SellerPoint.Models
{
    [Serializable]
    public class ProductGroup
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
