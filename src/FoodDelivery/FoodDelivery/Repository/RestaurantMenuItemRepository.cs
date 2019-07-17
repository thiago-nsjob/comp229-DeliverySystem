using FoodDelivery.Data;
using FoodDelivery.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDelivery.Repository
{
    public class RestaurantMenuItemRepository : IRepository<RestaurantMenuItem>
    {
        private FoodDeliveryContext _context;
        public RestaurantMenuItemRepository(FoodDeliveryContext context)
        {
            _context = context;
        }

        public IEnumerable<RestaurantMenuItem> GetAll =>
            _context.RestaurantMenuItem
            .Include(res => res.RestaurantMenuNavigation);


        public void Add(RestaurantMenuItem entity)
        {
            _context.RestaurantMenuItem.Add(entity);
            _context.SaveChanges();
        }

        public RestaurantMenuItem GetById(int? Id)
        {
            return _context.RestaurantMenuItem
                   .SingleOrDefault(item => item.IdRestaurantMenuItem == Id.Value);
        }

        public void Remove(int? Id)
        {
            var customer = GetById(Id);
            _context.RestaurantMenuItem.Remove(customer);
            _context.SaveChanges();
        }

        public void Update(RestaurantMenuItem entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }
    }
}
