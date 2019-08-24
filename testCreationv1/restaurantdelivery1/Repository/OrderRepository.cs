using Microsoft.EntityFrameworkCore;
using restaurantdelivery1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restaurantdelivery1.Repository
{
    public class OrderRepository : IRepository<Order>
    {
        RestaurantContext _repository;

        public OrderRepository(RestaurantContext repository)
        {
            _repository = repository;
        }

        public async Task<IQueryable<Order>> GetAll() =>
            await Task.FromResult(_repository.Order
                .Include(res => res.MenuItemNavigation)
                .Include(menu => menu.RestaurantNavigation) 
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
                  .SingleOrDefaultAsync(item => item.IdOrder == Id.Value);
        }

        public async Task Remove(int? Id)
        {
            var customer = await GetById(Id);
            _repository.Order.Remove(customer);
            await _repository.SaveChangesAsync();
        }

        public async Task Update(Order entity)
        {
            _repository.Update(entity);
            await _repository.SaveChangesAsync();
        }
        /*
        public Task SaveChangesAsync()
        {
            return Task.Run(() => {
                _repository.SaveChanges();
            });
        }*/
    }
}
