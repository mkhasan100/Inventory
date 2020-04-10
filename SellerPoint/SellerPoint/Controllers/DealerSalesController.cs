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
    public class DealerSalesController : Controller
    {
        private readonly SellerPointContext _context;

        public DealerSalesController(SellerPointContext context)
        {
            _context = context;
        }

        // GET: DealerSales
        public IActionResult Index()
        {
            var DealerSaleList = _context.DealerSale.AsEnumerable()
                                         .Join(_context.Warehouse, ds => ds.WarehouseId, w => w.Id, (ds, w) => new { ds, w })
                                         .Join(_context.Dealer, dsw=>dsw.ds.DealerId, d=>d.Id,(dsw,d)=>new { dsw , d })
                                         .Select(s => new DealerSale
                                         {
                                             DealerName = s.d.Name,
                                             ProductName = 
                                             string.Join(", ", _context.DealerSaleProductDetails.AsEnumerable().Join(_context.ProductDetail,dspd=>dspd.ProductId,pd=>pd.Id,(dspd,pd)=>new { dspd,pd}).Where(w=>w.dspd.DealerSaleId == s.dsw.ds.Id).Select(s=>s.pd.Name)),
                                             UnitPrice = s.dsw.ds.UnitPrice,
                                             DiscountPercent = s.dsw.ds.DiscountPercent,
                                             Discount = s.dsw.ds.Discount,
                                             payableTotal = s.dsw.ds.payableTotal,
                                             Paid= s.dsw.ds.Paid,
                                             Due = s.dsw.ds.Due,
                                             WareHouseName = s.dsw.w.Name,
                                             Remarks = s.dsw.ds.Remarks
                                         }).ToList();
            
                return View(DealerSaleList);
        }

        // GET: DealerSales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dealerSale = await _context.DealerSale
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dealerSale == null)
            {
                return NotFound();
            }

            return View(dealerSale);
        }


        public IActionResult DealerSaleLists()
        {
            ViewBag.DealerSaleList = _context.Warehouse.ToList();
            
            var DealerSaleListViewModel = new DealerSaleListViewModel();

            DealerSaleListViewModel.DealerSalesList = _context.DealerSale.ToList();

            return View(DealerSaleListViewModel);
        }


        public IActionResult Entry()
        {
            ViewBag.WareHouseList = _context.Warehouse.ToList();
            return View();
        }

        // GET: DealerSales/Create
        public IActionResult Create()
        {
            ViewBag.WareHouseList = _context.Warehouse.ToList();
            return View();
        }

        // POST: DealerSales/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DealerSaleProdDtlViewModel dealerSaleProdDtlViewModel)
        {
            if (ModelState.IsValid)
            {
                string OrderNo = string.Empty;
                string SalesOrder = "0";
                string SalesToken = "0";
                string[] strOrderNo;

                if (_context.DealerSale.ToList().Count() > 0)
                {
                    var orderNo = _context.DealerSale.OrderByDescending(m => m.Id).Where(w => w.OrderNo != null).Select(s => s.OrderNo).FirstOrDefault();

                    if (orderNo != null)
                    {
                        strOrderNo = orderNo.Split('-');

                        if (strOrderNo.Length > 0)
                        {
                            SalesOrder = strOrderNo[1];
                            SalesToken = strOrderNo[3];
                        }
                    }

                }



                SalesOrder = Convert.ToString(Convert.ToInt16(SalesOrder) + 1);

                SalesOrder = SalesOrder.PadLeft(8 - SalesOrder.Length, '0');

                SalesToken = Convert.ToString(Convert.ToInt16(SalesToken) + 1);

                SalesToken = SalesToken.PadLeft(10 - SalesToken.Length, '0');

                //string ProductName = "Symphony";

                //var firstChar = ProductName.ToUpper().Substring(0, 3);

                OrderNo = "S-" + SalesOrder + "-" + DateTime.Now.ToString("ddMMyy") + "-" + SalesToken;

                dealerSaleProdDtlViewModel.DealerSale.OrderNo = OrderNo;
                _context.Add(dealerSaleProdDtlViewModel.DealerSale);
                _context.SaveChanges();

                int DealerSaleId = dealerSaleProdDtlViewModel.DealerSale.Id;

                foreach (var item in dealerSaleProdDtlViewModel.DealerSaleProductDetail)
                {
                    item.DealerSaleId = DealerSaleId;

                    _context.Add(item);
                }


                _context.SaveChanges();


                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: DealerSales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dealerSale = await _context.DealerSale.FindAsync(id);
            if (dealerSale == null)
            {
                return NotFound();
            }
            return View(dealerSale);
        }

        // POST: DealerSales/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DealerId,ProductId,UnitPrice,Quantity,DiscountPercent,Discount,Paid,Due,WarehouseId,Remarks")] DealerSale dealerSale)
        {
            if (id != dealerSale.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dealerSale);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DealerSaleExists(dealerSale.Id))
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
            return View(dealerSale);
        }

        // GET: DealerSales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dealerSale = await _context.DealerSale
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dealerSale == null)
            {
                return NotFound();
            }

            return View(dealerSale);
        }

        // POST: DealerSales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dealerSale = await _context.DealerSale.FindAsync(id);
            _context.DealerSale.Remove(dealerSale);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DealerSaleExists(int id)
        {
            return _context.DealerSale.Any(e => e.Id == id);
        }

        public JsonResult GetDealers(string q)
        {
            q = q.ToUpper();
            var Dealers = _context.Dealer
                .Where(a => a.Name.ToUpper().Contains(q))
                .Select(a => new { id = a.Id, name = a.Name });

            return Json(Dealers);

        }


        public JsonResult GetProducts(string ProductNameAndDetail)
        {
            ProductNameAndDetail = ProductNameAndDetail.ToUpper();
            var Product = _context.ProductDetail
                .Where(a => a.Name.ToUpper().Contains(ProductNameAndDetail))
                .Select(a => new { a.Id, a.Name, a.DealerPrice });
            return Json(Product);
        }

        
    }
}
