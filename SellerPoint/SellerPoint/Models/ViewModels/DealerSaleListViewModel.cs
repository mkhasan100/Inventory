using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SellerPoint.Models.ViewModels
{
    public class DealerSaleListViewModel
    {
        [DisplayName("Search Order")]
        public string SearchOrder { get; set; }

        [DisplayName("Warehouse")]
        public int WarehouseID { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("From Date")]
        public DateTime FromDate { get; set; }


        [DataType(DataType.Date)]
        [DisplayName("To Date")]
        public DateTime ToDate { get; set; }

        public List<DealerSale> DealerSalesList { get; set; }
    }
}
