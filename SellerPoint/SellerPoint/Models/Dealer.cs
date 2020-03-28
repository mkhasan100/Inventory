using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SellerPoint.Models
{
    public class Dealer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string StreetAddress { get; set; }
        public string Area { get; set; }
        public string Thana { get; set; }
        public string District { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Remarks { get; set; }
        public string CompanyName { get; set; }
        public string ContactPersonName { get; set; }
    }
}
