using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodDelivery.Models;
using FoodDelivery.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodDelivery.Controllers
{
    public class RestaurantMenuItemController : Controller
    {
        private readonly IRepository<RestaurantMenuItem> _repository;

        public RestaurantMenuItemController(IRepository<RestaurantMenuItem> repository)
        {
            _repository = repository;
        }

        // GET: Restaurants
        public IActionResult Index()
        {
            return View(_repository.GetAll);
        }

        // GET: Restaurants/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurantMenuItem = _repository.GetById(id);

            if (restaurantMenuItem == null)
            {
                return NotFound();
            }

            return View(restaurantMenuItem);
        }

        // GET: Restaurants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Restaurants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRestaurant,Name,Cuisine,Description,Image")] RestaurantMenuItem restaurantMenuItem)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(restaurantMenuItem);
                return RedirectToAction(nameof(Index));
            }
            return View(restaurantMenuItem);
        }

        // GET: Restaurants/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurantMenuItem = _repository.GetById(id);
            if (restaurantMenuItem == null)
            {
                return NotFound();
            }
            return View(restaurantMenuItem);
        }

        // POST: Restaurants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("IdRestaurant,Name,Cuisine,Description,Image")] RestaurantMenuItem restaurantMenuItem)
        {
            if (id != restaurantMenuItem.IdRestaurantMenuItem)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _repository.Update(restaurantMenuItem);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RestaurantMenuItemExists(restaurantMenuItem.IdRestaurantMenuItem))
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
            return View(restaurantMenuItem);
        }

        // GET: Restaurants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurantMenuItem = _repository.GetById(id);
            if (restaurantMenuItem == null)
            {
                return NotFound();
            }

            return View(restaurantMenuItem);
        }

        // POST: Restaurants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var restaurantMenuItem = _repository.GetById(id);
            _repository.Remove(restaurantMenuItem.IdRestaurantMenuItem);
            return RedirectToAction(nameof(Index));
        }

        private bool RestaurantMenuItemExists(int id)
        {
            return _repository.GetById(id) != null;
        }
    }
}