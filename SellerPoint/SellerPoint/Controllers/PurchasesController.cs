using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SellerPoint.Data;
using SellerPoint.Models;
using SellerPoint.Models.ViewModels;

namespace SellerPoint.Controllers
{
    public class PurchasesController : Controller
    {
        private readonly SellerPointContext _context;

        public PurchasesController(SellerPointContext context)
        {
            _context = context;
        }

        // GET: Purchases
        public IActionResult Index()
        {
            var PurchaseList = _context.Purchase.AsEnumerable()
                                         .Join(_context.AccountHead, p => p.AccountHeadId, ah => ah.Id, (p, ah) => new { p, ah })
                                         .Join(_context.Warehouse, pah => pah.p.WarehouseId, w => w.Id, (pah, w) => new { pah, w })
                                         .Join(_context.Wallet, pahw => pahw.pah.p.WalletsId, wl => wl.Id, (pahw, wl) => new { pahw, wl })
                                         .Join(_context.Supplier, pahwwl => pahwwl.pahw.pah.p.SupplierId, sp => sp.Id, (pahwwl, sp) => new { pahwwl, sp })
                                         .Select(pr => new Purchase
                                         {
                                             AccountHeadName = pr.pahwwl.pahw.pah.ah.Name,
                                             WarehouseName = pr.pahwwl.pahw.w.Name,
                                             WalletsName = pr.pahwwl.wl.Title,
                                             SupplierName = pr.sp.Name,
                                             PurchaseOrderDate = pr.pahwwl.pahw.pah.p.PurchaseOrderDate,
                                             PurchaseOrderDateWithDay = pr.pahwwl.pahw.pah.p.PurchaseOrderDateWithDay,
                                             OrderNumber = pr.pahwwl.pahw.pah.p.OrderNumber,
                                             OrderReferenceNumber = pr.pahwwl.pahw.pah.p.OrderReferenceNumber,
                                             ProductAmount = pr.pahwwl.pahw.pah.p.ProductAmount,
                                             OtherAmount = pr.pahwwl.pahw.pah.p.OtherAmount,
                                             Discount = pr.pahwwl.pahw.pah.p.Discount,
                                             Total = pr.pahwwl.pahw.pah.p.Total,
                                             ShippingProvider = pr.pahwwl.pahw.pah.p.ShippingProvider,
                                             ShippingTrackingNumber = pr.pahwwl.pahw.pah.p.ShippingTrackingNumber,
                                             Remarks = pr.pahwwl.pahw.pah.p.Remarks
                                         }).ToList();

            return View(PurchaseList);
            //return View(_context.Purchase.ToList());
        }

        // GET: Purchases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchase = await _context.Purchase
                .FirstOrDefaultAsync(m => m.Id == id);
            if (purchase == null)
            {
                return NotFound();
            }

            return View(purchase);
        }

        public IActionResult PurchaseList(PurchaseListViewModel purchaseListViewModel)
        {
            ViewBag.WareHouseList = _context.Warehouse.ToList();
            ViewBag.SupplierList = _context.Supplier.ToList();

            return View();
        }



        // GET: Purchases/Create
        public IActionResult Create()
        {
            ViewBag.AccountHeadList = _context.AccountHead.ToList();
            ViewBag.WareHouseList = _context.Warehouse.ToList();
            ViewBag.WalletList = _context.Wallet.ToList();
            ViewBag.SupplierList = _context.Supplier.ToList();
            ViewBag.PurchaseOrderDate = DateTime.Now.ToString("yyyy-MM-dd");
            ViewBag.PurchaseOrderDateWithDay = DateTime.Now.ToString("ddd MMM dd yyyy");
            return View();

        }



        // POST: Purchases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Purchase purchase)
        {
            if (ModelState.IsValid)
            {
                _context.Add(purchase);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            return View(purchase);
        }

        // GET: Purchases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchase = await _context.Purchase.FindAsync(id);
            if (purchase == null)
            {
                return NotFound();
            }
            return View(purchase);
        }

        // POST: Purchases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AccountHeadId,WarehouseId,WalletsId,SupplierId,PurchaseOrderDate,OrderNumber,OrderReferenceNumber,ProductAmount,OtherAmount,Discount,Total,ShippingProvider,ShippingTrackingNumber,Remarks")] Purchase purchase)
        {
            if (id != purchase.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(purchase);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PurchaseExists(purchase.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(purchase);
        }

        // GET: Purchases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchase = await _context.Purchase
                .FirstOrDefaultAsync(m => m.Id == id);
            if (purchase == null)
            {
                return NotFound();
            }

            return View(purchase);
        }

        // POST: Purchases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var purchase = await _context.Purchase.FindAsync(id);
            _context.Purchase.Remove(purchase);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PurchaseExists(int id)
        {
            return _context.Purchase.Any(e => e.Id == id);
        }

        public JsonResult GetProducts(string PurchaseProductDetail)
        {
            PurchaseProductDetail = PurchaseProductDetail.ToUpper();
            var Product = _context.ProductDetail
                .Where(a => a.Name.ToUpper().Contains(PurchaseProductDetail))
                .Select(a => new { a.Id, a.Name, a.DealerPrice });
            return Json(Product);
        }

        public JsonResult GetKeyword(string q)
        {
            string PurchaseKeyword = q.ToUpper();
            var Product = _context.Purchase
                .Where(a => a.ProductName.ToUpper().Contains(PurchaseKeyword))
                .Select(a => new { a.Id, a.ProductName, });
            return Json(Product);
        }
    }
}
