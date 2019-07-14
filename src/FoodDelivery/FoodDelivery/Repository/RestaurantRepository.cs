using FoodDelivery.Data;
using FoodDelivery.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDelivery.Repository
{
    public class RestaurantRepository : IRepository<Restaurant>
    {
        private FoodDeliveryContext _context;
        public RestaurantRepository(FoodDeliveryContext context)
        {
            _context = context;
        }
        public IEnumerable<Restaurant> GetAll =>
            _context.Restaurant
            .Include(res => res.TblRestaurantMenu);

        public void Add(Restaurant entity)
        {
            _context.Restaurant.Add(entity);
            _context.SaveChanges();
        }

        public Restaurant GetById(int? Id)
        {
            return _context.Restaurant
                .SingleOrDefault(item => item.IdRestaurant== Id.Value);
        }

        public void Remove(int? Id)
        {
            var customer = GetById(Id);
            _context.Restaurant.Remove(customer);
            _context.SaveChanges();
        }

        public void Update(Restaurant entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }
    }
}
