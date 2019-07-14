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
    public class RestaurantsController : Controller
    {
        private readonly IRepository<Restaurant> _repository;

        public RestaurantsController(IRepository<Restaurant> repository)
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

            var restaurant = _repository.GetById(id);

            if (restaurant == null)
            {
                return NotFound();
            }

            return View(restaurant);
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
        public async Task<IActionResult> Create([Bind("IdRestaurant,Name,Cuisine,Description,Image")] Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(restaurant);
                return RedirectToAction(nameof(Index));
            }
            return View(restaurant);
        }

        // GET: Restaurants/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurant = _repository.GetById(id);
            if (restaurant == null)
            {
                return NotFound();
            }
            return View(restaurant);
        }

        // POST: Restaurants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("IdRestaurant,Name,Cuisine,Description,Image")] Restaurant restaurant)
        {
            if (id != restaurant.IdRestaurant)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _repository.Update(restaurant);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RestaurantExists(restaurant.IdRestaurant))
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
            return View(restaurant);
        }

        // GET: Restaurants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurant = _repository.GetById(id);
            if (restaurant == null)
            {
                return NotFound();
            }

            return View(restaurant);
        }

        // POST: Restaurants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var restaurant = _repository.GetById(id);
            _repository.Remove(restaurant.IdRestaurant);
            return RedirectToAction(nameof(Index));
        }

        private bool RestaurantExists(int id)
        {
            return _repository.GetById(id) != null;
        }
    }
}
