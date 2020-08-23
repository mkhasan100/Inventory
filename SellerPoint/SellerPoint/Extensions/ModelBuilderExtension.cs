using Microsoft.EntityFrameworkCore;
using SellerPoint.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellerPoint.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountHead>().HasData(
                    new AccountHead { Id = 1, Name = "Purchase", Type = "Any" },
                    new AccountHead { Id = 2, Name = "Stock Transfer", Type = "Expense" },
                    new AccountHead { Id = 3, Name = "Goods", Type = "Any" },
                    new AccountHead { Id = 4, Name = "Kistty", Type = "Asset" },
                    new AccountHead { Id = 5, Name = "TEST", Type = "Equity" },
                    new AccountHead { Id = 6, Name = "Conveyance", Type = "Asset" },
                    new AccountHead { Id = 7, Name = "Mix", Type = "Income" },
                    new AccountHead { Id = 8, Name = "Stationary", Type = "Any" },
                    new AccountHead { Id = 9, Name = "Other", Type = "Any" },
                    new AccountHead { Id = 10, Name = "Salary", Type = "Any" }
                );

            modelBuilder.Entity<Warehouse>().HasData(

                new Warehouse { Id = 1, Name = "Gulshan" },
                new Warehouse { Id = 2, Name = "Badda" },
                new Warehouse { Id = 3, Name = "Banani" },
                new Warehouse { Id = 4, Name = "Mohakhali" },
                new Warehouse { Id = 5, Name = "Dhanmondi" },
                new Warehouse { Id = 6, Name = "Mohammadpur" }

                );


            modelBuilder.Entity<ProductGroup>().HasData(
                new ProductGroup { Id = 1, Name = "Mobile" }

                );


            modelBuilder.Entity<ProductCategory>().HasData(
                new ProductCategory { Id = 1, GroupId = 1, Name = "Samsung" },
                new ProductCategory { Id = 2, GroupId = 1, Name = "Symphony" },
                new ProductCategory { Id = 3, GroupId = 1, Name = "Walton" },
                new ProductCategory { Id = 4, GroupId = 1, Name = "HTC" },
                new ProductCategory { Id = 5, GroupId = 1, Name = "Motorolla" }

                );


            modelBuilder.Entity<ProductDetail>().HasData(
                new ProductDetail { Id = 1, CategoryId = 1, Name = "Samsung", DealerPrice = 5000, BarCode = "1234" },
                new ProductDetail { Id = 2, CategoryId = 1, Name = "Symphony", DealerPrice = 6000, BarCode = "1234" },
                new ProductDetail { Id = 3, CategoryId = 1, Name = "Walton", DealerPrice = 7000, BarCode = "1234" },
                new ProductDetail { Id = 4, CategoryId = 1, Name = "HTC", DealerPrice = 8000, BarCode = "1234" },
                new ProductDetail { Id = 5, CategoryId = 1, Name = "Motorolla", DealerPrice = 9000, BarCode = "1234" }

                );

            modelBuilder.Entity<Wallet>().HasData(
                new Wallet { Id = 1, WareHouseId = 2, Title = "CatchMe", AccountNumber = "112233", WalletType = "Cash", Balance = "500" },
                new Wallet { Id = 2, WareHouseId = 2, Title = "Badda", AccountNumber = "112233", WalletType = "Mobile", Balance = "1000" },
                new Wallet { Id = 3, WareHouseId = 2, Title = "Badda", AccountNumber = "112233", WalletType = "Cash", Balance = "6000" },
                new Wallet { Id = 4, WareHouseId = 1, Title = "Gulshan", AccountNumber = "112233", WalletType = "Mpbile", Balance = "3000" }                
                );

            modelBuilder.Entity<Supplier>().HasData(
                new Supplier { Id = 1, Name = "Hasan", Address = "Islambag", Country = "Bangladesh", ContactPersonName = "01795818648" },
                new Supplier { Id = 2, Name = "Jewel", Address = "Islambag", Country = "Bangladesh", ContactPersonName = "01795818648" },
                new Supplier { Id = 3, Name = "Saad", Address = "Islambag", Country = "Bangladesh", ContactPersonName = "01795818648" },
                new Supplier { Id = 4, Name = "Saif", Address = "Islambag", Country = "Bangladesh", ContactPersonName = "01795818648" }
                
                );

            modelBuilder.Entity<Dealer>().HasData(
                new Dealer { Id = 1, Name = "Hasan"},
                new Dealer { Id = 2, Name = "Saif"},
                new Dealer { Id = 3, Name = "Masum"},
                new Dealer { Id = 4, Name = "Rakib"},
                new Dealer { Id = 5, Name = "Imran"},
                new Dealer { Id = 6, Name = "Saad"},
                new Dealer { Id = 7, Name = "Jewel"}
                );
        }
    }
}
