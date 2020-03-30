using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SellerPoint.Data;
using SellerPoint.Models;

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
        public async Task<IActionResult> Index()
        {
            return View(await _context.DealerSale.ToListAsync());
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



        public IActionResult Entry()
        {
            return View();
        }

        // GET: DealerSales/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DealerSales/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DealerId,ProductId,UnitPrice,Quantity,DiscountPercent,Discount,Paid,Due,WarehouseId,Remarks")] DealerSale dealerSale)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dealerSale);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dealerSale);
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


        public JsonResult GetProducts(string ProductName)
        {
            ProductName = ProductName.ToUpper();
            var Dealers = _context.ProductDetail
                .Where(a => a.Name.ToUpper().Contains(ProductName))
                .Select(a => new { a.Name,a.DealerPrice });

            return Json(Dealers);

        }

    }
}
