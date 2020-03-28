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
    public class AccountHeadsController : Controller
    {
        private readonly SellerPointContext _context;

        public AccountHeadsController(SellerPointContext context)
        {
            _context = context;
        }

        // GET: AccountHeads
        public async Task<IActionResult> Index()
        {
            return View(await _context.AccountHead.ToListAsync());
        }

        // GET: AccountHeads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountHead = await _context.AccountHead
                .FirstOrDefaultAsync(m => m.Id == id);
            if (accountHead == null)
            {
                return NotFound();
            }

            return View(accountHead);
        }

        // GET: AccountHeads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AccountHeads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Type")] AccountHead accountHead)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accountHead);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(accountHead);
        }

        // GET: AccountHeads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountHead = await _context.AccountHead.FindAsync(id);
            if (accountHead == null)
            {
                return NotFound();
            }
            return View(accountHead);
        }

        // POST: AccountHeads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Type")] AccountHead accountHead)
        {
            if (id != accountHead.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accountHead);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountHeadExists(accountHead.Id))
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
            return View(accountHead);
        }

        // GET: AccountHeads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountHead = await _context.AccountHead
                .FirstOrDefaultAsync(m => m.Id == id);
            if (accountHead == null)
            {
                return NotFound();
            }

            return View(accountHead);
        }

        // POST: AccountHeads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var accountHead = await _context.AccountHead.FindAsync(id);
            _context.AccountHead.Remove(accountHead);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountHeadExists(int id)
        {
            return _context.AccountHead.Any(e => e.Id == id);
        }
    }
}
