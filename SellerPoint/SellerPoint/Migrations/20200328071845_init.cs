using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SellerPoint.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountHead",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountHead", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    ContactPersonName = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    MadeInCountry = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    BrandCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Config",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryCharge = table.Column<int>(nullable: false),
                    ReceiptName = table.Column<string>(nullable: true),
                    ChalanName = table.Column<string>(nullable: true),
                    DefaultWarehouse = table.Column<string>(nullable: true),
                    DealerPriceChange = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Config", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Courier",
                columns: table => new
                {
                    ContactPersonName = table.Column<string>(nullable: false),
                    CourierShop = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courier", x => x.ContactPersonName);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    MembershipCardNo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Phone = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    NationalId = table.Column<string>(nullable: true),
                    Occupation = table.Column<string>(nullable: true),
                    Company = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    IsActive = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.MembershipCardNo);
                });

            migrationBuilder.CreateTable(
                name: "Damage",
                columns: table => new
                {
                    WareHouse = table.Column<string>(nullable: false),
                    ProductDetial = table.Column<string>(nullable: true),
                    Quantity = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Damage", x => x.WareHouse);
                });

            migrationBuilder.CreateTable(
                name: "Dealer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    StreetAddress = table.Column<string>(nullable: true),
                    Area = table.Column<string>(nullable: true),
                    Thana = table.Column<string>(nullable: true),
                    District = table.Column<string>(nullable: true),
                    PostCode = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    CompanyName = table.Column<string>(nullable: true),
                    ContactPersonName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dealer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DealerSale",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DealerId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    UnitPrice = table.Column<decimal>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    DiscountPercent = table.Column<float>(nullable: false),
                    Discount = table.Column<float>(nullable: false),
                    Paid = table.Column<decimal>(nullable: false),
                    Due = table.Column<decimal>(nullable: false),
                    WarehouseId = table.Column<int>(nullable: false),
                    Remarks = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DealerSale", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EI",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Phone = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Salary = table.Column<int>(nullable: false),
                    SaleTargetAmount = table.Column<int>(nullable: false),
                    SaleAchivedAmount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EI", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "MyShop",
                columns: table => new
                {
                    StreetAddress = table.Column<string>(nullable: false),
                    Area = table.Column<string>(nullable: true),
                    Thana = table.Column<string>(nullable: true),
                    PostCode = table.Column<int>(nullable: false),
                    District = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Phone = table.Column<int>(nullable: false),
                    Website = table.Column<string>(nullable: true),
                    Facebook = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    ContactPerson = table.Column<int>(nullable: false),
                    ContactPersonPhone = table.Column<int>(nullable: false),
                    About = table.Column<string>(nullable: true),
                    LogoURL = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    ExpireDate = table.Column<DateTime>(nullable: false),
                    DeliveryCharge = table.Column<int>(nullable: false),
                    RecieptName = table.Column<string>(nullable: true),
                    ChalanName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyShop", x => x.StreetAddress);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                columns: table => new
                {
                    GroupName = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => x.GroupName);
                });

            migrationBuilder.CreateTable(
                name: "ProductDetail",
                columns: table => new
                {
                    Category = table.Column<string>(nullable: false),
                    Brand = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Year = table.Column<string>(nullable: true),
                    ProductCode = table.Column<string>(nullable: true),
                    BarCode = table.Column<int>(nullable: false),
                    SalePrice = table.Column<string>(nullable: true),
                    DealerPrice = table.Column<string>(nullable: true),
                    CostPrice = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    MinimumStockToNotify = table.Column<string>(nullable: true),
                    StartingInventory = table.Column<string>(nullable: true),
                    Purchased = table.Column<string>(nullable: true),
                    Sold = table.Column<string>(nullable: true),
                    OnHand = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDetail", x => x.Category);
                });

            migrationBuilder.CreateTable(
                name: "ProductGroup",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductGroup", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Purchase",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountHeadId = table.Column<int>(nullable: false),
                    WarehouseId = table.Column<int>(nullable: false),
                    WalletsId = table.Column<int>(nullable: false),
                    SupplierId = table.Column<int>(nullable: false),
                    PurchaseOrderDate = table.Column<DateTime>(nullable: false),
                    OrderNumber = table.Column<int>(nullable: false),
                    OrderReferenceNumber = table.Column<int>(nullable: false),
                    ProductAmount = table.Column<decimal>(nullable: false),
                    OtherAmount = table.Column<decimal>(nullable: false),
                    Discount = table.Column<decimal>(nullable: false),
                    Total = table.Column<decimal>(nullable: false),
                    ShippingProvider = table.Column<string>(nullable: true),
                    ShippingTrackingNumber = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    PhoneName = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    ContactPersonName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "test",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_test", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Phone = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Wallet",
                columns: table => new
                {
                    WareHouse = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    AccountNumber = table.Column<string>(nullable: true),
                    BankName = table.Column<string>(nullable: true),
                    WalletType = table.Column<string>(nullable: true),
                    CardNumber = table.Column<string>(nullable: true),
                    Balance = table.Column<string>(nullable: true),
                    MobileNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallet", x => x.WareHouse);
                });

            migrationBuilder.CreateTable(
                name: "Warehouse",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    StreetAddress = table.Column<string>(nullable: true),
                    Area = table.Column<string>(nullable: true),
                    District = table.Column<string>(nullable: true),
                    IsMain = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouse", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountHead");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "Config");

            migrationBuilder.DropTable(
                name: "Courier");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Damage");

            migrationBuilder.DropTable(
                name: "Dealer");

            migrationBuilder.DropTable(
                name: "DealerSale");

            migrationBuilder.DropTable(
                name: "EI");

            migrationBuilder.DropTable(
                name: "MyShop");

            migrationBuilder.DropTable(
                name: "ProductCategory");

            migrationBuilder.DropTable(
                name: "ProductDetail");

            migrationBuilder.DropTable(
                name: "ProductGroup");

            migrationBuilder.DropTable(
                name: "Purchase");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropTable(
                name: "test");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Wallet");

            migrationBuilder.DropTable(
                name: "Warehouse");
        }
    }
}
