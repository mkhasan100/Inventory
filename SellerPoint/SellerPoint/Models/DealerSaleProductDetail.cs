using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SellerPoint.Models
{
    [Serializable]
    public class DealerSaleProductDetail
    {
        [Key]
        public int Id { get; set; }
        public int DealerSaleId { get; set; }
        public int ProductId { get; set; }
        public int UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int SaleTypeId { get; set; }


    }
}
