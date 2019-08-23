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
        private readonly IRepository<MenuItem> _repoMenuItem;
        private readonly IRepository<Restaurant> _repoRestaurant;

        public MenuItemsController(IRepository<MenuItem> repoContext,
                                   IRepository<Restaurant> repoRestaurant)
        {
            _repoMenuItem = repoContext;
            _repoRestaurant = repoRestaurant;
        }

        // GET: MenuItems
        public async Task<IActionResult> Index()
        {
            return View(await _repoMenuItem.GetAll());
        }

        // GET: MenuItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuItem = await _repoMenuItem.GetById(id);
            if (menuItem == null)
            {
                return NotFound();
            }

            return View(menuItem);
        }

        // GET: MenuItems/Create
        public async Task<IActionResult> Create()
        {
           var restaurant = await _repoRestaurant.GetAll();  
           ViewData["Name"] = new SelectList(restaurant, "IdRestaurant", "Name");
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
                await _repoMenuItem.Add(menuItem);
                return RedirectToAction(nameof(Index));
            }
            var restaurant = await _repoRestaurant.GetAll();
            ViewData["IdRestaurant"] = new SelectList(restaurant, "IdRestaurant", "IdRestaurant", menuItem.IdRestaurant);
            return View(menuItem);
        }

        // GET: MenuItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuItem = await _repoMenuItem.GetById(id);
            if (menuItem == null)
            {
                return NotFound();
            }
            var restaurant = await _repoRestaurant.GetAll();
            ViewData["Name"] = new SelectList(restaurant, "IdRestaurant", "Name", menuItem.IdRestaurant);
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
                    await _repoMenuItem.Update(menuItem);
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
            var restaurant = await _repoRestaurant.GetAll();
            ViewData["IdRestaurant"] = new SelectList(restaurant, "IdRestaurant", "IdRestaurant", menuItem.IdRestaurant);
            return View(menuItem);
        }

        // GET: MenuItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuItem = await _repoMenuItem.GetById(id);
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
            var menuItem = await _repoMenuItem.GetById(id);
            await _repoMenuItem.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        private bool MenuItemExists(int id)
        {
            return _repoMenuItem.GetById(id) != null;
        }

    }
}
