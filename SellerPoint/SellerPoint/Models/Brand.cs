using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SellerPoint.Models
{
    public class Brand
    {
        [Key]
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Remarks { get; set; }
        public string ContactPersonName { get; set; }
        public string Country { get; set; }
        public string MadeInCountry { get; set; }
        public string Email { get; set; }
        public int BrandCode { get; set; }
    }
}
