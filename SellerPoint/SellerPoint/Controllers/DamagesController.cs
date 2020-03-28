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
    public class DamagesController : Controller
    {
        private readonly SellerPointContext _context;

        public DamagesController(SellerPointContext context)
        {
            _context = context;
        }

        // GET: Damages
        public async Task<IActionResult> Index()
        {
            return View(await _context.Damage.ToListAsync());
        }

        // GET: Damages/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var damage = await _context.Damage
                .FirstOrDefaultAsync(m => m.WareHouse == id);
            if (damage == null)
            {
                return NotFound();
            }

            return View(damage);
        }

        // GET: Damages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Damages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WareHouse,ProductDetial,Quantity")] Damage damage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(damage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(damage);
        }

        // GET: Damages/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var damage = await _context.Damage.FindAsync(id);
            if (damage == null)
            {
                return NotFound();
            }
            return View(damage);
        }

        // POST: Damages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("WareHouse,ProductDetial,Quantity")] Damage damage)
        {
            if (id != damage.WareHouse)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(damage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DamageExists(damage.WareHouse))
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
            return View(damage);
        }

        // GET: Damages/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var damage = await _context.Damage
                .FirstOrDefaultAsync(m => m.WareHouse == id);
            if (damage == null)
            {
                return NotFound();
            }

            return View(damage);
        }

        // POST: Damages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var damage = await _context.Damage.FindAsync(id);
            _context.Damage.Remove(damage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DamageExists(string id)
        {
            return _context.Damage.Any(e => e.WareHouse == id);
        }
    }
}
