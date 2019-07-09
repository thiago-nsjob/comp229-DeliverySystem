using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using FoodDelivery.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using FoodDelivery.Models;
using FoodDelivery.Models.ViewModels;

namespace FoodDelivery.Controllers
{
    public class CartController : Controller
    {
        private IMenuRepository repository;
        private Cart cart; //for Cart Service

        public CartController(IMenuRepository repo, Cart cartService)
        {
            repository = repo;
            cart = cartService;
        }

        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                //Cart = GetCart(),
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        public RedirectToActionResult AddToCart(int menuId, string returnUrl)
        {
            //to direct user to Cart View
            Menu menu = repository.Menus
                .FirstOrDefault(p => p.MenuID == menuId);

            if (menu != null)
            {
                //Cart cart = GetCart();
                cart.AddItem(menu, 1);
                //SaveCart(cart);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToActionResult RemoveFromCart(int menuId,
        string returnUrl)
        {
            Menu menu = repository.Menus
            .FirstOrDefault(p => p.MenuID == menuId);

            if (menu != null)
            {
                //Cart cart = GetCart();
                cart.RemoveLine(menu);
                //SaveCart(cart);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        //private void SaveCart(Cart cart)
        //{
        //    HttpContext.Session.SetJson("Cart", cart);
        //}

        //private Cart GetCart()
        //{
        //    Cart cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
        //    return cart;
        //}

    }
}
