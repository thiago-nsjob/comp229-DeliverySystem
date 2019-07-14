using FoodDelivery.Data;
using FoodDelivery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDelivery.Repository
{
    public class OrderItemRepository : IRepository<OrderItem>
    {
        private FoodDeliveryContext _context;
        public OrderItemRepository(FoodDeliveryContext context)
        {
            _context = context;
        }

        public IEnumerable<OrderItem> GetAll =>
            _context.OrderItem;

        public void Add(OrderItem entity)
        {
            _context.OrderItem.Add(entity);
            _context.SaveChanges();
        }

        public OrderItem GetById(int? Id)
        {
            return _context.OrderItem
               .SingleOrDefault(item => item.IdOrderItem== Id.Value);
        }

        public void Remove(int? Id)
        {
            var customer = GetById(Id);
            _context.OrderItem.Remove(customer);
            _context.SaveChanges();
        }

        public void Update(OrderItem entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }
    }
}
