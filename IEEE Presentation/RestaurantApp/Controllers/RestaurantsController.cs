using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestaurantApp.Models;
using RestaurantApp.Repository;

namespace RestaurantApp.Controllers
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

            var restaurant = await _repo.GetAll();
            var result= await restaurant.Where(m => m.IdRestaurant == id).FirstOrDefaultAsync();

            if (result == null)
            {
                return NotFound();
            }

            return View(result);
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
        public async Task<IActionResult> Create([Bind("IdRestaurant,Name,Cuisine,Description,Image")] Restaurant restaurant, IFormFile imageFile)
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

            var restaurant = await _repo.GetAll();
            var result = await restaurant.Where(m => m.IdRestaurant == id).FirstOrDefaultAsync();

            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }

        // POST: Restaurants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRestaurant,Name,Cuisine,Description,Image")] Restaurant restaurant)
        {
            if (id != restaurant.IdRestaurant)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _repo.Update(restaurant);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await RestaurantExists(restaurant.IdRestaurant))
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

            var restaurant = await _repo.GetAll();
            var result = restaurant.FirstOrDefaultAsync(m => m.IdRestaurant == id);

            if (restaurant == null)
            {
                return NotFound();
            }

            return View(result);
        }

        // POST: Restaurants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var restaurant = await _repo.GetAll();
            var result = restaurant.FirstOrDefaultAsync(m => m.IdRestaurant == id);

            await _repo.Remove(result.Id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> RestaurantExists(int id)
        {
            var restaurant = await _repo.GetAll();
            return await restaurant.AnyAsync(m => m.IdRestaurant == id);
        }
    }
}
