using FoodDelivery.Data;
using FoodDelivery.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDelivery.Repository
{
    public class RestaurantMenuRepository : IRepository<RestaurantMenu>
    {
        private FoodDeliveryContext _context;
        public RestaurantMenuRepository(FoodDeliveryContext context)
        {
            _context = context;
        }
        public IEnumerable<RestaurantMenu> GetAll =>
            _context.RestaurantMenu
            .Include(item => item.TblRestaurantMenuItem)
            .Include(item => item.RestaurantNavigation);

        public void Add(RestaurantMenu entity)
        {
            _context.RestaurantMenu.Add(entity);
            _context.SaveChanges();
        }

        public RestaurantMenu GetById(int? Id)
        {
            return _context.RestaurantMenu
                .SingleOrDefault(item => item.IdRestaurantMenu == Id.Value);
        }

        public void Remove(int? Id)
        {
            var customer = GetById(Id);
            _context.RestaurantMenu.Remove(customer);
            _context.SaveChanges();
        }

        public void Update(RestaurantMenu entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }
    }
}
