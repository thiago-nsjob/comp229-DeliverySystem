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
        
        private readonly IRepository<Order> _repoOrder;
        private readonly IRepository<Restaurant> _respoRestaurant;
        private readonly IRepository<MenuItem> _repoMenuItem;

        public OrdersController(IRepository<Order> repoOrder, 
                                IRepository<MenuItem> repoMenuItem,
                                IRepository<Restaurant> repoRestaurant)
        {
            _repoOrder = repoOrder;
            _repoMenuItem = repoMenuItem;
            _respoRestaurant = repoRestaurant;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            return View(await _repoOrder.GetAll());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _repoOrder.GetById(id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public async Task<IActionResult> Create()
        {
            var restaurant = await _respoRestaurant.GetAll();
            var menuItem = await _repoMenuItem.GetAll();
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
                await _repoOrder.Add(order);
                return RedirectToAction(nameof(Index));
            }
            var restaurant = await _respoRestaurant.GetAll();
            var menuItem = await _repoMenuItem.GetAll();
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

            var order = await  _repoOrder.GetById(id); ;
            if (order == null)
            {
                return NotFound();
            }
            var restaurant = await _respoRestaurant.GetAll();
            var menuItem = await _repoMenuItem.GetAll();
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
                    await _repoOrder.Update(order);
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
            var restaurant = await _respoRestaurant.GetAll();
            var menuItem = await _repoMenuItem.GetAll();
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

            var order = await _repoOrder.GetById(id);
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
            var order = await _repoOrder.GetById(id);
            await _repoOrder.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _repoOrder.GetById(id) != null;
        }
    }
}
