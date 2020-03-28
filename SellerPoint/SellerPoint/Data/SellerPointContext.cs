using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SellerPoint.Models;

namespace SellerPoint.Data
{
    public class SellerPointContext : DbContext
    {
        public SellerPointContext (DbContextOptions<SellerPointContext> options)
            : base(options)
        {
        }

        public DbSet<SellerPoint.Models.MyShop> MyShop { get; set; }
        public DbSet<SellerPoint.Models.Config> Config { get; set; }
        public DbSet<SellerPoint.Models.User> User { get; set; }
        public DbSet<SellerPoint.Models.EmployeeInfo> EI { get; set; }
        public DbSet<SellerPoint.Models.Brand> Brand { get; set; }
        public DbSet<SellerPoint.Models.Customer> Customer { get; set; }
        public DbSet<SellerPoint.Models.ProductGroup> ProductGroup { get; set; }
        public DbSet<SellerPoint.Models.ProductCategory> ProductCategory { get; set; }
        public DbSet<SellerPoint.Models.ProductDetail> ProductDetail { get; set; }
        public DbSet<SellerPoint.Models.Warehouse> Warehouse { get; set; }
        public DbSet<SellerPoint.Models.Damage> Damage { get; set; }
        public DbSet<SellerPoint.Models.AccountHead> AccountHead { get; set; }
        public DbSet<SellerPoint.Models.Wallet> Wallet { get; set; }
        public DbSet<SellerPoint.Models.Supplier> Supplier { get; set; }
        public DbSet<SellerPoint.Models.Dealer> Dealer { get; set; }
        public DbSet<SellerPoint.Models.Courier> Courier { get; set; }
        public DbSet<SellerPoint.Models.Purchase> Purchase { get; set; }
        public DbSet<SellerPoint.Models.DealerSale> DealerSale { get; set; }
    }
}
