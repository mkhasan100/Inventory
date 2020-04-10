using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SellerPoint.Models
{
    [Serializable]
    public class DealerSale
    {
        [Key]
        public int Id { get; set; }

        public string OrderNo { get; set; }


        [DisplayName("Dealer")]
        public int DealerId { get; set; }

        [DisplayName("Dealer")]
        [NotMapped]
        public string DealerName { get; set; }

        [DisplayName("Product")]
        public int ProductId { get; set; }

        [NotMapped]
        [DisplayName("Product")]
        public string ProductName { get; set; }

        [NotMapped]
        [DisplayName("Product Total")]
        public decimal ProductTotal { get; set; }


        [DisplayName("Product Total:")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }

        [DisplayName("Discount Percent")]
        public float? DiscountPercent { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Discount { get; set; }


        [DisplayName("Payable Total")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal payableTotal { get; set; }


        [Column(TypeName = "decimal(18,2)")]
        public decimal  Paid { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Due { get; set; }
        [DisplayName("WareHouse")]
        public int WarehouseId { get; set; }

        [NotMapped]
        [DisplayName("WareHouse")]
        public string WareHouseName { get; set; }

        public string Remarks { get; set; }

        internal static object GenerateDummyDealerSaleList()
        {
            throw new NotImplementedException();
        }
    }
}
