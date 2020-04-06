using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SellerPoint.Models
{
    public class Purchase
    {
        [Key]
        public int Id { get; set; }
        [DisplayName ("Account Head")]
        public int AccountHeadId { get; set; }
        [DisplayName ("Warehouse")]
        public int WarehouseId { get; set; }
        [DisplayName("Wallets")]
        public int WalletsId { get; set; }
        [DisplayName("Suppliers")]
        public int SupplierId { get; set; }

        [DataType(DataType.Date)]
        [DisplayName ("Purchase Order Date")]
        public DateTime PurchaseOrderDate { get; set; }
        [DisplayName("Order Number")]
        public int OrderNumber { get; set; }
       
        [DisplayName("Order Reference Number")]
        public int OrderReferenceNumber { get; set; }


        [DisplayName("Product Amount")]
        [Column(TypeName = "decimal(18,2)")]
        public Decimal ProductAmount { get; set; }

        [DisplayName("Other Amount")]
        [Column(TypeName = "decimal(18,2)")]
        public Decimal OtherAmount { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public Decimal Discount { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public Decimal Total { get; set; }


        [DisplayName("Shipping Provider")]
        public string ShippingProvider { get; set; }
        [DisplayName("Shipping Tracking Number")]
        public string ShippingTrackingNumber { get; set; }
        public string Remarks { get; set; }
    }
}
