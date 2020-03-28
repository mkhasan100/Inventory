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
    public class MyShopsController : Controller
    {
        private readonly SellerPointContext _context;

        public MyShopsController(SellerPointContext context)
        {
            _context = context;
        }

        // GET: MyShops
        public async Task<IActionResult> Index()
        {
            return View(await _context.MyShop.ToListAsync());
        }

        // GET: MyShops/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myShop = await _context.MyShop
                .FirstOrDefaultAsync(m => m.StreetAddress == id);
            if (myShop == null)
            {
                return NotFound();
            }

            return View(myShop);
        }

        // GET: MyShops/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MyShops/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StreetAddress,Area,Thana,PostCode,District,Country,Phone,Website,Facebook,Email,ContactPerson,ContactPersonPhone,About,LogoURL,Remarks,ExpireDate,DeliveryCharge,RecieptName,ChalanName")] MyShop myShop)
        {
            if (ModelState.IsValid)
            {
                _context.Add(myShop);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(myShop);
        }

        // GET: MyShops/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myShop = await _context.MyShop.FindAsync(id);
            if (myShop == null)
            {
                return NotFound();
            }
            return View(myShop);
        }

        // POST: MyShops/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("StreetAddress,Area,Thana,PostCode,District,Country,Phone,Website,Facebook,Email,ContactPerson,ContactPersonPhone,About,LogoURL,Remarks,ExpireDate,DeliveryCharge,RecieptName,ChalanName")] MyShop myShop)
        {
            if (id != myShop.StreetAddress)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(myShop);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MyShopExists(myShop.StreetAddress))
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
            return View(myShop);
        }

        // GET: MyShops/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myShop = await _context.MyShop
                .FirstOrDefaultAsync(m => m.StreetAddress == id);
            if (myShop == null)
            {
                return NotFound();
            }

            return View(myShop);
        }

        // POST: MyShops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var myShop = await _context.MyShop.FindAsync(id);
            _context.MyShop.Remove(myShop);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MyShopExists(string id)
        {
            return _context.MyShop.Any(e => e.StreetAddress == id);
        }
    }
}
