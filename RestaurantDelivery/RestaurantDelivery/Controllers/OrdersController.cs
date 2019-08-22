using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestaurantDelivery.Models;
using RestaurantDelivery.Repository;

namespace RestaurantDelivery.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IRepository<Restaurant> _repoRestaurant;
        private readonly IRepository<MenuItem> _repoMenu;
        private readonly IRepository<Order> _repoOrder;

        public OrdersController(IRepository<Order> repoOrder, IRepository<MenuItem> repoMenu, IRepository<Restaurant> repoRestaurant)
        {
            _repoOrder = repoOrder;
            _repoMenu = repoMenu;
            _repoRestaurant = repoRestaurant;
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

            var orders = await _repoOrder.GetAll();
            var order = await orders.FirstOrDefaultAsync(m => m.IdRestaurant == id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public async Task<IActionResult> Create()
        {
            await FillAuxiliaryLists();

            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRestaurant,IdMenuItem,CustomerName,CustomerAddress,OrderNetAmount,OrderTax,OrderGrossAmount,CustomerNotes")] Order order)
        {
            if (ModelState.IsValid)
            {
                await _repoOrder.Add(order);
                return RedirectToAction(nameof(Index));
            }

            await FillAuxiliaryLists();
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orders = await _repoOrder.GetAll();
            var order = await orders.FirstOrDefaultAsync(m => m.IdRestaurant == id);

            if (order == null)
            {
                return NotFound();
            }

            await FillAuxiliaryLists();

            return View(order);
        }

        private async Task FillAuxiliaryLists()
        {
            var lstMenuItem = await _repoMenu.GetAll();
            var lstRestaurant = await _repoRestaurant.GetAll();

            ViewData["MenuItem"] = new SelectList(lstMenuItem, "IdMenuItem", "ItemName");
            ViewData["Restaurant"] = new SelectList(lstRestaurant, "IdRestaurant", "Name");
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

            await FillAuxiliaryLists();

            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orders = await _repoOrder.GetAll();
            var order = await orders.FirstOrDefaultAsync(m => m.IdRestaurant == id);

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
            var orders = await _repoOrder.GetAll();
            var order = await orders.FirstOrDefaultAsync(m => m.IdRestaurant == id);

            await _repoOrder.Remove(order?.IdOrder);
    
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            var orders = _repoOrder.GetAll().Result;
            return orders.Any(e => e.IdRestaurant == id);
        }
    }
}
