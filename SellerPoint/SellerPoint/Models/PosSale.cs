using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SellerPoint.Models
{
    public class PosSale
    {
        [KEY]
        public int Id { get; set; }
        public int? WarehouseId { get; set; }
        public string productId { get; set; }

        //Payments (How customer is paying)
        [DisplayName("Total Amount")]
        public int TotalAmount { get; set; }
        [DisplayName("Discount Percentage")]
        public float? DiscountPercentage { get; set; }
        [DisplayName("Discount Amount")]
        [Column(TypeName = "Decimal (18,2)")]
        public decimal? DiscountAmount { get; set; }
        [DisplayName("Payable Total")]
        [Column(TypeName = "Decimal (18,2)")]
        public decimal PayableTotal1 { get; set; }
        [DisplayName("Transaction Medium")]
        public string TransactionMedium { get; set; }
        public int? Wallets { get; set; }
        [DisplayName("Paying Amount")]
        public int? PayingAmount { get; set; }
        [DisplayName("Transaction Number")]
        public int? TransactionNumber { get; set; }
        public string Remarks { get; set; }

        //CustomerInfo
        public string CustomerInfo { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        [DisplayName("Street Address")]
        public string StreetAddress1 { get; set; }
        public string Addresses { get; set; }
        [DisplayName("Addresses Name")]
        public string AddressesName { get; set; }
        [DisplayName("Contact Name")]
        public string ContactName { get; set; }
        [DisplayName("Contact Phone")]
        public string ContactPhone { get; set; }
        [DisplayName("Street Address")]
        public string StreetAddress2 { get; set; }
        public string District { get; set; }
        public string Thana { get; set; }
        public string Area { get; set; }
        public string Postcode { get; set; }
        public string Country { get; set; }
        [DisplayName("Special Note")]
        public string SpecialNote { get; set; }

        //SummaryOfSale
        [DisplayName("Sale Total")]
        public string SaleTotal { get; set; }
        [Column(TypeName = "Decimal (18,2)")]
        public decimal? Discount { get; set; }
        [DisplayName("Payable Total")]
        [Column(TypeName = "Decimal (18,2)")]
        public decimal PayableTotal2 { get; set; }
        public decimal Paid { get; set; }
        public decimal Due { get; set; }
        [DisplayName("Given Amount")]
        public decimal GivenAmount { get; set; }
        [DisplayName("Change Amount")]
        public decimal ChangeAmount { get; set; }
        public string Remark { get; set; }
        [DisplayName("Order Reference Number")]
        public string OrderReferenceNumber { get; set; }

    }
}
