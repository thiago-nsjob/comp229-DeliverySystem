using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestaurantDelivery.Models;
using RestaurantDelivery.Repository;

namespace RestaurantDelivery.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly IRepository<Restaurant> _repo;

        public RestaurantsController(IRepository<Restaurant> repo)
        {
            _repo = repo;
        }


        // GET: Restaurants
        public async Task<IActionResult> Index()
        {
            return View(await _repo.GetAll());
        }

        // GET: Restaurants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurants = await _repo.GetAll();
            var restaurant = await restaurants.FirstOrDefaultAsync(m => m.IdRestaurant == id);

            if (restaurant == null)
            {
                return NotFound();
            }

            return View(restaurant);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: Restaurants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRestaurant,Name,Address,Description,Cuisine,Image")] Restaurant restaurant, IFormFile imageFile)
        {
            if (ModelState.IsValid)
            {
                using (var ms = new MemoryStream())
                {
                    imageFile.CopyTo(ms);
                    restaurant.Image = ms.ToArray();
                }
                await _repo.Add(restaurant);
                return RedirectToAction(nameof(Index));
            }
            return View(restaurant);
        }

        // GET: Restaurants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurants = await _repo.GetAll();
            var restaurant = restaurants.Where(res => res.IdRestaurant == id).FirstOrDefault();

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
        public async Task<IActionResult> Edit(int id, [Bind("IdRestaurant,Name,Address,Description,Cuisine,Image")] Restaurant restaurant,IFormFile imageFile)
        {
            if (id != restaurant.IdRestaurant)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    using (var ms = new MemoryStream())
                    {
                        imageFile.CopyTo(ms);
                        restaurant.Image = ms.ToArray();
                    }
                    await _repo.Update(restaurant);
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

            var restaurants = await _repo.GetAll();
            var restaurant = restaurants.Where(res => res.IdRestaurant == id).FirstOrDefault();

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
            var restaurants = await _repo.GetAll();
            var restaurant = restaurants.Where(res => res.IdRestaurant == id).FirstOrDefault();
            await _repo.Remove(restaurant.IdRestaurant);
            return RedirectToAction(nameof(Index));
        }

        private bool RestaurantExists(int id)
        {
            var restaurants = _repo.GetAll().Result;
            return restaurants.Any(e => e.IdRestaurant == id);
        }
    }
}
