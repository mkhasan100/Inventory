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
                new Warehouse { Id = 2, Name = "Badda" }

                );


            modelBuilder.Entity<ProductGroup>().HasData(
                new ProductGroup { Id = 1, Name = "Mobile" }

                );


            modelBuilder.Entity<ProductCategory>().HasData(
                new ProductCategory { Id = 1, GroupId = 1, Name = "Samsung" }

                );


            modelBuilder.Entity<ProductDetail>().HasData(
                new ProductDetail { Id = 1, CategoryId = 1, Name = "Samsung", DealerPrice = 5000, BarCode = "1234" },
                new ProductDetail { Id = 2, CategoryId = 1, Name = "Symphony", DealerPrice = 6000, BarCode = "1234" },
                new ProductDetail { Id = 3, CategoryId = 1, Name = "Walton", DealerPrice = 7000, BarCode = "1234" },
                new ProductDetail { Id = 4, CategoryId = 1, Name = "HTC", DealerPrice = 8000, BarCode = "1234" },
                new ProductDetail { Id = 5, CategoryId = 1, Name = "Motorolla", DealerPrice = 9000, BarCode = "1234" }

                );
        }
    }
}
