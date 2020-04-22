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
    public class PosSalesController : Controller
    {
        private readonly SellerPointContext _context;

        public PosSalesController(SellerPointContext context)
        {
            _context = context;
        }

        // GET: PosSales
        public async Task<IActionResult> Index()
        {
            return View(await _context.PosSale.ToListAsync());
        }

        // GET: PosSales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var posSale = await _context.PosSale
                .FirstOrDefaultAsync(m => m.Id == id);
            if (posSale == null)
            {
                return NotFound();
            }

            return View(posSale);
        }

        // GET: PosSales/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PosSales/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,WarehouseId,productId,TotalAmount,DiscountPercentage,DiscountAmount,PayableTotal1,TransactionMedium,Wallets,PayingAmount,TransactionNumber,Remarks,CustomerInfo,Name,Phone,StreetAddress1,Addresses,AddressesName,ContactName,ContactPhone,StreetAddress2,District,Thana,Area,Postcode,Country,SpecialNote,SaleTotal,Discount,PayableTotal2,Paid,Due,GivenAmount,ChangeAmount,Remark,OrderReferenceNumber")] PosSale posSale)
        {
            if (ModelState.IsValid)
            {
                _context.Add(posSale);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(posSale);
        }

        // GET: PosSales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var posSale = await _context.PosSale.FindAsync(id);
            if (posSale == null)
            {
                return NotFound();
            }
            return View(posSale);
        }

        // POST: PosSales/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,WarehouseId,productId,TotalAmount,DiscountPercentage,DiscountAmount,PayableTotal1,TransactionMedium,Wallets,PayingAmount,TransactionNumber,Remarks,CustomerInfo,Name,Phone,StreetAddress1,Addresses,AddressesName,ContactName,ContactPhone,StreetAddress2,District,Thana,Area,Postcode,Country,SpecialNote,SaleTotal,Discount,PayableTotal2,Paid,Due,GivenAmount,ChangeAmount,Remark,OrderReferenceNumber")] PosSale posSale)
        {
            if (id != posSale.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(posSale);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PosSaleExists(posSale.Id))
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
            return View(posSale);
        }

        // GET: PosSales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var posSale = await _context.PosSale
                .FirstOrDefaultAsync(m => m.Id == id);
            if (posSale == null)
            {
                return NotFound();
            }

            return View(posSale);
        }

        // POST: PosSales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var posSale = await _context.PosSale.FindAsync(id);
            _context.PosSale.Remove(posSale);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PosSaleExists(int id)
        {
            return _context.PosSale.Any(e => e.Id == id);
        }
    }
}
