using FoodDelivery.Data;
using FoodDelivery.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDelivery.Repository
{
    public class OrderStatusRepository : IRepository<OrderStatus>
    {

        private FoodDeliveryContext _context;
        public OrderStatusRepository(FoodDeliveryContext context)
        {
            _context = context;
        }

        public IEnumerable<OrderStatus> GetAll =>
            _context.OrderStatus;
            

        public void Add(OrderStatus entity)
        {
            _context.OrderStatus.Add(entity);
            _context.SaveChanges();
        }

        public OrderStatus GetById(int? Id)
        {
            return _context.OrderStatus
                .SingleOrDefault(item => item.IdOrderStatus == Id.Value);
        }

        public void Remove(int? Id)
        {
            var orderStatus = GetById(Id);
            _context.OrderStatus.Remove(orderStatus);
            _context.SaveChanges();
        }

        public void Update(OrderStatus entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }
    }
}
