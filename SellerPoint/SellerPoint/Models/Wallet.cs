using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SellerPoint.Models
{
    public class Wallet
    {
        [Key]
        public int Id { get; set; }
        public string WareHouse { get; set; }
        public string Title { get; set; }
        public string AccountNumber { get; set; }
        public string BankName { get; set; }
        public string WalletType { get; set; }
        public string CardNumber { get; set; }
        public string Balance { get; set; }
        public string MobileNumber { get; set; }
    }
}
