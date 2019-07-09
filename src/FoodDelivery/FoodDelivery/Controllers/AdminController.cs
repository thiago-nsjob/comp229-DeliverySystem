using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FoodDelivery.Models;

namespace FoodDelivery.Controllers
{
    public class AdminController : Controller
    {
        private IMenuRepository repository;
        public AdminController(IMenuRepository repo)
        {
            repository = repo;
        }
        public ViewResult Index() => View(repository.Menus);

        public ViewResult Edit(int menuId) =>
            View(repository.Menus.FirstOrDefault(p => p.MenuID == menuId));

        [HttpPost]
        public IActionResult Edit(Menu menu)
        {
            if (ModelState.IsValid)
            {
                repository.SaveMenu(menu);
                TempData["message"] = $"{menu.Name} has been saved";
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values
                return View(menu);
            }
        }

        //public ViewResult Create() => View("Edit", new Product());
        public IActionResult Create() => View("Edit", new Menu());

        [HttpPost]
        public IActionResult Delete(int menuId)
        {
            Menu deletedMenu = repository.DeleteMenu(menuId);
            if (deletedMenu != null)
            {
                TempData["message"] = $"{deletedMenu.Name} was deleted";
            }
            return RedirectToAction("Index");
        }
    }
}
