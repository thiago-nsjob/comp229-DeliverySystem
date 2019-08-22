﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestaurantDelivery.Models;

namespace RestaurantDelivery.Controllers
{
    public class OrdersController : Controller
    {
        private readonly RestaurantDeliveryContext _context;

        public OrdersController(RestaurantDeliveryContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var restaurantDeliveryContext = _context.Order.Include(o => o.IdMenuItemNavigation).Include(o => o.IdRestaurantNavigation);
            return View(await restaurantDeliveryContext.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .Include(o => o.IdMenuItemNavigation)
                .Include(o => o.IdRestaurantNavigation)
                .FirstOrDefaultAsync(m => m.IdOrder == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewData["IdMenuItem"] = new SelectList(_context.MenuItem, "IdMenuItem", "IdMenuItem");
            ViewData["IdRestaurant"] = new SelectList(_context.Restaurant, "IdRestaurant", "IdRestaurant");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdOrder,IdRestaurant,IdMenuItem,CustomerName,CustomerAddress,OrderNetAmount,OrderTax,OrderGrossAmount,CustomerNotes")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdMenuItem"] = new SelectList(_context.MenuItem, "IdMenuItem", "IdMenuItem", order.IdMenuItem);
            ViewData["IdRestaurant"] = new SelectList(_context.Restaurant, "IdRestaurant", "IdRestaurant", order.IdRestaurant);
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["IdMenuItem"] = new SelectList(_context.MenuItem, "IdMenuItem", "IdMenuItem", order.IdMenuItem);
            ViewData["IdRestaurant"] = new SelectList(_context.Restaurant, "IdRestaurant", "IdRestaurant", order.IdRestaurant);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdOrder,IdRestaurant,IdMenuItem,CustomerName,CustomerAddress,OrderNetAmount,OrderTax,OrderGrossAmount,CustomerNotes")] Order order)
        {
            if (id != order.IdOrder)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.IdOrder))
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
            ViewData["IdMenuItem"] = new SelectList(_context.MenuItem, "IdMenuItem", "IdMenuItem", order.IdMenuItem);
            ViewData["IdRestaurant"] = new SelectList(_context.Restaurant, "IdRestaurant", "IdRestaurant", order.IdRestaurant);
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .Include(o => o.IdMenuItemNavigation)
                .Include(o => o.IdRestaurantNavigation)
                .FirstOrDefaultAsync(m => m.IdOrder == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Order.FindAsync(id);
            _context.Order.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Order.Any(e => e.IdOrder == id);
        }
    }
}
