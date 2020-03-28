using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SellerPoint.Models
{
    
    public class Config
    {
        [key]
        public int id { get; set; }
        public int DeliveryCharge { get; set; }
        public string ReceiptName { get; set; }
        public string ChalanName { get; set; }
        public string DefaultWarehouse { get; set; }
        public int DealerPriceChange { get; set; }
    }
}
