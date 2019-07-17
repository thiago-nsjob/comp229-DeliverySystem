using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FoodDelivery.Data;
using FoodDelivery.Models;
using FoodDelivery.Repository;

namespace FoodDelivery.Controllers
{
    public class OrderItemsController : Controller
    {

        private readonly IRepository<OrderItem> _repositoryOrderItem;
        private readonly IRepository<Order> _repositoryOrder;

        public OrderItemsController(IRepository<OrderItem> repositoryOrderItem, IRepository<Order> repositoryOrder)
        {
            _repositoryOrderItem = repositoryOrderItem;
            _repositoryOrder = repositoryOrder;
        }

        // GET: OrderItems
        public IActionResult Index()
        {
            return View(_repositoryOrderItem.GetAll);
        }

        // GET: OrderItems/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderItem = _repositoryOrderItem.GetById(id);

            if (orderItem == null)
            {
                return NotFound();
            }

            return View(orderItem);
        }

        // GET: OrderItems/Create
        public IActionResult Create()
        {
            ViewData["IdOrder"] = new SelectList(_repositoryOrder.GetAll, "IdOrder", "IdOrder");
            return View();
        }

        // POST: OrderItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("IdOrderItem,IdOrder,IdRestaurantMenuItem,Quantity,PricePerUnity")] OrderItem orderItem)
        {
            if (ModelState.IsValid)
            {
                _repositoryOrderItem.Add(orderItem);

                return RedirectToAction(nameof(Index));
            }
            ViewData["IdOrder"] = new SelectList(_repositoryOrder.GetAll, "IdOrder", "IdOrder", orderItem.IdOrder);
            return View(orderItem);
        }

        // GET: OrderItems/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderItem = _repositoryOrderItem.GetById(id);

            if (orderItem == null)
            {
                return NotFound();
            }
            ViewData["IdOrder"] = new SelectList(_repositoryOrder.GetAll, "IdOrder", "IdOrder", orderItem.IdOrder);
            return View(orderItem);
        }

        // POST: OrderItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdOrderItem,IdOrder,IdRestaurantMenuItem,Quantity,PricePerUnity")] OrderItem orderItem)
        {
            if (id != orderItem.IdOrderItem)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _repositoryOrderItem.Update(orderItem);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderItemExists(orderItem.IdOrderItem))
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
            ViewData["IdOrder"] = new SelectList(_repositoryOrder.GetAll, "IdOrder", "IdOrder", orderItem.IdOrder);
            return View(orderItem);
        }

        // GET: OrderItems/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderItem =  _repositoryOrderItem.GetById(id);
            if (orderItem == null)
            {
                return NotFound();
            }

            return View(orderItem);
        }

        // POST: OrderItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var orderItem = _repositoryOrderItem.GetById(id);

            return RedirectToAction(nameof(Index));
        }

        private bool OrderItemExists(int id)
        {
            return _repositoryOrderItem.GetById(id) != null ;
        }
    }
}
