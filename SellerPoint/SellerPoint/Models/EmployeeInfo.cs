using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellerPoint.Models
{
    public class EmployeeInfo
    {
        [key]
        public int id { get; set; }
        public string Name { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public int Salary { get; set; }
        public int SaleTargetAmount { get; set; }
        public int SaleAchivedAmount { get; set; }

    }
}
