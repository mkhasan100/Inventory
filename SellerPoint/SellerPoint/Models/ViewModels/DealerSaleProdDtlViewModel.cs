using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellerPoint.Models.ViewModels
{
    public class DealerSaleProdDtlViewModel
    {
        public DealerSale DealerSale { get; set; }

        public List<DealerSaleProductDetail> DealerSaleProductDetail { get; set; }
    }
}
