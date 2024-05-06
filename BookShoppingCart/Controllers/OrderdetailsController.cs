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
    public class OrderdetailsController : Controller
    {
        private readonly ShoppingcartdbContext _context;

        public OrderdetailsController(ShoppingcartdbContext context)
        {
            _context = context;
        }

        // GET: Orderdetails
        public async Task<IActionResult> Index()
        {
              return _context.Orderdetails != null ? 
                          View(await _context.Orderdetails.ToListAsync()) :
                          Problem("Entity set 'ShoppingcartdbContext.Orderdetails'  is null.");
        }

        // GET: Orderdetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Orderdetails == null)
            {
                return NotFound();
            }

            var orderdetail = await _context.Orderdetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orderdetail == null)
            {
                return NotFound();
            }

            return View(orderdetail);
        }

        // GET: Orderdetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Orderdetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OrderId,BookId,Quantity,UnitPrice")] Orderdetail orderdetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderdetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(orderdetail);
        }

        // GET: Orderdetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Orderdetails == null)
            {
                return NotFound();
            }

            var orderdetail = await _context.Orderdetails.FindAsync(id);
            if (orderdetail == null)
            {
                return NotFound();
            }
            return View(orderdetail);
        }

        // POST: Orderdetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OrderId,BookId,Quantity,UnitPrice")] Orderdetail orderdetail)
        {
            if (id != orderdetail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderdetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderdetailExists(orderdetail.Id))
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
            return View(orderdetail);
        }

        // GET: Orderdetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Orderdetails == null)
            {
                return NotFound();
            }

            var orderdetail = await _context.Orderdetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orderdetail == null)
            {
                return NotFound();
            }

            return View(orderdetail);
        }

        // POST: Orderdetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Orderdetails == null)
            {
                return Problem("Entity set 'ShoppingcartdbContext.Orderdetails'  is null.");
            }
            var orderdetail = await _context.Orderdetails.FindAsync(id);
            if (orderdetail != null)
            {
                _context.Orderdetails.Remove(orderdetail);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderdetailExists(int id)
        {
          return (_context.Orderdetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
