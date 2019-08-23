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
    public class OrdersController : Controller
    {
        
        private readonly IRepository<Order> _context;
        private readonly IRepository<Restaurant> _restaurant;
        private readonly IRepository<MenuItem> _menuItem;

        public OrdersController(IRepository<Order> context, 
                                IRepository<MenuItem> menuItem,
                                IRepository<Restaurant> restaurant)
        {
            _context = context;
            _menuItem = menuItem;
            _restaurant = restaurant;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            //var restaurantContext = _context.Order.Include(o => o.IdMenuItemNavigation).Include(o => o.IdRestaurantNavigation);
            return View(await _context.GetAll());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.GetById(id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public async Task<IActionResult> Create()
        {
            var restaurant = await _restaurant.GetAll();
            var menuItem = await _menuItem.GetAll();
            ViewData["ItemName"] = new SelectList(menuItem, "IdMenuItem", "ItemName");
            ViewData["Name"] = new SelectList(restaurant, "IdRestaurant", "Name");
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
                await _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var restaurant = await _restaurant.GetAll();
            var menuItem = await _menuItem.GetAll();
            ViewData["IdMenuItem"] = new SelectList(menuItem, "IdMenuItem", "IdMenuItem", order.IdMenuItem);
            ViewData["IdRestaurant"] = new SelectList(restaurant, "IdRestaurant", "IdRestaurant", order.IdRestaurant);
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await  _context.GetById(id); ;
            if (order == null)
            {
                return NotFound();
            }
            var restaurant = await _restaurant.GetAll();
            var menuItem = await _menuItem.GetAll();
            ViewData["ItemName"] = new SelectList(menuItem, "IdMenuItem", "ItemName", order.IdMenuItem);
            ViewData["Name"] = new SelectList(restaurant, "IdRestaurant", "Name", order.IdRestaurant);
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
                    await _context.Update(order);
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
            var restaurant = await _restaurant.GetAll();
            var menuItem = await _menuItem.GetAll();
            ViewData["IdMenuItem"] = new SelectList(menuItem, "IdMenuItem", "IdMenuItem", order.IdMenuItem);
            ViewData["IdRestaurant"] = new SelectList(restaurant, "IdRestaurant", "IdRestaurant", order.IdRestaurant);
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.GetById(id);
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
            var order = await _context.GetById(id);
            await _context.Remove(id);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.GetById(id) != null;
        }
    }
}
