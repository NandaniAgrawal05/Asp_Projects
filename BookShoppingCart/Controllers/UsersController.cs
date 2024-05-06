using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookShoppingCart.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BookShoppingCart.Controllers
{
    public class UsersController : Controller
    {
        private readonly ShoppingcartdbContext _context;

        public UsersController(ShoppingcartdbContext context)
        {
            _context = context;
        }

        //GET: Users
        public async Task<IActionResult> Index()
        {

            return _context.Users != null ?
                        View(await _context.Users.ToListAsync()) :
                        Problem("Entity set 'ShoppingcartdbContext.Users'  is null.");
        }
        [HttpPost]
        public IActionResult Index(User model, string submitButton)
        {
            if (submitButton == "Admin123@gmail.com")
            {
                return View("Index","_NewLayout");
            }
            else if (submitButton == "User123@gmail.com")
            {
                return View("Index","_Layout");
            }

            // Redirect to the same action after processing
            return RedirectToAction("Index");
        }
        //    }
        //}

        //    // GET: Users/Create
        //    public IActionResult Create()
        //    {
        //            return View();
        //        }

        //        // POST: Users/Create
        //        // To protect from overposting attacks, enable the specific properties you want to bind to.
        //        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //        [HttpPost]
        //        [ValidateAntiForgeryToken]
        //        public async Task<IActionResult> Create([Bind("Id,UserName,Password")] User user)
        //        {
        //            if (ModelState.IsValid)
        //            {
        //                _context.Add(user);
        //                await _context.SaveChangesAsync();
        //                return RedirectToAction(nameof(Index));
        //            }
        //            return View(user);
        //        }
        //}
    }
}