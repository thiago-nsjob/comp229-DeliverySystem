using Microsoft.EntityFrameworkCore;
using RestaurantDelivery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantDelivery.Repository
{
    public class OrderRepository : IRepository<Order>
    {
        RestaurantDeliveryContext _repository;

        public OrderRepository(RestaurantDeliveryContext repository)
        {
            _repository = repository;
        }

        public async Task<IQueryable<Order>> GetAll() =>
            await Task.FromResult(_repository.Order
                .Include(ord=>ord.RestaurantNavigation)
                .Include(ord=>ord.MenuItemNavigation)
                );

        public async Task<Order> Add(Order entity)
        {
            await _repository.AddAsync(entity);
            _repository.SaveChanges();
            return entity;
        }

        public async Task<Order> GetById(int? Id)
        {
            return await _repository.Order
                  .SingleOrDefaultAsync(item => item.IdRestaurant == Id.Value);
        }

        public async Task Remove(int? Id)
        {
            var order = await GetById(Id);
            _repository.Order.Remove(order);
            await _repository.SaveChangesAsync();
        }

        public async Task Update(Order entity)
        {
            _repository.Update(entity);
            await _repository.SaveChangesAsync();
        }
    }
}
