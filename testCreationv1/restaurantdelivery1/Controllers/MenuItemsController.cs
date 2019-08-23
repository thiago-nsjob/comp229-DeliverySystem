using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using restaurantdelivery1.Models;
using restaurantdelivery1.Repository;

namespace restaurantdelivery1.Controllers
{
    public class MenuItemsController : Controller
    {
        private readonly IRepository<MenuItem> _context;
        private readonly IRepository<Restaurant> _restaurant;
        private readonly RestaurantContext _rescontext;

        public MenuItemsController(IRepository<MenuItem> context,RestaurantContext rescontext)
        {
            _context = context;
            _rescontext = rescontext;
        }

        // GET: MenuItems
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetAll());
        }

        // GET: MenuItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuItem = await _context.GetById(id);
            if (menuItem == null)
            {
                return NotFound();
            }

            return View(menuItem);
        }

        // GET: MenuItems/Create
        public IActionResult Create()
        {

            ViewData["Name"] = new SelectList(_rescontext.Restaurant, "IdRestaurant", "Name");

            return View();
        }

        // POST: MenuItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMenuItem,IdRestaurant,ItemName,ItemDescription,ItemPrice")] MenuItem menuItem)
        {
            if (ModelState.IsValid)
            {
                await _context.Add(menuItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdRestaurant"] = new SelectList(_rescontext.Restaurant, "IdRestaurant", "IdRestaurant", menuItem.IdRestaurant);
            return View(menuItem);
        }

        // GET: MenuItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuItem = await _context.GetById(id);
            if (menuItem == null)
            {
                return NotFound();
            }
            ViewData["Name"] = new SelectList(_rescontext.Restaurant, "IdRestaurant", "Name", menuItem.IdRestaurant);
            return View(menuItem);
        }

        // POST: MenuItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMenuItem,IdRestaurant,ItemName,ItemDescription,ItemPrice")] MenuItem menuItem)
        {
            if (id != menuItem.IdMenuItem)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Update(menuItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenuItemExists(menuItem.IdMenuItem))
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
            ViewData["IdRestaurant"] = new SelectList(_rescontext.Restaurant, "IdRestaurant", "IdRestaurant", menuItem.IdRestaurant);
            return View(menuItem);
        }

        // GET: MenuItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuItem = await _context.GetById(id);
            if (menuItem == null)
            {
                return NotFound();
            }

            return View(menuItem);
        }

        // POST: MenuItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var menuItem = await _context.GetById(id);
            await _context.Remove(id);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MenuItemExists(int id)
        {
            return _context.GetById(id) != null;
        }

    }
}
