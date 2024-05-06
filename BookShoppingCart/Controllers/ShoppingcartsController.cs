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
    public class ShoppingcartsController : Controller
    {
        private readonly ShoppingcartdbContext _context;

        public ShoppingcartsController(ShoppingcartdbContext context)
        {
            _context = context;
        }

        // GET: Shoppingcarts
        public async Task<IActionResult> Index()
        {
              return _context.Shoppingcarts != null ? 
                          View(await _context.Shoppingcarts.ToListAsync()) :
                          Problem("Entity set 'ShoppingcartdbContext.Shoppingcarts'  is null.");
        }

        // GET: Shoppingcarts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Shoppingcarts == null)
            {
                return NotFound();
            }

            var shoppingcart = await _context.Shoppingcarts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shoppingcart == null)
            {
                return NotFound();
            }

            return View("Create", "_NewLayout");
        }

        // GET: Shoppingcarts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Shoppingcarts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,IsDeleted")] Shoppingcart shoppingcart)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shoppingcart);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shoppingcart);
        }

        // GET: Shoppingcarts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Shoppingcarts == null)
            {
                return NotFound();
            }

            var shoppingcart = await _context.Shoppingcarts.FindAsync(id);
            if (shoppingcart == null)
            {
                return NotFound();
            }
            return View(shoppingcart);
        }

        // POST: Shoppingcarts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,IsDeleted")] Shoppingcart shoppingcart)
        {
            if (id != shoppingcart.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shoppingcart);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShoppingcartExists(shoppingcart.Id))
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
            return View(shoppingcart);
        }

        // GET: Shoppingcarts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Shoppingcarts == null)
            {
                return NotFound();
            }

            var shoppingcart = await _context.Shoppingcarts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shoppingcart == null)
            {
                return NotFound();
            }

            return View(shoppingcart);
        }

        // POST: Shoppingcarts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Shoppingcarts == null)
            {
                return Problem("Entity set 'ShoppingcartdbContext.Shoppingcarts'  is null.");
            }
            var shoppingcart = await _context.Shoppingcarts.FindAsync(id);
            if (shoppingcart != null)
            {
                _context.Shoppingcarts.Remove(shoppingcart);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShoppingcartExists(int id)
        {
          return (_context.Shoppingcarts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
