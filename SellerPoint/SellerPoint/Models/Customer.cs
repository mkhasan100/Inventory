using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SellerPoint.Models
{
    public class Customer
    {
        [Key]
        public int MembershipCardNo { get; set; }
        public string Name { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public string NationalId { get; set; }
        public string Occupation { get; set; }
        public string Company { get; set; }
        public string Remarks { get; set; }
        public string IsActive { get; set; }
    }
}
