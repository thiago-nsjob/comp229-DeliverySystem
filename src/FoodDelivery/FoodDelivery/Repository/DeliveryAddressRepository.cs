using FoodDelivery.Data;
using FoodDelivery.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDelivery.Repository
{
    public class DeliveryAddressRepository :IRepository<DeliveryAddress>
    {

        private FoodDeliveryContext _context;

        public DeliveryAddressRepository(FoodDeliveryContext context)
        {
            _context = context;
        }

        public IEnumerable<DeliveryAddress> GetAll =>
            _context.DeliveryAddress
            .Include(add => add.CustomerNavigation);
            

        public void Add(DeliveryAddress entity)
        {
            _context.DeliveryAddress.Add(entity);
            _context.SaveChanges();
        }

        public DeliveryAddress GetById(int? Id)
        {
            return _context.DeliveryAddress
                .Include(add => add.CustomerNavigation)
                .SingleOrDefault(item => item.IdAddress== Id.Value);
        }

        public void Remove(int? Id)
        {
            var add = GetById(Id);
            _context.DeliveryAddress.Remove(add);
            _context.SaveChanges();
        }

        public void Update(DeliveryAddress entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }
    }
}
