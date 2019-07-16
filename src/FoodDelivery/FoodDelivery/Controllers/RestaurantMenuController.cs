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
    public class RestaurantMenuController : Controller
    {
        private readonly IRepository<RestaurantMenu> _repository;

        public RestaurantMenuController(IRepository<RestaurantMenu> repository)
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

            var restaurantMenu = _repository.GetById(id);

            if (restaurantMenu == null)
            {
                return NotFound();
            }

            return View(restaurantMenu);
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
        public async Task<IActionResult> Create([Bind("IdRestaurant,Name,Cuisine,Description,Image")] RestaurantMenu restaurantMenu)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(restaurantMenu);
                return RedirectToAction(nameof(Index));
            }
            return View(restaurantMenu);
        }

        // GET: Restaurants/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurantMenu = _repository.GetById(id);
            if (restaurantMenu == null)
            {
                return NotFound();
            }
            return View(restaurantMenu);
        }

        // POST: Restaurants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("IdRestaurant,Name,Cuisine,Description,Image")] RestaurantMenu restaurantMenu)
        {
            if (id != restaurantMenu.IdRestaurantMenu)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _repository.Update(restaurantMenu);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RestaurantMenuExists(restaurantMenu.IdRestaurantMenu))
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
            return View(restaurantMenu);
        }

        // GET: Restaurants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurantMenu = _repository.GetById(id);
            if (restaurantMenu == null)
            {
                return NotFound();
            }

            return View(restaurantMenu);
        }

        // POST: Restaurants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var restaurantMenu = _repository.GetById(id);
            _repository.Remove(restaurantMenu.IdRestaurantMenu);
            return RedirectToAction(nameof(Index));
        }

        private bool RestaurantMenuExists(int id)
        {
            return _repository.GetById(id) != null;
        }
    }
}