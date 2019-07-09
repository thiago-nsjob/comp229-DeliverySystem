using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FoodDelivery.Models;
using FoodDelivery.Models.ViewModels;

namespace FoodDelivery.Controllers
{
    public class MenuController : Controller
    {
        private IMenuRepository repository;
        public int PageSize = 4; //to expand this to limit the page size 

        //constructor to pass IProductRepository called repo; then assign repo 
        public MenuController(IMenuRepository repo)
        {
            repository = repo;
        }

        //to expand this to limit the page size
        public ViewResult List(string category, int menuPage = 1)
            => View(new MenusListViewModel
            {
                Menus = repository.Menus
                    .Where(p => category == null || p.Category == category)
                    .OrderBy(p => p.MenuID)
                    .Skip((manuPage - 1) * PageSize)
                    .Take(PageSize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = menuPage,
                    ItemsPerPage = PageSize,
                    //TotalItems = repository.Products.Count()
                    TotalItems = repository.Menus //add filtering on Count
                    .Where(p => category == null || p.Category == category)
                    .Count()
                },

                //PagingInfo = new PagingInfo
                //{
                //    CurrentPage = productPage,
                //    ItemsPerPage = PageSize,
                //    TotalItems = category == null ? 
                //        repository.Products.Count() : 
                //        repository.Products.Where(e => 
                //            e.Category == category).Count()
                //},

                CurrentCategory = category
            });

        //public ViewResult List(int productPage = 1)
        //    => View(repository.Products
        //        .OrderBy(p => p.ProductID)
        //        .Skip((productPage - 1) * PageSize)
        //        .Take(PageSize));

        //public ViewResult List() => View(repository.Products); //List of action created
    }
}
