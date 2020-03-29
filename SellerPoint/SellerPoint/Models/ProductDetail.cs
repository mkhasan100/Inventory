using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SellerPoint.Models
{
    [Serializable]
    public class ProductDetail
    {
        [Key]
        public int Id { get; set; }
        public int CategoryId { get; set; }
        
        [NotMapped]
        public string Category { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public string ProductCode { get; set; }
        public int BarCode { get; set; }
        public string SalePrice { get; set; }
        public string DealerPrice { get; set; }
        public string CostPrice { get; set; }
        public string Type { get; set; }
        public string Color { get; set; }
        public string MinimumStockToNotify { get; set; }
        public string StartingInventory { get; set; }
        public string Purchased { get; set; }
        public string Sold { get; set; }
        public string OnHand { get; set; }
        
    }
}
