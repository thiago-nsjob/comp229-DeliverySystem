using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodDelivery.Models;
using FoodDelivery.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FoodDelivery.Controllers
{
    public class OrderStatusController : Controller
    {
        private readonly IRepository<OrderStatus> _repository;

        public OrderStatusController(IRepository<OrderStatus> repository)
        {
            _repository = repository;
        }

        // GET: Delivery Order
        public IActionResult Index()
        {
            return View(_repository.GetAll);
        }

        // GET: DeliveryAddress/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("IdOrderStatus,StatusName")] OrderStatus orderStatus)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(orderStatus);

                return RedirectToAction(nameof(Index));
            }
            return View(orderStatus);
        }

        // GET: Customers/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var orderStatus = _repository.GetById(id);

            if (_repository.GetById(id) == null)
                return NotFound();



            return View(orderStatus);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var order = _repository.GetById(id);
            _repository.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}