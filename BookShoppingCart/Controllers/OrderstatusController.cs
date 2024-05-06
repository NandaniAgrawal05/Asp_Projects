using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookShoppingCart.Models;

namespace BookShoppingCart.Controllers
{
    public class OrderstatusController : Controller
    {
        private readonly ShoppingcartdbContext _context;

        public OrderstatusController(ShoppingcartdbContext context)
        {
            _context = context;
        }

        // GET: Orderstatus
        public async Task<IActionResult> Index()
        {
              return _context.Orderstatuses != null ? 
                          View(await _context.Orderstatuses.ToListAsync()) :
                          Problem("Entity set 'ShoppingcartdbContext.Orderstatuses'  is null.");
        }

        // GET: Orderstatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Orderstatuses == null)
            {
                return NotFound();
            }

            var orderstatus = await _context.Orderstatuses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orderstatus == null)
            {
                return NotFound();
            }

            return View(orderstatus);
        }

        // GET: Orderstatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Orderstatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StatusName")] Orderstatus orderstatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderstatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(orderstatus);
        }

        // GET: Orderstatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Orderstatuses == null)
            {
                return NotFound();
            }

            var orderstatus = await _context.Orderstatuses.FindAsync(id);
            if (orderstatus == null)
            {
                return NotFound();
            }
            return View(orderstatus);
        }

        // POST: Orderstatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StatusName")] Orderstatus orderstatus)
        {
            if (id != orderstatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderstatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderstatusExists(orderstatus.Id))
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
            return View(orderstatus);
        }

        // GET: Orderstatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Orderstatuses == null)
            {
                return NotFound();
            }

            var orderstatus = await _context.Orderstatuses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orderstatus == null)
            {
                return NotFound();
            }

            return View(orderstatus);
        }

        // POST: Orderstatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Orderstatuses == null)
            {
                return Problem("Entity set 'ShoppingcartdbContext.Orderstatuses'  is null.");
            }
            var orderstatus = await _context.Orderstatuses.FindAsync(id);
            if (orderstatus != null)
            {
                _context.Orderstatuses.Remove(orderstatus);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderstatusExists(int id)
        {
          return (_context.Orderstatuses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
