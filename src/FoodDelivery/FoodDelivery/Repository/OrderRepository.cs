using FoodDelivery.Data;
using FoodDelivery.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDelivery.Repository
{
    public class OrderRepository : IRepository<Order>
    {
        private FoodDeliveryContext _context;
        public OrderRepository(FoodDeliveryContext context)
        {
            _context = context;
        }
        public IEnumerable<Order> GetAll =>
            _context.Order
            .Include(or => or.TblOrderItem)
            .Include(or => or.CustomerNavigation)
            .Include(or => or.AddressNavigation)
            .Include(or => or.OrderStatusNavigation)
            .Include(or => or.PaymentMethodNavigation)
            .Include(or => or.RestaurantNavigation);


        public void Add(Order entity)
        {
            _context.Order.Add(entity);
            _context.SaveChanges();
        }

        public Order GetById(int? Id)
        {
            return _context.Order
                .SingleOrDefault(item => item.IdCustomer == Id.Value);
        }

        public void Remove(int? Id)
        {
            var order = GetById(Id);
            _context.Order.Remove(order);
            _context.SaveChanges();
        }

        public void Update(Order entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }
    }
}
