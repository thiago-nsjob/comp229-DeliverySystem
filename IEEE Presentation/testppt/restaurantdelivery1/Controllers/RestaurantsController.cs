using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using restaurantdelivery1.Models;
using restaurantdelivery1.Repository;

namespace restaurantdelivery1.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly IRepository<Restaurant> _repoRestaurant;

        public RestaurantsController(IRepository<Restaurant> repoRestaurant)
        {
            _repoRestaurant = repoRestaurant;
        }

        // GET: Restaurants
        public async Task<IActionResult> Index()
        {
            return View(await _repoRestaurant.GetAll());
        }

        // GET: Restaurants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurant = await _repoRestaurant.GetById(id);
                //.FirstOrDefaultAsync(m => m.IdRestaurant == id);
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
        public async Task<IActionResult> Create([Bind("IdRestaurant,Name,Address,Description,Cuisine,Image")] Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                await _repoRestaurant.Add(restaurant);   
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

            var restaurant = await _repoRestaurant.GetById(id);
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
        public async Task<IActionResult> Edit(int id, [Bind("IdRestaurant,Name,Address,Description,Cuisine,Image")] Restaurant restaurant, IFormFile imageFile)
        {
            if (id != restaurant.IdRestaurant)
                return NotFound();
            
            if (ModelState.IsValid)
            {
                try
                {
                    using (var ms = new MemoryStream())
                    {
                        imageFile.CopyTo(ms);
                        restaurant.Image = ms.ToArray();
                    }
                    await _repoRestaurant.Update(restaurant);
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

            var restaurant = await _repoRestaurant.GetById(id);
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
            var restaurant = await _repoRestaurant.GetById(id);
            await _repoRestaurant.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        private bool RestaurantExists(int id)
        {
            return _repoRestaurant.GetById(id)!=null;
        }
    }
}
