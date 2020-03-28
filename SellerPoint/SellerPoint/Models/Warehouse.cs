using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SellerPoint.Models
{
    public class Warehouse
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string StreetAddress { get; set; }
        public string Area { get; set; }
        public string District { get; set; }
        public string IsMain { get; set; }
    }
}
