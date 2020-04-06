using Microsoft.EntityFrameworkCore;
using SellerPoint.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellerPoint.Extensions
{
    public static class ModelBuilderExtensions
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
        }
    }
}
