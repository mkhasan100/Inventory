﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SellerPoint.Models
{
    public class DealerSale
    {
        [Key]
        public int Id { get; set; }


        [DisplayName("Dealer")]
        public int DealerId { get; set; }

        [DisplayName("Product")]
        public int ProductId { get; set; }

        [NotMapped]
        [DisplayName("Product")]
        public string ProductName { get; set; }

        [NotMapped]
        [DisplayName("Product Total")]
        public decimal ProductTotal { get; set; }

        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        [DisplayName("Discount Percent")]
        public float DiscountPercent { get; set; }

        public float Discount { get; set; }
        public decimal  Paid { get; set; }
        public decimal Due { get; set; }
        [DisplayName("WareHouse")]
        public int WarehouseId { get; set; }

        public string Remarks { get; set; }

    }
}