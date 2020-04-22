using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SellerPoint.Models.ViewModels
{
    public class PurchaseListViewModel
    {
        public int? KeywordId { get; set; }
        public string Keyword { get; set; }
        [DataType(DataType.Date)]
        [DisplayName ("From Date")]
        public DateTime? FromDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("To Date")]
        public DateTime? ToDate { get; set; }
        [DisplayName("Suppliers")]
        public int? SupplierID { get; set; }
        [DisplayName("Warehouse")]
        public int? WarehouseID { get; set; }
        public List<Purchase> PurchasesList { get; set; }
    }
}
